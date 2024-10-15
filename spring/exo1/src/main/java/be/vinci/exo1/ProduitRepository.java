package be.vinci.exo1;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProduitRepository extends CrudRepository<Produit, Integer> {
    // Toutes les méthodes CRUD de base sont déjà disponibles :
  // save(), findById(), findAll(), deleteById(), etc.
}
