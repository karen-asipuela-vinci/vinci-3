public class DrawCarWithCircles extends DrawCar{

  @Override
  public Shape createShape(int size, Point point) {
    return new Circle(size, point);
  }
}
