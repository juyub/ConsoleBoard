using System;
using Oracle.ManagedDataAccess.Client;

public class PostService
{
    private Database _database;

    public PostService(Database database)
    {
        _database = database;
    }

    public void ViewAllPosts()
    {
        var posts = _database.GetAllPosts();

        if (posts.Count == 0)
        {
            Console.WriteLine("There are no posts yet.");
            return;
        }

        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Content: {post.Content}");
        }
    }

    public void CreatePost(Post post)
    {
        _database.CreatePost(post);
    }

    public void UpdatePost(Post post)
    {
        _database.UpdatePost(post);
    }

    public void DeletePost(int id)
    {
        _database.DeletePost(id);
    }

    public void ViewPosts()
    {
        var posts = _database.GetAllPosts();

        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Content: {post.Content}");
        }
    }
}