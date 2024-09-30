public class LivreAbstractStrategy implements AbstractStrategy {
  @Override
  public Produit createProduit(String name, int anneeDeParution) {
    return new Livre(name, anneeDeParution);
  }

}
