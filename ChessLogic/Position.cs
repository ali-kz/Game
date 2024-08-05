namespace ChessLogic;

public class Position(int row, int column)
{
    public int Row { get; set; } = row;
    public int Column { get; set; } = column;

    public Player SquareColor()
    {
        return (Row + Column) % 2 == 0 ? Player.White : Player.Black;
    }

    public override bool Equals(object obj)
    {
        return obj is Position position &&
               Row == position.Row &&
               Column == position.Column;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Position left, Position right)
    {
        return EqualityComparer<Position>.Default.Equals(left, right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }

    public static Position operator +(Position pos, Direction dir)
    {
        return new Position(pos.Row + dir.RowDelta, pos.Column + dir.ColumnDelta);
    }
}