package validation;

import domaine.CarteDeCredit;
import java.util.Calendar;

public class ChaineValidation {
  private Generateur[] generateurs;

  public ChaineValidation() {
    generateurs = new Generateur[] {
        new VisaGenerateur(),
        new MasterCardGenerateur(),
        new DiscoverGenerateur(),
        new AmExGenerateur(),
        new DinersClubGenerateur()};
  }

  public CarteDeCredit valider(String numero, Calendar dateExpiration, String nom) {
    for (Generateur generateur : generateurs) {
      if (generateur.valider(numero)) {
        return generateur.creerCarte(numero, dateExpiration, nom);
      }
    }
    return null;
  }

}
