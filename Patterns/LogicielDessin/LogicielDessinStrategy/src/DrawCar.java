import java.awt.Shape;

public class DrawCar {
	public void draw(int size, AbstractStrategy s) {
		double sizeWheel=size/10;
		double carHeight=size/2;
		double carLength=size;
		for (int i=0;i<50;i++) {
			double center= i/50*carLength;
			Shape c= s.createShape(sizeWheel,new Point(carHeight,center));
		}
		for (int i=15;i<35;i++) {
			double center= i/50*carLength;
			Shape c= s.createShape(sizeWheel,new Point(carHeight,center));
		}
		//.....
	}
}
