import java.util.HashMap;
import java.util.Map;

public class MagasinDeLivre extends CreateMagasin{
	@Override
	public void ajouterProduit(String name, int anneeDeParution){
		Livre livre = new Livre(name, anneeDeParution);
		etagere.put(name, livre);
	}

	@Override
	public void retournerProduit(String name){
		etagere.get(name);
	}
}
