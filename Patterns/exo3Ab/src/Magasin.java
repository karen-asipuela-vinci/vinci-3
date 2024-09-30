import java.util.HashMap;
import java.util.Map;

public class Magasin {
  Map<String, Produit> etagere = new HashMap<String, Produit>();

  public void createMagasin(AbstractStrategy strategy) {
    Produit p1 = strategy.createProduit("DVD1", 2000);
    Produit p2 = strategy.createProduit("DVD2", 2001);
    Produit p3 = strategy.createProduit("Livre1", 2002);
    Produit p4 = strategy.createProduit("Livre2", 2003);
    ajouterProduit(p1);
    ajouterProduit(p2);
    ajouterProduit(p3);
    ajouterProduit(p4);
  }

  public void ajouterProduit(Produit p) {
    etagere.put(p.getNom(), p);
  }

  public void retirerProduit(String nom) {
    etagere.remove(nom);
  }

}
