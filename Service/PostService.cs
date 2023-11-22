public class PostService
{
    private Database _database;

    public PostService(Database database)
    {
        _database = database;
    }

    public List<Board> GetBoardList()
    {
        return _database.GetBoardList();
    }

    public Board GetBoard(int boardNo)
    {
        Board board = _database.GetBoardByNo(boardNo);
        if (board != null)
        {
            return board;
        }
        else
        {
            throw new Exception("Board not found with the provided boardNo");
        }
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
