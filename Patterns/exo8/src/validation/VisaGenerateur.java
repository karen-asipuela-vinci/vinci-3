package validation;

import domaine.CarteDeCredit;
import domaine.Visa;
import java.util.Calendar;

public class VisaGenerateur extends Generateur {
  public boolean valider(String numero) {
    return numero.startsWith("4") && numero.length() == 16;
  }

  public CarteDeCredit creerCarte(String numero, Calendar dateExpiration, String nom) {
    return new Visa(numero, dateExpiration, nom);
  }

}
