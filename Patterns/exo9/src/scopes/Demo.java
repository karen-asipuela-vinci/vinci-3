package scopes;

import java.applet.Applet;
import java.awt.Color;
import java.awt.FlowLayout;

import controls.KaleidoscopeControl;
import factories.GeneralShapeFactory;
import strategies.GeneralShapeMutationStrategy;
import views.FlipKaleidoscopeView;
import views.KaleidoscopeView;

@SuppressWarnings("serial")
public class Demo extends Applet {
	// Construct the applet
	private Kaleidoscope kal;

	private KaleidoscopeView kalView1;

	private KaleidoscopeControl kalControl;

	public Demo() {
		setLayout(new FlowLayout()); // setLayout( new XYLayout() );
		kal = new Kaleidoscope(new GeneralShapeFactory(200),
				new GeneralShapeMutationStrategy(200));

		kalView1 = new FlipKaleidoscopeView(kal, 200);
		kalControl = new KaleidoscopeControl(kal);

		add(kalView1);
		add(kalControl);

		setBackground(Color.lightGray);
	}
}
