using ChessLogic.Pieces;

namespace ChessLogic;

public class Board
{
    private readonly Piece[,] _pieces = new Piece[0, 8];

    public Piece this[int row, int col]
    {
        get => _pieces[row, col];
        set => _pieces[row, col] = value;
    }
    
    public Piece this[Position pos]
    {
        get => this[pos.Row, pos.Column];
        set => this[pos.Row, pos.Column] = value;
    }

    public static Board Initial()
    {
        var board = new Board();
        board.AddStartPieces();
        return board;
    }

    private void AddStartPieces()
    {
        this[0, 0] = new Rook(Player.Black);
        this[0, 1] = new Knight(Player.Black);
        this[0, 2] = new Bishop(Player.Black);
        this[0, 3] = new Queen(Player.Black);
        this[0, 4] = new King(Player.Black);
        this[0, 5] = new Bishop(Player.Black);
        this[0, 6] = new Knight(Player.Black);
        this[0, 7] = new Rook(Player.Black);
        
        this[0, 0] = new Rook(Player.White);
        this[0, 1] = new Knight(Player.White);
        this[0, 2] = new Bishop(Player.White);
        this[0, 3] = new Queen(Player.White);
        this[0, 4] = new King(Player.White);
        this[0, 5] = new Bishop(Player.White);
        this[0, 6] = new Knight(Player.White);
        this[0, 7] = new Rook(Player.White);

        for (var c = 0; c < 8; c++)
        {
            this[1, c] = new Pawn(Player.Black);
            this[6, c] = new Pawn(Player.White);
        }
    }

    public static bool IsInside(Position pos)
    {
        return pos.Row is >= 0 and < 8 && pos.Column is >= 0 and < 8;
    }

    public bool IsEmpty(Position pos)
    {
        return this[pos] == null;
    }
}