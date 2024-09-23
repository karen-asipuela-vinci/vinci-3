package Strategies;

public class DeLongueur implements Strategy {
  private final int longueur;
  public DeLongueur(int longueur) {
    this.longueur = longueur;
  }

  @Override
  public boolean estValide(String mot) {
    if (mot.length() == longueur) {
      System.out.println(mot);
    }
    return false;
  }
}
