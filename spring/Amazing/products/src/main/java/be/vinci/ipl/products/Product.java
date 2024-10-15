package be.vinci.ipl.products;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.*;

@Getter
@Setter
@ToString
@AllArgsConstructor
@NoArgsConstructor  // Constructeur sans arguments requis par JPA
public class Product {
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

