package MultiCombinations;

import Strategies.Strategy;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Ou implements Strategy {
  private final List<Strategy> strategies = new ArrayList<>();

  public Ou(Strategy ... strategy){
    strategies.addAll(Arrays.asList(strategy));
  }

  @Override
  public boolean estValide(String mot) throws IOException {
    boolean auMoins1OK = false;
    for (Strategy strategy : strategies) {
      // condition OU : Il faut que l'un ou l'autre soit ok
      if(strategy.estValide(mot)){
        auMoins1OK = true;
      }
    }
    return auMoins1OK;
  }
}
