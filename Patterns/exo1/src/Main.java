import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class Main {

  public static void main(String[] args) {
    BufferedReader lecteurAvecBuffer = null;
		String ligne;

    AnalyseurTexte analyseur = new AnalyseurTexte();
    analyseur.addObs(new Mot());
    analyseur.addObs(new Ligne());
    analyseur.addObs(new Belgique());
    analyseur.addObs(new Palindrome());

    try {
      lecteurAvecBuffer = new BufferedReader(new FileReader(args[0]));
      while ((ligne = lecteurAvecBuffer.readLine()) != null) {
        analyseur.lireFichier(lecteurAvecBuffer.readLine());
      }
    } catch (IOException e) {
      e.printStackTrace();
    } finally {
      try {
        if (lecteurAvecBuffer != null)
          lecteurAvecBuffer.close();
      } catch (IOException e) {
        e.printStackTrace();
      }

    }
  }
}