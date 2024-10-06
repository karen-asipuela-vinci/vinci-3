using exo3.Models;
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
        foreach (Product p in c.Products)
        {
            WriteLine(p.ProductName);
        }
    }
}


WriteLine("-------------------- 3 -----------------");
/* 3.	Afficher les produits de la catégorie Beverages et Condiments. Utilisez le eager loading ! (avec include).  Le résultat est identique à la requête précédente.
a.	Désactiver le lazy loading -> retirer   .UseLazyLoadingProxies()
b.	Remarquez que vous avez maintenant un seul select !
*/



