public class Piece
{
    private int _xCoordinate;
    private int _yCoordinate;

    public int XCoordinate {
        get
        {
            return _xCoordinate;
        }

        set
        {
            _xCoordinate = value;
        }
     
    }

    public int YCoordinate
    {
        get
        {
            return _yCoordinate;
        }

        set
        {
            _yCoordinate = value;
        }
    }

    public Piece(int x = 0, int y = 0)
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
