import java.util.Stack;

public class Palindrome implements Observer {
  int compteurPalindromes = 0;

  @Override
  public void update(String ligne) {
    
    // pile
    Stack<Character> pile = new Stack<Character>();
    // séparer les mots
    String[] list = ligne.split(" ");
    for (String s : list) {
      // ajouter les lettres du mot dans la pile
      for (int i = 0; i < s.length(); i++) {
        pile.push(s.charAt(i));
      }
      // vérifier si le mot est un palindrome
      boolean palindrome = true;
      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) != pile.pop()) {
          palindrome = false;
          break;
        }
      }
      // incrémenter le compteur si le mot est un palindrome
      if (palindrome) {
        compteurPalindromes++;
      }
    }

  }

  @Override
  public void imprimerStats() {
    System.out.println("Nombre de palindromes : " + compteurPalindromes);
  }
}
