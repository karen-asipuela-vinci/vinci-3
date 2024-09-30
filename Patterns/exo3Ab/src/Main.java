public class Main {
    public static void main(String[] args) {
        Magasin magasinDVD = new Magasin();
        magasinDVD.createMagasin(new DVDAbstractStrategy());

        Magasin magasinLivre = new Magasin();
        magasinLivre.createMagasin(new LivreAbstractStrategy());
    }
}