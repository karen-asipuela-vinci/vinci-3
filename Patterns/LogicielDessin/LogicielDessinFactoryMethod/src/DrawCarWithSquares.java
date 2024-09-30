public class DrawCarWithSquares extends DrawCar{
  @Override
  public Shape createShape(int size, Point point) {
    return new Square(size, point);
  }

}
