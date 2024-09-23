package be.vinci.exo1;

import lombok.AllArgsConstructor;
import lombok.Generated;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
@AllArgsConstructor
public class Produit {

  private int id;
  private String name;
  private String category;
  private double price;

  // add méthode vérification
  public boolean invalid() {
    return id <=0 || name == null || name.isEmpty() || category == null || category.isEmpty();
  }
}