import java.util.HashMap;
import java.util.Map;

public abstract class CreateMagasin {
  Map<String, Produit> etagere = new HashMap<String, Produit>();

  public abstract void ajouterProduit(String name, int anneeDeParution);
  public abstract void retournerProduit(String name);
}
