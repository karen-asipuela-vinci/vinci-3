using exo3.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Drawing.Drawing2D;
using static System.Console; //# pour ne pas taper Console à chaque fois

WriteLine("------------------ Activation Lazy Loading ----------------");

WriteLine("------------------ exo 1 --------------------");

//## 1. Lister tous les Customers habitants dans une ville saisie au clavier.

// Demander la ville à l'utilisateur
WriteLine("Entrez le nom de la ville : ");
string? city = ReadLine();

if (city != null)
{
    //# le lancer que quand utilisé
    NorthwindContext context = new();

    // Requête pour lister les clients dans la ville saisie
    var customersCity = from cust in context.Customers
                        where cust.City == city
                        select new
                        {
                            cust.CustomerId,
                            cust.ContactName
                        };

    // Vérification s'il y a des résultats et affichage
    if (customersCity.Any()) // Vérifie si la collection n'est pas vide
    {
        WriteLine($"Clients dans la ville {city} :");
        foreach (var cust in customersCity)
        {
            WriteLine($"ID: {cust.CustomerId}, Nom: {cust.ContactName}");
        }
    }
    else
    {
        WriteLine($"Aucun client trouvé dans la ville {city}.");
    }
}
else
{
    WriteLine("Le nom de la ville ne peut pas être vide.");
}

//## 2.Afficher les produits de la catégorie Beverages et Condiments.
// Utilisez le lazy loading  (pas d’include !)

WriteLine("------------------- 2 -----------------");

using (NorthwindContext context = new ())
{

    IQueryable<Category> categories = from Category c in context.Categories
                                      where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                      select c;

    foreach (Category c in categories)
    {
        WriteLine("Catégorie :  " + c.CategoryName);
        WriteLine("**************************");
        foreach (Product p in c.Products)
        {
            WriteLine(p.ProductName);
        }
    }
}


WriteLine("-------------------- 3 -----------------");
//## 3.	Afficher les produits de la catégorie Beverages et Condiments. 
 /* Utilisez le eager loading ! (avec include).  
  * Le résultat est identique à la requête précédente.
 * a.	Désactiver le lazy loading -> retirer   .UseLazyLoadingProxies()
 * b.	Remarquez que vous avez maintenant un seul select !
*/


using (NorthwindContext context = new())
{
    IQueryable<Category> categories = from Category c in context.Categories.Include("Products")
                                      where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                      select c;

    foreach (Category c in categories)
    {
        WriteLine("Catégorie : " + c.CategoryName);
        WriteLine("**************************");
        foreach (Product p in c.Products)
        {
            WriteLine(p.ProductName);
        }
    }
}

WriteLine("-------------------- 4 -----------------");
//## 4.
/* Donnez pour un client donné saisi au clavier (LILAS par ex) 
 * la liste de ces commandes (de la plus récente à la plus ancienne) 
 * et qui ont été livrées ( il y a une date de livraison). Les champs renvoyés par ce query sont le ID du client «CustomerID »,  
 * la date de la commande « OrderDate » et la date de livraison « ShippedDate ».
 */

using (NorthwindContext context = new())
{
    string? clientName = "";

    while (clientName == "")
    {
        WriteLine("Entrez le nom du client (ID) : ");
        clientName = ReadLine();
    }

    var queryOrders = from orders in context.Orders
                      where (orders.CustomerId == clientName)
                      && (orders.ShippedDate != null)
                      orderby orders.ShippedDate descending
                      select new
                      {
                          CustomerID = clientName,
                          orders.OrderDate,
                          orders.ShippedDate
                      };

    foreach (var order in queryOrders)
    {
        WriteLine("CustomerID : {0}  OrderDate : {1}   ShippedDate : {2} ", order.CustomerID, order.OrderDate, order.ShippedDate);
    }

}

WriteLine("-------------------- 5 -----------------");
//## 5.Afficher le total des ventes par produit (ID  produit -> Total)
//trié par ordre de numéro produit.

using (NorthwindContext context = new())
{
    var querySells = from od in context.OrderDetails.AsEnumerable() // Cette conversion signifie que la requête suivante sera exécutée en mémoire sur des objets .NET plutôt qu'envoyée et exécutée par la base de données.
                     orderby od.ProductId
                     group od by od.ProductId;

    foreach (IGrouping<int, OrderDetail> od in querySells)
    {
        // pour le total de ventes : quantity * unitprice
        WriteLine("{0} ----> {1}", od.Key, od.Sum(o => o.Quantity * o.UnitPrice));
    }

                                                    
}

WriteLine("-------------------- 6 -----------------");
//## 6.	Afficher tous les employés (leur nom) qui ont sous leur responsabilité la région « Western »

//# BIEN RELIRE ET COMPRENDRE CELUI-CI
using (NorthwindContext context = new())
{
    IQueryable<Employee> queryEmployees = from e in context.Employees
                                          where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                                          select e;

    WriteLine("Les employés responsables de la région Western : ");

    foreach (var item in queryEmployees)
    {
        WriteLine(item.LastName + " " + item.FirstName);
    }

}

WriteLine("-------------------- 7 -----------------");
//## 7.	Quels sont les territoires gérés par le supérieur de « Suyama Michael »
//# pareil

