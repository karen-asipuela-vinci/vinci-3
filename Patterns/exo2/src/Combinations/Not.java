package Combinations;

import Strategies.Strategy;
import java.io.IOException;

public class Not implements Strategy {
  private final Strategy strategy;

  public Not(Strategy s) {
    this.strategy = s;
  }

  @Override
  public boolean estValide(String mot) throws IOException {
    return !strategy.estValide(mot);
  }


}
