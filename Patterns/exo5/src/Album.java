public class Album {
  // attributs
  private String title; // obligatoire
  private String artist; // obligatoire

  private String label;
  private String producer;
  private String artistCountry;
  private String version;
  private String genre;
  private String releaseDate;
  private boolean isRemastered;
  private String releaseDateOriginal;
  private int qualityStandard;
  private int qualitySubscribe;

  // Constructeur
  private Album(Builder builder ){
    this.title = builder.title;
    this.artist = builder.artist;
    this.label = builder.label;
    this.producer = builder.producer;
    this.artistCountry = builder.artistCountry;
    this.version = builder.version;
    this.genre = builder.genre;
    this.releaseDate = builder.releaseDate;
    this.isRemastered = builder.isRemastered;
    this.releaseDateOriginal = builder.releaseDateOriginal;
    this.qualityStandard = builder.qualityStandard;
    this.qualitySubscribe = builder.qualitySubscribe;
  }

  //   // comme 2 seules variables sont obligatoires
  // on va utiliser un Builder Pattern
  // ICI CLASSE INTERNE A ALBUM
  public static class Builder {
    // a les memes attributs que Album
    public String title;
    public String artist;
    public String label;
    public String producer;
    public String artistCountry;
    public String version;
    public String genre;
    public String releaseDate;
    public boolean isRemastered;
    public String releaseDateOriginal;
    public int qualityStandard;
    public int qualitySubscribe;

    // Constructeur avec les 2 seules variables obligatoires
    public Builder(String title, String artist) {
      this.title = title;
      this.artist = artist;
    }

    // pour les autres attributs, méthodes qui retournent le Builder // set
    public Builder label(String label) {
      this.label = label;
      return this;
    }
    public Builder producer(String producer) {
      this.producer = producer;
      return this;
    }
    public Builder artistCountry(String artistCountry) {
      this.artistCountry = artistCountry;
      return this;
    }
    public Builder version(String version) {
      this.version = version;
      return this;
    }
    public Builder genre(String genre) {
      this.genre = genre;
      return this;
    }
    public Builder releaseDate(String releaseDate) {
      this.releaseDate = releaseDate;
      return this;
    }
    public Builder isRemastered(boolean isRemastered) {
      this.isRemastered = isRemastered;
      return this;
    }
    public Builder releaseDateOriginal(String releaseDateOriginal) {
      this.releaseDateOriginal = releaseDateOriginal;
      return this;
    }
    public Builder qualityStandard(int qualityStandard) {
      this.qualityStandard = qualityStandard;
      return this;
    }
    public Builder qualitySubscribe(int qualitySubscribe) {
      this.qualitySubscribe = qualitySubscribe;
      return this;
    }

    // méthode qui construit l'objet Album --> appelle le constructeur de Album
    public Album build() {
      return new Album(this);
    }
  }

  // Getters
  public String getTitle() {
    return title;
  }
  public String getArtist() {
    return artist;
  }
  public String getLabel() {
    return label;
  }
  public String getProducer() {
    return producer;
  }
  public String getArtistCountry() {
    return artistCountry;
  }
  public String getVersion() {
    return version;
  }
  public String getGenre() {
    return genre;
  }
  public String getReleaseDate() {
    return releaseDate;
  }
  public boolean getIsRemastered() {
    return isRemastered;
  }
  public String getReleaseDateOriginal() {
    return releaseDateOriginal;
  }
  public int getQualityStandard() {
    return qualityStandard;
  }
  public int getQualitySubscribe() {
    return qualitySubscribe;
  }
}
