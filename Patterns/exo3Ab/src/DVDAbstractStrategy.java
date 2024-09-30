public class DVDAbstractStrategy implements AbstractStrategy {

  @Override
  public Produit createProduit(String name, int anneeDeParution) {
    return new DVD(name, anneeDeParution);
  }
}
