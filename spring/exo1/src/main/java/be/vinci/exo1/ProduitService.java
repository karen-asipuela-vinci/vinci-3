package be.vinci.exo1;
import java.util.List;
import org.springframework.stereotype.Service;

@Service
public class ProduitService {
  private final ProduitRepository produitRepository;


  public ProduitService(ProduitRepository produitRepository) {
    this.produitRepository = produitRepository;
  }

  public boolean createOne(Produit produit) {
    if(produit.invalid()){
      return false;
    }
    produitRepository.save(produit);
    return true;
  }

  public Iterable<Produit> getProduits() {
    return produitRepository.findAll();
  }

  public java.util.Optional<Produit> getProduitById(int id) {
    return produitRepository.findById(id);
  }

  public java.util.Optional<Produit> updateProduit(int id, Produit produit) {
    if(produit.invalid()){
      return java.util.Optional.empty();
    }
    return produitRepository.findById(id).map(p -> {
      p.setName(produit.getName());
      p.setCategory(produit.getCategory());
      p.setPrice(produit.getPrice());
      return produitRepository.save(p);
    });
  }

  public void deleteAllProduits() {
    produitRepository.deleteAll();
  }

  public boolean deleteProduitById(int id) {
    if(produitRepository.existsById(id)){
      produitRepository.deleteById(id);
      return true;
    }
    return false;
  }

}
