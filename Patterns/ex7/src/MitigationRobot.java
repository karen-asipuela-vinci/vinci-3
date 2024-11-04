public class MitigationRobot extends AbstractRobotDecorator {
    public MitigationRobot(Robot robot) {
        super(robot);
    }

    @Override
    public int getShield() {
        return super.getShield()*2;
    }

    @Override
    public void update() {
        super.update();
        System.out.println("MitigationRobot update");
    }
}
