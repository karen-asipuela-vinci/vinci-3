package be.vinci.ipl.products;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductRepository extends CrudRepository<Product, Integer> {
    // Toutes les méthodes CRUD de base sont déjà disponibles :
    // save(), findById(), findAll(), deleteById(), etc.
}
