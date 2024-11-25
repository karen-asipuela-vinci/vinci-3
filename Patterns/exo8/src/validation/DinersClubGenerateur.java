package validation;

import domaine.CarteDeCredit;
import domaine.DinersClub;
import java.util.Calendar;

public class DinersClubGenerateur extends Generateur{

  public boolean valider(String numero) {
    return numero.length() == 14 && numero.startsWith("36");
  }

  public CarteDeCredit creerCarte(String numero, Calendar dateExpiration, String nom) {
    return new DinersClub(numero, dateExpiration, nom);
  }
}
