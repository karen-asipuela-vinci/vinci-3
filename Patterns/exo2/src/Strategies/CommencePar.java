package Strategies;

public class CommencePar implements Strategy {
  private final char lettre ;

  public CommencePar(char t) {
    this.lettre = t;
  }

  @Override
  public boolean estValide(String mot) {
    return mot.charAt(0) == lettre;
  }
}
