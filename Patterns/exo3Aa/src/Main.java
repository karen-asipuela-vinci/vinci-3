public class Main {
    public static void main(String[] args) {
        MagasinDeLivre magasin = new MagasinDeLivre();
        magasin.ajouterProduit("Livre1", 2020);
        magasin.ajouterProduit("Livre2", 2021);

        MagasinDeDVD magasinDVD = new MagasinDeDVD();
        magasinDVD.ajouterProduit("DVD1", 2020);
        magasinDVD.ajouterProduit("DVD2", 2021);
    }
}