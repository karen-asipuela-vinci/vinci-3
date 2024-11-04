package Factory;


import Robot.ConcreteRobot;

public class GrosseBertaFactory extends RobotFactory {
    @Override
    public ConcreteRobot createRobot() {
        return new ConcreteRobot.Builder("GrosseBerta")
                .canon(10)
                .freq(2)
                .build();
    }
}
