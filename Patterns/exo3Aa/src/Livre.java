
public class Livre extends Produit{
	public static final double PRIX=14.99;

	public Livre(String name, int anneeDeParution){
		super(name, anneeDeParution, PRIX);
	}

	public Livre(String name, int anneDeParution, double prix){
		super(name, anneDeParution, prix);
	}

}