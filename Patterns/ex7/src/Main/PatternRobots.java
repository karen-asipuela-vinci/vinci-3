package Main;

import Decorator.DoubleCanonRobot;
import Decorator.DoubleShieldRobot;
import Decorator.MitigationRobot;
import Robot.ConcreteRobot;
import Robot.Robot;
import Factory.*;

public class PatternRobots {
	
	public static void fight(Robot robot1, Robot robot2) {
		int tick1=robot1.getFreq();
		int tick2=robot2.getFreq();
		while(robot2.diffLife(0)>0 && robot1.diffLife(0)>0) {
			int tick=Math.min(tick1, tick2);
			tick1-=tick;
			tick2-=tick;
			if (tick1==0) {// robot 1 feu
				tick1=shoot(robot1,robot2);
			}
			if (tick2==0) {// robot 2 feu
				tick2=shoot(robot2,robot1);
			}
		}
	}
	
	private static int shoot(Robot robot1, Robot robot2) {
		int dmg=Math.max(0,robot1.getCanon()-robot2.getShield());
		int lost=robot2.diffLife(0)-robot2.diffLife(-dmg);
		System.out.println(robot1.getName()+" shoots for "+lost);
		if (robot2.diffLife(0)<=0) {
			System.out.println("Kabooom "+robot2.getName());
		}
		return robot1.getFreq();
	}

	public static void main(String[] args) {
		// un robot avec un canon de 10, un bouclier de 2, une fréquence de tir de 100
		// et qui a reçu une amélioration de canon multipliant la puissance de ce dernier par 2.
		Robot robot1= new ConcreteRobot.Builder("Robot1").shield(2).freq(100).canon(10).build();
		robot1 = new DoubleCanonRobot(robot1);

		//check if the robot1 has the double canon+
		System.out.println(robot1.getCanon());
		// check vie
		System.out.println(robot1.diffLife(0));

		// un robot avec un canon de 9, un bouclier de 3, une fréquence de tir de 9
		// et qui a reçu une amélioration de bouclier multipliant ce dernier par 2
		// et une amélioration de mitigation des dégats qui réduit les points de vue perdus par 2.
		Robot robot2= new ConcreteRobot.Builder("Robot2").shield(3).freq(9).canon(9).build();
		robot2 = (Robot) new DoubleShieldRobot(robot2);
		robot2 = new MitigationRobot(robot2);
		//checks
		System.out.println(robot2.getShield());
		System.out.println(robot2.diffLife(0));

		fight(robot1, robot2);

		System.out.printf("-------------------------\n");

		// utilisation des factory method
		RobotFactory picVertFactory = new PicVertFactory();
		RobotFactory grosseBertaFactory = new GrosseBertaFactory();
		RobotFactory tankFactory = new TankFactory();

		Robot picVert = picVertFactory.createRobot();
		Robot grosseBerta = grosseBertaFactory.createRobot();
		Robot tank = tankFactory.createRobot();

		fight(picVert, grosseBerta);
		System.out.println("-------------------------------------------\n");
		fight(picVert, tank);
		System.out.println("-------------------------------------------\n");
		fight(grosseBerta, tank);

	}
}
