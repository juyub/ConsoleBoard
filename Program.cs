using System;

class Program
{
    static void Main(string[] args)
    {
        Connection connection = new Connection();
        Database database = new Database(connection);
        PostService postService = new PostService(database);

        try
        {
            connection.OpenConnection();
            Console.WriteLine("Connected to Oracle Database");

            while (true)
            {
                postService.ViewAllPosts();

                Console.WriteLine("1. Create Post\n2. View Posts\n3. Update Post\n4. Delete Post\n5. Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Post newPost = new Post();
                        Console.Write("Enter post title: ");
                        string input = Console.ReadLine();
                        newPost.Title = input ?? string.Empty;
                        /*newPost.Title = Console.ReadLine();*/
                        Console.Write("Enter post content: ");
                        newPost.Content = Console.ReadLine();
                        postService.CreatePost(newPost);
                        Console.WriteLine("Post created successfully");
                        break;
                    case 2:
                        postService.ViewPosts();
                        break;
                    case 3:
                        Post updatedPost = new Post();
                        Console.Write("Enter post ID to update: ");
                        updatedPost.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new title: ");
                        updatedPost.Title = Console.ReadLine();
                        Console.Write("Enter new content: ");
                        updatedPost.Content = Console.ReadLine();
                        postService.UpdatePost(updatedPost);
                        Console.WriteLine("Post updated successfully");
                        break;
                    case 4:
                        Console.Write("Enter post ID to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        postService.DeletePost(deleteId);
                        Console.WriteLine("Post deleted successfully");
                        break;
                    case 5:
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
            connection.CloseConnection();
            Console.WriteLine("Connection closed");
        }
    }
}