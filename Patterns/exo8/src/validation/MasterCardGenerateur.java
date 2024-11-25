package validation;

import domaine.CarteDeCredit;
import domaine.MasterCard;
import java.util.Calendar;

public class MasterCardGenerateur extends Generateur  {

  public boolean valider(String numero) {
    // check if the number starts with 51, 52, 53, 54, or 55 and has a length of 16
    return (numero.startsWith("51") || numero.startsWith("52") || numero.startsWith("53")
        || numero.startsWith("54") || numero.startsWith("55")) && numero.length() == 16;
  }

  public CarteDeCredit creerCarte(String numero, Calendar dateExpiration, String nom) {
    return new MasterCard(numero, dateExpiration, nom);
  }
}
