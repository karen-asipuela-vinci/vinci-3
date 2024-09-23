package Combinations;

import Strategies.Strategy;
import java.io.IOException;

public class And implements Strategy {
  private final Strategy strategy1;
  private final Strategy strategy2;

  public And(Strategy s1, Strategy s2) {
    this.strategy1 = s1;
    this.strategy2 = s2;
  }

  @Override
  public boolean estValide(String mot) throws IOException {
    return strategy1.estValide(mot) && strategy2.estValide(mot);
  }

}
