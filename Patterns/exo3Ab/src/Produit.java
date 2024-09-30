public abstract class Produit {
  private String nom;
  private int anneeDeParution;
  private double prix;

  public Produit(String nom, int anneeDeParution, double prix) {
    this.nom = nom;
    this.anneeDeParution = anneeDeParution;
    this.prix = prix;
  }
  public String getNom() {
    return nom;
  }
  public int getAnneeDeParution() {
    return anneeDeParution;
  }
  public void setNom(String nom) {
    this.nom = nom;
  }
  public void setAnneeDeParution(int anneeDeParution) {
    this.anneeDeParution = anneeDeParution;
  }
  public String toString() {
    return "Produit [nom=" + nom + ", anneeDeParution=" + anneeDeParution + "]";
  }

}
