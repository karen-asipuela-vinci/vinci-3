package Decorator;

import Robot.Robot;

public class DoubleCanonRobot extends AbstractRobotDecorator {
  public DoubleCanonRobot(Robot robot) {
    super(robot);
  }

  @Override
  public int getCanon() {
    return 2 * super.getCanon();
  }

  @Override
  public void update() {
    // Ajout d'un comportement spécifique pour ce décorateur
    System.out.println("Decorator.DoubleCanonRobot active");
    // Propagation de l'appel à la chaîne de décorateurs, si applicable
    super.update();
  }
}
