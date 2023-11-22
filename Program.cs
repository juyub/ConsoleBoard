using System;

class Program
{

    static void Main(string[] args)
    {
        Connection connection = new Connection();
        Database database = new Database(connection);
        PostService postService = new PostService(database);
        View view = new View(postService);

        while (true)
        {
            /*connection.openConnection();
            Console.WriteLine("Connected to Oracle Database");*/

            try
            {
                view.BoardList();

                Console.WriteLine("1. Create Board\n" +
                                  "2. View Board\n" +
                                  "3. Exit\n");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                switch (option)
                {
                    case 1:
                        view.CreateBoard();
                        break;
                    case 2:
                        Console.Write("Enter BoardNo: ");
                        int boardNo = Convert.ToInt32(Console.ReadLine());
                        view.GetBoard(boardNo);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.CloseConnection();
                /*Console.WriteLine("Connection closed");*/
            }
        }
    }
}
