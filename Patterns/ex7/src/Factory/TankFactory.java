package Factory;

public class TankFactory extends RobotFactory {
    @Override
    public Robot.ConcreteRobot createRobot() {
        return new Robot.ConcreteRobot.Builder("Tank")
                .canon(5)
                .shield(200)
                .freq(2)
                .build();
    }
}
