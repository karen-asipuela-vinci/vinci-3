package be.vinci.exo1;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
@AllArgsConstructor
@NoArgsConstructor  // Constructeur sans arguments requis par JPA
@Entity(name = "produits")  // Spécifie le nom de la table en base de données
public class Produit {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  private int id;

  private String name;
  private String category;
  private double price;

  // Méthode de vérification
  public boolean invalid() {
    return name == null || name.isEmpty() || category == null || category.isEmpty();
  }
}
