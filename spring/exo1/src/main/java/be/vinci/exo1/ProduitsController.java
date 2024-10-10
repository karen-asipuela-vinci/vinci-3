package be.vinci.exo1;

import java.util.ArrayList;
import java.util.List;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

@RestController
public class ProduitsController{
  private static final List<Produit> produits = new ArrayList<Produit>();

  static {
    Produit newProduit1 = new Produit(1, "name1", "category1", 12.50 );
    Produit newProduit2 = new Produit(2, "name2", "category2", 12.50 );
    Produit newProduit3 = new Produit(3, "name3", "category3", 12.50 );
    produits.add(newProduit1);
    produits.add(newProduit2);
    produits.add(newProduit3);
  }

  // endpoints
  //createOne
  @PostMapping("/produits/create")
  public Produit create(@RequestBody Produit produit) {
    produit.setId(produits.size()+1);
    produits.add(produit);
    return produit;
  }

  //getAll
  @GetMapping("/produits")
  public Iterable<Produit> getProduits(){
    return produits;
  }

  //getOne
  @GetMapping("/produits/{id}")
  public Produit getProduit(@PathVariable int id){
    return produits.get(id - 1);
  }

  //updateOne
  @PostMapping("/produits/update/{id}")
  public Produit update(@PathVariable int id, @RequestBody Produit produit) {
    Produit produitFound = produits.get(id-1);
    if(produitFound == null){
      throw new ResponseStatusException(HttpStatus.BAD_REQUEST);
    }

    produitFound.setName(produit.getName());
    produitFound.setCategory(produit.getCategory());
    produitFound.setPrice(produit.getPrice());

    return produitFound;
  }

  // deleteAll
  @PostMapping("/delete")
  public void delete() {
    produits.clear();
  }

  //deleteOne
  @PostMapping("/delete/{id}")
  public void delete(@PathVariable int id) {
    produits.remove(id - 1);
  }
}
