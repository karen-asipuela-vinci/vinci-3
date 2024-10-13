public class Main {
    public static void main(String[] args) {
        // Créer une instance d'Album avec des informations complètes
        Album lonerism = new Album.Builder("Lonerism", "Tame Impala")
                            .artistCountry("Australie")
                            .releaseDate("2012")
                            .genre("Indie Rock")
                            .label("Modular")
                            .isRemastered(false)
                            .qualityStandard(128)
                            .qualitySubscribe(320)
                            .build();

        // Créer une autre instance d'Album avec seulement quelques informations
        Album orange = new Album.Builder("channel ORANGE", "Frank Ocean")
                            .releaseDate("2012")
                            .genre("R&B")
                            .build();

        // Créer une instance avec encore moins d'informations
        Album visions = new Album.Builder("Visions", "Grimes")
                            .build();

        // Afficher les informations des albums pour les tester
        System.out.println("Album 1: " + lonerism.getTitle() + " by " + lonerism.getArtist());
        System.out.println("Country: " + lonerism.getArtistCountry());
        System.out.println("Genre: " + lonerism.getGenre());
        System.out.println("Quality (Standard): " + lonerism.getQualityStandard() + " kbps");
        System.out.println("Quality (Subscriber): " + lonerism.getQualitySubscribe() + " kbps");
        System.out.println();

        System.out.println("Album 2: " + orange.getTitle() + " by " + orange.getArtist());
        System.out.println("Genre: " + orange.getGenre());
        System.out.println();

        System.out.println("Album 3: " + visions.getTitle() + " by " + visions.getArtist());
    }
}
