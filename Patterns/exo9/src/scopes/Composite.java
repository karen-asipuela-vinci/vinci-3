package scopes;

import java.applet.Applet;
import java.awt.Color;
import java.awt.FlowLayout;

import controls.KaleidoscopeControl;
import factories.GeneralShapeFactory;
import strategies.CompositeShapeMutationStrategy;
import strategies.ExplodeShapeMutationStrategy;
import strategies.SpinShapeMutationStrategy;
import views.FlipKaleidoscopeView;
import views.KaleidoscopeView;

@SuppressWarnings("serial")
public class Composite extends Applet {
	// Construct the applet
	private Kaleidoscope kal;

	private KaleidoscopeView kalView1;

	private KaleidoscopeControl kalControl;

	public Composite() {
		setLayout(new FlowLayout());
		CompositeShapeMutationStrategy s = new CompositeShapeMutationStrategy(
				200);

		s.add(new SpinShapeMutationStrategy(200));
		s.add(new ExplodeShapeMutationStrategy(200));

		kal = new Kaleidoscope(new GeneralShapeFactory(200), s);

		kalView1 = new FlipKaleidoscopeView(kal, 200);
		kalControl = new KaleidoscopeControl(kal);

		add(kalView1);
		add(kalControl);

		setBackground(Color.lightGray);
	}
}
