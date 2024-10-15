package be.vinci.ipl.products;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

@RestController
@RequestMapping("/products")
public class ProductController {
    @Autowired
    private ProductService productService;

    // Create a new product
    @PostMapping("/create")
    public Product create(@RequestBody Product product) {
        if (!productService.createOne(product)) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Produit invalide");
        }
        return product;
    }

    // Get all products
    @GetMapping
    public Iterable<Product> getProducts() {
        return productService.getProducts();
    }

    // Get a specific product by ID
    @GetMapping("/{id}")
    public Product getProduct(@PathVariable int id) {
        return productService.getProductById(id)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé"));
    }

    // Update a specific product
    @PostMapping("/update/{id}")
    public Product update(@PathVariable int id, @RequestBody Product produit) {
        return productService.updateProduct(id, produit)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé"));
    }

    // Delete all products
    @PostMapping("/delete")
    public void deleteAll() {
        productService.deleteAllProducts();
    }

    // Delete a specific product by ID
    @PostMapping("/delete/{id}")
    public void delete(@PathVariable int id) {
        if (!productService.deleteProductById(id)) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Produit non trouvé");
        }
    }
}
