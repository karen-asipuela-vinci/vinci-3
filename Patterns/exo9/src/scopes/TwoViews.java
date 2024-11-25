package scopes;

import java.applet.Applet;
import java.awt.Color;
import java.awt.FlowLayout;

import controls.KaleidoscopeControl;
import factories.GeneralShapeFactory;
import strategies.GeneralShapeMutationStrategy;
import views.FlipKaleidoscopeView;
import views.KaleidoscopeView;
import views.RotateKaleidoscopeView;

@SuppressWarnings("serial")
public class TwoViews extends Applet {
	// Construct the applet
	Kaleidoscope kal;

	KaleidoscopeView kalView1, kalView2;

	KaleidoscopeControl kalControl;

	public TwoViews() {
		setLayout(new FlowLayout());

		kal = new Kaleidoscope(new GeneralShapeFactory(200),
				new GeneralShapeMutationStrategy(200));

		kalView1 = new FlipKaleidoscopeView(kal, 200);
		kalView2 = new RotateKaleidoscopeView(kal, 200);
		kalControl = new KaleidoscopeControl(kal);

		add(kalView1);
		add(kalView2);
		add(kalControl);

		setBackground(Color.lightGray);
	}
}
