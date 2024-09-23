package MultiCombinations;

import Strategies.Strategy;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Et implements Strategy {
  private final List<Strategy> strategies = new ArrayList<>();

  public Et(Strategy... s) {
    strategies.addAll(List.of(s));
  }

  @Override
  public boolean estValide(String mot) throws IOException {
    for (Strategy strategy : strategies) {
      if (!strategy.estValide(mot)){
        return false;
      }
    }
    return true;
  }
}
