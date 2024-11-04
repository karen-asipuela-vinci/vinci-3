public abstract class AbstractRobotDecorator implements RobotDecorator {
    private final RobotDecorator robot;

    public AbstractRobotDecorator(Robot robot) {
        this.robot = (RobotDecorator) robot;
    }

    @Override
    public int getCanon() {
        return robot.getCanon();
    }

    @Override
    public int getShield() {
        return robot.getShield();
    }

    @Override
    public int getFreq() {
        return robot.getFreq();
    }

    @Override
    public String getName() {
        return robot.getName();
    }

    @Override
    public int diffLife(int i) {
        return robot.diffLife(i);
    }

    @Override
    public void update() {
        robot.update();
    }
}
