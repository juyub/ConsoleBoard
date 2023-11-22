using Oracle.ManagedDataAccess.Client;
using System.Data;

public class Database
{
    private Connection connection;

    public Database(Connection connection)
    {
        this.connection = connection;
    }
    
    /*"non-query" SQL 문을 실행하며,
    이는 일반적으로 데이터를 반환하지 않는 SQL 문을 의미합니다.
    예를 들어, INSERT, UPDATE, DELETE, CREATE 등의 SQL 문이 여기에 해당합니다.
    이 메서드는 영향받은 행의 수를 반환*/
    public void ExecuteNonQuery(string query)
    {
        connection.OpenConnection();
        OracleConnection conn = connection.GetConnection();
        if (conn == null)
        {
            Console.WriteLine("Error : syntex error");
            return;
        }

        try
        {
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            /*Console.WriteLine("success query");*/
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
        finally
        {
            connection.CloseConnection();
        }
    }

    /*"query" SQL 문을 실행하며,
    이는 데이터를 반환하는 SQL 문을 의미합니다.
    예를 들어, SELECT 문이 여기에 해당합니다.
    이 메서드는 결과로 반환된 데이터를
    DataTable 객체에 담아 반환*/
    public DataTable ExecuteQuery(string query)
    {
        connection.OpenConnection();
        OracleConnection conn = connection.GetConnection();

        if (conn == null)
        {
            Console.WriteLine("Error : syntex error");
            return null;
        }

        DataTable dt = new DataTable();

        try
        {
            OracleCommand cmd = new OracleCommand(query, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            /*Console.WriteLine("success query");*/
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
        finally
        {
            connection.CloseConnection();
        }

        return dt;
    }

    public void CreateBoard(Board board)
    {
        string query = $"INSERT INTO c_board_test (boardNo, title, content, regDate) " +
                       $"VALUES (c_board_test_seq.NEXTVAL, '{board.title}', '{board.content}', SYSDATE)";
        ExecuteNonQuery(query);
    }

    public List<Board> GetBoardList()
    {
        string query = "SELECT * FROM c_board_test";
        DataTable dt = ExecuteQuery(query);
        List<Board> boardList = new List<Board>();
        foreach (DataRow row in dt.Rows)
        {
            boardList.Add(new Board
            {
                boardNo = Convert.ToInt32(row["boardNo"]),
                title = row["title"].ToString(),
                content = row["content"].ToString(),
                regDate = Convert.ToDateTime(row["regDate"])
            });
        }
        return boardList;
    }

    public Board GetBoardByNo(int boardNo)
    {
        string query = $"SELECT * FROM c_board_test WHERE BoardNo = {boardNo}";
        DataTable dt = ExecuteQuery(query);
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            return new Board
            {
                boardNo = Convert.ToInt32(row["boardNo"]),
                title = row["title"].ToString(),
                content = row["content"].ToString(),
                regDate = Convert.ToDateTime(row["regDate"])
            };
        }
        else
        {
            return null;
        }
    }

    public void UpdateBoard(Board board)
    {
        string query = $"UPDATE c_board_test SET Title = '{board.title}', Content = '{board.content}' WHERE boardNo = {board.boardNo}";
        ExecuteNonQuery(query);
    }

    public void DeleteBoard(int boardNo)
    {
        string query = $"DELETE FROM c_board_test WHERE boardNo = {boardNo}";
        ExecuteNonQuery(query);
    }

}
