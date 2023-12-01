public class BoardService
{
    private Database _database;

    public BoardService(Database database)
    {
        _database = database;
    }

    public List<Board> GetBoardList()
    {
        return _database.GetBoardList();
    }

    public Board GetBoard(int boardNo)
    {
        return _database.GetBoardByNo(boardNo);
    }

    public void CreateBoard(Board board)
    {
        _database.CreateBoard(board);
    }

    public void UpdateBoard(Board board)
    {
        _database.UpdateBoard(board);
    }

    public void DeleteBoard(int boardNo)
    {
        _database.DeleteBoard(boardNo);
    }
        
}
