package strategies;

import java.awt.Point;

import shapes.Shape;

public class GeneralShapeMutationStrategy extends ShapeMutationStrategy {

	public GeneralShapeMutationStrategy(int w) {
		super(w);
	}

	public void mutate(Shape s) {
		s.translateTo(new Point(r.nextInt(0, width), r.nextInt(0, width)));
	}
}
