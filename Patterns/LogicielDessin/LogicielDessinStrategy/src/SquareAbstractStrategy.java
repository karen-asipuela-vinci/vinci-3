public class SquareAbstractStrategy implements AbstractStrategy {
  @Override
  public Shape createShape(double size, Point point) {
    return new Square(size, point);
  }

}
