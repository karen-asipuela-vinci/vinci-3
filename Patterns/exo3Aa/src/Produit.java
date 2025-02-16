public abstract class Produit {
  public double prix;
	private String name;
	private int anneeDeParution;

  public Produit(String name, int anneeDeParution, double prix){
    this.name=name;
    this.anneeDeParution=anneeDeParution;
    this.prix=prix;
  }

  public String getName() {
    return name;
  }

  public int getAnneeDeParution() {
    return anneeDeParution;
  }

  public double getPrix() {
    return prix;
  }

  public void setPrix(int prix){
    this.prix=prix;
  }

}
