import Combinations.And;
import Combinations.Not;
import Combinations.Or;
import Strategies.CommencePar;
import Strategies.DeLongueur;
import Strategies.Palindrome;

public class Main {
	public static void main(String[] args) {
		if (args.length == 0) {
			System.out.println("Usage : java ListerMots1 fichier");
			System.exit(1);
		}
		ListerMots l = new ListerMots(args[0]);
		l.imprimerSi(new CommencePar('t'), new DeLongueur(3), new Palindrome());
		// combinations
		l.imprimerSi(new Not(new CommencePar('c')));
		l.imprimerSi(new And(new CommencePar('t'), new DeLongueur(3)));
		l.imprimerSi(new Or(new CommencePar('t'), new DeLongueur(3)));
	}
}