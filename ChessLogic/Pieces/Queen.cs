namespace ChessLogic.Pieces;

public class Queen(Player color) : Piece
{
    public override PieceType Type => PieceType.Queen;
    
    public override Player Color { get; } = color;

    public override Piece Copy()
    {
        var copy = new Pawn(Color)
        {
            HasMoved = HasMoved
        };
        return copy;
    }
}