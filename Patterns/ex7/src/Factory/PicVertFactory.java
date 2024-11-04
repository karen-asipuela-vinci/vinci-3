package Factory;

import Robot.ConcreteRobot;

public class PicVertFactory extends RobotFactory {

    @Override
    public ConcreteRobot createRobot() {
        return new Robot.ConcreteRobot.Builder("PicVert")
                .freq(50)
                .canon(1)
                .shield(20)
                .build();
    }
}
