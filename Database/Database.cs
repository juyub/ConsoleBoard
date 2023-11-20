using Oracle.ManagedDataAccess.Client;
using System.Data;

public class Database
{
    private Connection connection;

    public Database(Connection connection)
    {
        this.connection = connection;
    }

    public void CreatePost(Post post)
    {
        string query = $"INSERT INTO c_board_test (Id, Title, Content, DateCreated) " +
                       $"VALUES (c_board_test_seq.NEXTVAL, '{post.Title}', '{post.Content}', TO_DATE('{DateTime.Now.ToString("dd-MMM-yy")}', 'dd-MON-yy'))";
        ExecuteNonQuery(query);
    }

    public List<Post> GetAllPosts()
    {
        string query = "SELECT * FROM c_board_test";
        DataTable dt = ExecuteQuery(query);
        List<Post> posts = new List<Post>();
        foreach (DataRow row in dt.Rows)
        {
            posts.Add(new Post
            {
                Id = Convert.ToInt32(row["Id"]),
                Title = row["Title"].ToString(),
                Content = row["Content"].ToString(),
                DateCreated = Convert.ToDateTime(row["DateCreated"])
            });
        }
        return posts;
    }

    public void UpdatePost(Post post)
    {
        string query = $"UPDATE c_board_test SET Title = '{post.Title}', Content = '{post.Content}' WHERE Id = {post.Id}";
        ExecuteNonQuery(query);
    }

    public void DeletePost(int id)
    {
        string query = $"DELETE FROM c_board_test WHERE Id = {id}";
        ExecuteNonQuery(query);
    }

    private void ExecuteNonQuery(string query)
    {
        connection.OpenConnection();
        OracleCommand cmd = new OracleCommand(query, connection.GetConnection());
        cmd.ExecuteNonQuery();
        connection.CloseConnection();
    }

    private DataTable ExecuteQuery(string query)
    {
        connection.OpenConnection();
        OracleCommand cmd = new OracleCommand(query, connection.GetConnection());
        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.CloseConnection();
        return dt;
    }
}
