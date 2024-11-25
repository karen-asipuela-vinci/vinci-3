package scopes;

import java.applet.Applet;
import java.awt.Color;
import java.awt.FlowLayout;

import controls.KaleidoscopeControl;
import factories.CircleFactory;
import factories.GeneralShapeFactory;
import strategies.GeneralShapeMutationStrategy;
import views.FlipKaleidoscopeView;
import views.KaleidoscopeView;

@SuppressWarnings("serial")
public class FactoryDemo extends Applet {
	// Construct the applet
	private Kaleidoscope kal1, kal2;

	private KaleidoscopeView kalView1, kalView2;

	private KaleidoscopeControl kalControl;

	public FactoryDemo() {
		setLayout(new FlowLayout()); // setLayout( new XYLayout() );
		kal1 = new Kaleidoscope(new GeneralShapeFactory(200),
				new GeneralShapeMutationStrategy(200));
		kal2 = new Kaleidoscope(new CircleFactory(200),
				new GeneralShapeMutationStrategy(200));

		kalView1 = new FlipKaleidoscopeView(kal1, 200);
		kalView2 = new FlipKaleidoscopeView(kal2, 200);
		kalControl = new KaleidoscopeControl(kal1);
		kalControl.register(kal2);

		add(kalView1);
		add(kalView2);
		add(kalControl);

		setBackground(Color.lightGray);
	}
}
