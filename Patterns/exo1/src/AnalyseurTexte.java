import java.util.ArrayList;

public class AnalyseurTexte {
  // attributs
  ArrayList<Observer> observersList = new ArrayList<Observer>();

  // méthodes
  public void addObs(Observer observer) {
      observersList.add(observer);
  }

  public void removeObs (Observer observer) {
    observersList.remove(observer);
  }

  public void lireFichier(String fichier) {
    for (Observer observer : observersList) {
      observer.update(fichier);
    }
  }
}
