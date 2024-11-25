package validation;

import domaine.AmEx;
import domaine.CarteDeCredit;
import java.util.Calendar;

public class AmExGenerateur extends Generateur {

  public boolean valider(String numero) {
    // check 15 digits
    if (numero.length() != 15) {
      return false;
    }

    // check first two digits
    return numero.startsWith("34") || numero.startsWith("37");
  }

  public CarteDeCredit creerCarte(String numero, Calendar dateExpiration, String nom) {
    return new AmEx(numero, dateExpiration, nom);
  }
}
