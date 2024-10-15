package be.vinci.ipl.products;

import org.springframework.stereotype.Service;

@Service
public class ProductService {
    private final ProductRepository productRepository;

    public ProductService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public boolean createOne(Product product) {
        if(product.invalid()){
            return false;
        }
        productRepository.save(product);
        return true;
    }

    public Iterable<Product> getProducts() {
        return productRepository.findAll();
    }

    public java.util.Optional<Product> getProductById(int id) {
        return productRepository.findById(id);
    }

    public java.util.Optional<Product> updateProduct(int id, Product product) {
        if(product.invalid()){
            return java.util.Optional.empty();
        }
        return productRepository.findById(id).map(p -> {
            p.setName(product.getName());
            p.setCategory(product.getCategory());
            p.setPrice(product.getPrice());
            return productRepository.save(p);
        });
    }

    public void deleteAllProducts() {
        productRepository.deleteAll();
    }

    public boolean deleteProductById(int id) {
        if(productRepository.existsById(id)){
            productRepository.deleteById(id);
            return true;
        }
        return false;
    }
}
