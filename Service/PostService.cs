public class PostService
{
    private Database _database;

    public PostService(Database database)
    {
        _database = database;
    }

    public void getBoardList()
    {
        var boards = _database.getBoardList();

        if (boards.Count == 0)
        {
            Console.WriteLine("There are no posts yet.");
            return;
        }

        foreach (var board in boards)
        {
            Console.WriteLine($"No: {board.boardNo}, Title: {board.title}, Content: {board.content}, RegDate: {board.regDate}");
        }
    }
    
    public Board GetBoard(int boardNo)
    {
        Board board = _database.getBoardByNo(boardNo);
        if (board != null)
        {
            return board;
        }
        else
        {
            throw new Exception("Board not found with the provided boardNo");
        }
    }

    public void createBoard(Board board)
    {
        _database.createBoard(board);
    }

    public void updatePost(Board board)
    {
        _database.updateBoard(board);
    }

    public void deletePost(int boardNo)
    {
        _database.deleteBoard(boardNo);
    }
        
}