using System;

class Program
{
    static void Main(string[] args)
    {
        Connection connection = new Connection();
        Database database = new Database(connection);
        PostService postService = new PostService(database);
        Controller controller = new Controller(postService);

        try
        {
            /*connection.openConnection();
            Console.WriteLine("Connected to Oracle Database");*/

            while (true)
            {
                controller.BoardList();

                Console.WriteLine("1. Create Board\n" +
                                  "2. View Board\n" +
                                  "3. Exit\n");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                switch (option)
                {
                    case 1:
                        controller.CreateBoard();
                        break;
                    case 2:
                        Console.Write("Enter BoardNo: ");
                        int boardNo = Convert.ToInt32(Console.ReadLine());
                        controller.GetBoard(boardNo);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            connection.closeConnection();
            Console.WriteLine("Connection closed");
        }
    }
}
