import Strategies.Strategy;
import java.io.IOException;

public class Compteur implements Strategy {
  // = decorator
  // le nombre de mots sélectionnés
  private int nbMots = 0;

  public void incrementer() {
    nbMots++;
  }

  public int getNbMots() {
    return nbMots;
  }

  @Override
  public boolean estValide(String mot) throws IOException {
    return false;
  }
}
