package Decorator;

import Robot.Robot;

public class MitigationRobot extends AbstractRobotDecorator {
    public MitigationRobot(Robot robot) {
        super(robot);
    }


    @Override
    public int diffLife(int i) {
        i = i/2;
        return super.diffLife(i);
    }

    @Override
    public void update() {
        super.update();
        System.out.println("Decorator.MitigationRobot update");
    }
}
