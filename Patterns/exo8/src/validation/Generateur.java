package validation;

import java.util.Calendar;

import domaine.CarteDeCredit;

public abstract class Generateur {
	public abstract boolean valider(String numero);
	public abstract CarteDeCredit creerCarte(String numero, Calendar dateExpiration, String nom);
}
