import java.util.HashMap;
import java.util.Map;


public class MagasinDeDVD extends CreateMagasin{
	@Override
	public void ajouterProduit(String name, int anneeDeParution){
		DVD dvd = new DVD(name, anneeDeParution);
		etagere.put(name, dvd);
	}

	@Override
	public void retournerProduit(String name){
		etagere.get(name);
	}
}
