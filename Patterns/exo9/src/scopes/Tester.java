package scopes;

import java.applet.Applet;
import java.awt.Color;
import java.awt.FlowLayout;

import controls.KaleidoscopeControl;
import factories.GeneralShapeFactory;
import strategies.CompositeShapeMutationStrategy;
import strategies.GeneralShapeMutationStrategy;
import views.FlipKaleidoscopeView;
import views.KaleidoscopeView;

@SuppressWarnings("serial")
public class Tester extends Applet {
	// Construct the applet
	private Kaleidoscope kal;

	private KaleidoscopeView kalView1;

	private KaleidoscopeControl kalControl;

	public Tester() {
		setLayout(new FlowLayout());
		CompositeShapeMutationStrategy s = new CompositeShapeMutationStrategy(
				200);

		s.add(new GeneralShapeMutationStrategy(200));
		// s.add( new ImplodeShapeMutationStrategy(200) );

		kal = new Kaleidoscope(new GeneralShapeFactory(200), s);

		kalView1 = new FlipKaleidoscopeView(kal, 200);
		// kalView2 = new RotateKaleidoscopeView(kal);
		kalControl = new KaleidoscopeControl(kal);

		add(kalControl);
		add(kalView1);
		// add(kalView2, new XYConstraints(215, 10, 200, 200));

		setBackground(Color.lightGray);

	}
}
