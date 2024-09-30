
public class CircleAbstractStrategy implements AbstractStrategy {
  @Override
  public Shape createShape(double size, Point point) {
    return new Circle(size, point);
  }

}
