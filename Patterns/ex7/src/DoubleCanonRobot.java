public class DoubleCanonRobot extends AbstractRobotDecorator{

  public DoubleCanonRobot(Robot robot) {
    super(robot);
  }

  public int getCanon() {
    return 2 * super.getCanon();
  }

  public void update() {
    super.update();
    System.out.println("DoubleCanonRobot update");
  }
}
