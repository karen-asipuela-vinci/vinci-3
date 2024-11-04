package Decorator;

import Robot.Robot;

public abstract class AbstractRobotDecorator implements RobotDecorator {
    protected final Robot robot;

    public AbstractRobotDecorator(Robot robot) {
        this.robot = robot;
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
        // Appelle la méthode update du robot décoré si c'est aussi un décorateur
        if (robot instanceof RobotDecorator) {
            ((RobotDecorator) robot).update();
        }
    }
}