package strategies;

import java.awt.Point;

import shapes.Shape;
import util.Randomizer;

public abstract class ShapeMutationStrategy {
	protected static Randomizer r = new Randomizer();

	protected int width;
	protected Point origin;

	public ShapeMutationStrategy(int w) {
		width = w;
		origin = new Point(width / 2, width / 2);
	}

	public abstract void mutate(Shape s);
}
