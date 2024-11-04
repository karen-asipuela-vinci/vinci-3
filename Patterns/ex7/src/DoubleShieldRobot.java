public class DoubleShieldRobot extends AbstractRobotDecorator {
    public DoubleShieldRobot(Robot robot) {
        super(robot);
    }

    @Override
    public int getShield() {
        return 2 * super.getShield();
    }

    @Override
    public void update() {
        super.update();
        System.out.println("DoubleShieldRobot update");
    }
}
