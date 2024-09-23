public class Ligne implements Observer{
  // attributs
  int compteurLignes = 0;
  @Override
  public void update(String ligne) {
    compteurLignes++;
  }
  @Override
  public void imprimerStats() {
    System.out.println("Nombre de lignes : " + compteurLignes);
  }
}
