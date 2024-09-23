import Strategies.CommencePar;
import Strategies.Strategy;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.StringTokenizer;

public class ListerMots {

  private final String fichier;
  private final Compteur compteurMotsOk = new Compteur();

  public ListerMots(String fichier) {
    this.fichier = fichier;
  }

  void imprimerSi(Strategy... strategy) {
    try {
      BufferedReader input = new BufferedReader(new FileReader(this.fichier));
      String buffer = null;
      while ((buffer = input.readLine()) != null) {
        StringTokenizer mots = new StringTokenizer(buffer, " \t.;(){}\"'*=:!/\\");
        while (mots.hasMoreTokens()) {
          String mot = mots.nextToken();
          for (Strategy s : strategy) {
            if (s.estValide(mot)) {
              System.out.println(mot);
              // compteur
              compteurMotsOk.incrementer();
            }
          }
        }
      }
      // imprimer le compteur
      System.out.println("Nombre de mots valides : " + compteurMotsOk.getNbMots());
    } catch (IOException e) {
      throw new RuntimeException(e);
    }
  }
}
