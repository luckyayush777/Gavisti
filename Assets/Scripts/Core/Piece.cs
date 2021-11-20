public class Piece
{
    private int _xCoordinate ;
    private int _yCoordinate;

    public Piece(int x, int y)
    {
        _xCoordinate = x;
        _yCoordinate = y;
    }

    public int GetXCoordinate()
    {
        return _xCoordinate;
    }

    public int GetYCoordinate()
    {
        return _yCoordinate;
    }

    public void SetXCoordinate(int xCoordinate)
    {
        _xCoordinate = xCoordinate;
    }

    public void SetYCoordinate(int yCoordinate)
    {
        _yCoordinate = yCoordinate;
    }
}
