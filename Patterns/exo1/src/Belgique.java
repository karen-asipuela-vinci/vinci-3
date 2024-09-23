import java.util.Objects;

public class Belgique implements Observer{
  int compteurBelgique = 0;
  @Override
  public void update(String ligne) {
    String[] list = ligne.split(" ");
    for (String s : list) {
      if (Objects.equals(s, "Belgique")) {
        compteurBelgique++;
      }
    }
  }
}
