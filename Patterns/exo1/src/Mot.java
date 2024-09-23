public class Mot implements Observer{
  int compteurMots = 0;

  @Override
  public void update(String ligne) {
    compteurMots += ligne.split(" ").length;
  }

  @Override
  public void imprimerStats() {
    System.out.println("Nombre de mots : " + compteurMots);
  }
}