using (NorthwindContext context = new())
{
    // Rechercher le supérieur de "Suyama Michael" et obtenir les territoires qu'il gère
    var territories = (from e in context.Employees
                      where (e.LastName.Equals("Suyama")
                      && e.FirstName.Equals("Michael"))
                      select e.ReportsToNavigation.Territories).SingleOrDefault();
                        // reportsTo -> champ vers responsable
                        // reportsToNavigation permet de naviguer vers son responsable en tant qu'objet
                        //### on voyage jusqu'au responsable puis on sélectionne ses territories

    // Afficher les résultats
    WriteLine("Territoires gérés par le supérieur de Suyama Michael :");
    foreach (var territory in territories)
    {
        WriteLine(territory.TerritoryDescription);
    }
}

WriteLine("-------------------------------------");
WriteLine("----------------- c) UPDATES --------------------");

//## 1.	Mettez en majuscule le nom de tous les clients

using (NorthwindContext context = new())
{
    // on choppe tous les clients
    var custs = from c in context.Customers
                select c;

    foreach(var c in custs)
    {
        c.ContactName = c.ContactName.ToUpper();
    }

    // save changes
    try
    {
        context.SaveChanges();
    } catch (OptimisticConcurrencyException)
    {
        context.Refresh(RefreshMode.ClientWins, context.Customers);
        context.SaveChanges();
    }



    //## 2.	Vérifiez que l’update a bien été réalisé en faisant un query qui affiche les noms des clients

    foreach(var c in custs)
    {
        WriteLine(c.ContactName);
    }
}

WriteLine("-------------------------------------");
WriteLine("----------------- d) INSERT --------------------");
//## 1.	Ajoutez une catégorie à partir d’un nom saisi au clavier

WriteLine("Entrez le nom de la catégorie : ");
string? nameCat = ReadLine();

using (NorthwindContext context = new())
{
    //check si déjà existante :
    Category? cat = (from c in context.Categories
                     where c.CategoryName == nameCat
                     select c).SingleOrDefault();

    if (cat == null && nameCat is not null)
    {
        // on créé category
        cat = new Category
        {
            CategoryName = nameCat
        };

        // on save les changes
        try
        {
            // on le rajoute dans la bd via context
            context.Categories.Add(cat);
            context.SaveChanges();
        }
        catch (OptimisticConcurrencyException)
        {
            context.Refresh(RefreshMode.ClientWins, context.Customers);
            context.SaveChanges();
        }
    } else
    {
        WriteLine("Catégorie déjà existante.");
    }

    //## 2.	Vérifiez que l’ajout a bien été effectué en DB

    var createdCategory =( from c in context.Categories
                          where c.CategoryName == nameCat
                          select c).SingleOrDefault();

    if (createdCategory != null)
    {
        WriteLine("ok");
    } else
    {
        WriteLine("ko");
    }
}


WriteLine("-------------------------------------");
WriteLine("----------------- e) DELETES --------------------");

//## 1.	Supprimez la catégorie ajoutée à l’exercice précédent

using (NorthwindContext context = new())
{
    // on sélectionne le dernier créé
    var lastCategoryID = (from c in context.Categories
                        select c.CategoryId).Max();

    var lastCategory = context.Categories.Find(lastCategoryID);

    WriteLine(lastCategory.CategoryName);

    if (lastCategory != null)
    {
        // on save les changes
        try
        {
            // on supprime dans la db
            context.Categories.Remove(lastCategory);

            context.SaveChanges();
        }
        catch (OptimisticConcurrencyException)
        {
            context.Refresh(RefreshMode.ClientWins, context.Customers);
            context.SaveChanges();
        }
    }


    //## 2.	Vérifiez que la suppression a bien été faite en DB

    var catRemoved = (from c in context.Categories
                      where c.CategoryId == lastCategoryID
                      select c).SingleOrDefault();

    if (catRemoved == null)
    {
        WriteLine("ok");
    } else
    {
        WriteLine("ko");
    }
}

//## 3.	Supprimez un employé et réassignez toutes ses commandes (« orders ») à un autre employé.
// Vous demanderez les «id » des employés au clavier.
// Essayez de supprimer DAVOLIO (employeeId ==1) et de réassigner ses commandes à FULLER (employeeId ==2) 

WriteLine("Entrez l'ID de l'employé à supprimer : ");
string? delete = ReadLine();
int idDelete = int.Parse(delete);

WriteLine("Entrez l'ID de l'employé à réassigner : ");
string? reassigned = ReadLine();
int idReassigned = int.Parse(reassigned);

using (NorthwindContext context = new())
{
    // on cherche l'employé 1 !!! on veut supp ses territories et ses employés :
    Employee toDelete = (from e in context.Employees.Include("Territories").Include("InverseReportsToNavigation")
                    where e.EmployeeId.Equals(idDelete)
                    select e).Single<Employee>();

    // on cherche ses orders à transférer :
    IQueryable<Order> ordersToTransfer = from o in context.Orders
                                         where o.EmployeeId.Equals(idDelete)
                                         select o;

    // on cherche l'employé 2 :
    Employee toReassigned = context.Employees.Find(idReassigned);

    // si tout ok, on assigne les orders 1 à 1
    // et on les supprime
    if (toDelete != null && toReassigned != null)
    {
        foreach (Order o in ordersToTransfer)
        {
            toReassigned.Orders.Add(o);
            toDelete.Orders.Remove(o);
        }

        // puis on supprime tout du 1
        //# faut d'abord vider les tables
        toDelete.Territories.Clear();
        toDelete.InverseReportsToNavigation.Clear();

        context.Employees.Remove(toDelete);
        int affected = context.SaveChanges();
        WriteLine("Nombre de lignes affectées : " + affected);
    }
}