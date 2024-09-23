package Strategies;

public class Palindrome implements Strategy {

  @Override
  public boolean estValide(String mot) {
    int i = 0;
    int j = mot.length() - 1;
    while (i < j) {
      if (mot.charAt(i) != mot.charAt(j)) {
        return false;
      }
      i++;
      j--;
    }
    return true;
  }
}
