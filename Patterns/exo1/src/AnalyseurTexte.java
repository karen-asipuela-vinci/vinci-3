import java.util.ArrayList;
import java.util.List;

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

  public void lireFichier() {

  }
}
