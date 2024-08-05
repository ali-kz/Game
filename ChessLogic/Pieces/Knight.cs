namespace ChessLogic.Pieces;

public class Knight(Player color) : Piece
{
    public override PieceType Type => PieceType.Knight;
    
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