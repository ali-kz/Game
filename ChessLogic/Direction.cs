namespace ChessLogic;

public class Direction(int rowDelta, int columnDelta)
{
    public static readonly Direction North = new Direction(-1, 0);
    public static readonly Direction South = new Direction(1, 0);
    public static readonly Direction East = new Direction(0, 1);
    public static readonly Direction West = new Direction(0, -1);
    public static readonly Direction NorthEast = North + East;
    public static readonly Direction NorthWest = North + West;
    public static readonly Direction SouthEast = South + East;
    public static readonly Direction NSouthWest = South + West;
    public int RowDelta { get; } = rowDelta;
    public int ColumnDelta { get; } = columnDelta;

    public static Direction operator +(Direction dir1, Direction dir2)
    {
        return new Direction(dir1.RowDelta + dir2.RowDelta, dir1.ColumnDelta + dir2.ColumnDelta);
    }

    public static Direction operator *(int scalar, Direction dir)
    {
        return new Direction(scalar * dir.RowDelta, scalar * dir.ColumnDelta);
    }
}