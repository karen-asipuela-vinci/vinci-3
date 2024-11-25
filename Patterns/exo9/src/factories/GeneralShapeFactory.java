package factories;

import java.awt.Color;
import java.awt.Point;
import shapes.Circle;
import shapes.Rectangle;
import shapes.Shape;
import shapes.Square;
import shapes.Triangle;
import util.Randomizer;


public class GeneralShapeFactory extends ShapeFactory {
	private static Randomizer r = new Randomizer();

	public GeneralShapeFactory(int w) {
		super(w);
	}

	public Shape createShape() {
		Shape result;
		int size1 = r.nextInt(MIN_SHAPE_SIZE, MAX_SHAPE_SIZE);
		int size2 = r.nextInt(MIN_SHAPE_SIZE, MAX_SHAPE_SIZE);
		int temp1 = r.nextInt(0, WIDTH / 2);
		int temp2 = r.nextInt(0, WIDTH / 2);
		Point point = new Point(temp1, temp2);
		Color color = new Color(r.nextInt(100, 255), r.nextInt(100, 255), r
				.nextInt(100, 255));
		switch (r.nextInt(0, 3)) {
		case 0:
			result = new Triangle(point, size1, color);
			break;
		case 1:
			result = new Square(point, size1, color);
			break;
		case 2:
			result = new Rectangle(point, size1, size2, color);
			break;
		default:
			result = new Circle(point, size1, color);
			break;
		}
		return (result);
	}
}
