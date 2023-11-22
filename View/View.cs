class View
{
    private PostService postService;

    public View(PostService postService)
    {
        this.postService = postService;
    }
    
    public void BoardList()
    {
        var boardList = postService.GetBoardList();

        if (boardList.Count == 0)
        {
            Console.WriteLine("There are no posts yet.");
            return;
        }

        foreach (var board in boardList)
        {
            Console.WriteLine($"No: {board.boardNo}, Title: {board.title}, Content: {board.content}, RegDate: {board.regDate}");
        }
        
        Console.Write("\n");
    }

    public void CreateBoard()
    {
        Board newBoard = new Board();

        Console.Write("Enter board title: ");
        newBoard.title = Console.ReadLine();

        Console.Write("Enter board content: ");
        newBoard.content = Console.ReadLine();

        postService.CreateBoard(newBoard);

        Console.WriteLine("Board created successfully\n");
    }

    public void GetBoard(int boardNo)
    {
        Board board = postService.GetBoard(boardNo);       
        Console.WriteLine($"No: {board.boardNo}, Title: {board.title}, Content: {board.content}, RegDate: {board.regDate}");
        Console.Write("\n");

        Console.WriteLine("1. UpdateBoard\n" +
                          "2. DeleteBoard\n" +
                          "3. Return\n");
        Console.Write("Select an option: ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                UpdateBoard(boardNo);
                break;
            case 2:
                DeleteBoard(boardNo);
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    public void UpdateBoard(int boardNo)
    {
        Board updatedBoard = postService.GetBoard(boardNo);

        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine();
        if (!string.IsNullOrEmpty(newTitle))
        {
            updatedBoard.title = newTitle;
        }

        Console.Write("Enter new content: ");
        string newContent = Console.ReadLine();
        if (!string.IsNullOrEmpty(newContent))
        {
            updatedBoard.content = newContent;
        }

        postService.UpdateBoard(updatedBoard);
        Console.WriteLine("Board updated successfully\n");

        GetBoard(boardNo);
    }

    public void DeleteBoard(int boardNo)
    {
        Console.Write("Are you sure? 1.Yes\t2.No : ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.Write("\n");

        switch (option)
        {
            case 1:
                postService.DeleteBoard(boardNo);
                Console.WriteLine("Board deleted successfully\n");
                break;
            default:
                GetBoard(boardNo);
                break;
        }
    }

    /*public void UpdateBoard()
    {
        postService.getBoardList();
        Console.Write("Enter board No to update: ");
        string inputBoardNo = Console.ReadLine();
        if (string.IsNullOrEmpty(inputBoardNo))
        {
            Console.Write("\n");
            return;
        }
        int boardNoToUpdate = Convert.ToInt32(inputBoardNo);
        Board updatedBoard = postService.GetBoard(boardNoToUpdate);
        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine();
        if (!string.IsNullOrEmpty(newTitle))
        {
            updatedBoard.title = newTitle;
        }
        Console.Write("Enter new content: ");
        string newContent = Console.ReadLine();
        if (!string.IsNullOrEmpty(newContent))
        {
            updatedBoard.content = newContent;
        }
        postService.updatePost(updatedBoard);
        Console.WriteLine("Board updated successfully");
    }*/

    /*public void DeleteBoard()
    {
        postService.getBoardList();
        Console.Write("Enter board No to delete: ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.Write("\n");
            return;
        }
        int deleteNo = Convert.ToInt32(input);
        postService.deletePost(deleteNo);
        Console.WriteLine("Board deleted successfully");
    }*/
}
