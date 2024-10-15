package be.vinci.exo1;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@RestController
@RequestMapping("/produits")
public class ProduitsController {

    @Autowired
    private ProduitService produitService;

    // Create a new product
    @PostMapping("/create")
    public Produit create(@RequestBody Produit produit) {
        if (!produitService.createOne(produit)) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Produit invalide");
        }
        return produit;
    }

    // Get all products
    @GetMapping
    public Iterable<Produit> getProduits() {
        return produitService.getProduits();
    }

    // Get a specific product by ID
    @GetMapping("/{id}")
    public Produit getProduit(@PathVariable int id) {
        return produitService.getProduitById(id)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé"));
    }

    // Update a specific product
    @PostMapping("/update/{id}")
    public Produit update(@PathVariable int id, @RequestBody Produit produit) {
        return produitService.updateProduit(id, produit)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé"));
    }

    // Delete all products
    @PostMapping("/delete")
    public void deleteAll() {
        produitService.deleteAllProduits();
    }

    // Delete a specific product by ID
    @PostMapping("/delete/{id}")
    public void delete(@PathVariable int id) {
        if (!produitService.deleteProduitById(id)) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé");
        }
    }
}
