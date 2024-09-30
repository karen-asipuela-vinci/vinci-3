
public class DVD extends Produit{
	public static final double PRIX=19.99;

	public DVD(String name, int anneeDeParution){
		super(name, anneeDeParution, PRIX);
	}

	public DVD(String name, int anneDeParution, double prix){
		super(name, anneDeParution, prix);
	}
	
}
