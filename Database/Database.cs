using Oracle.ManagedDataAccess.Client;
using System.Data;

public class Database
{
    private Connection connection;

    public Database(Connection connection)
    {
        this.connection = connection;
    }
    
    /*"non-query" SQL ���� �����ϸ�,
    �̴� �Ϲ������� �����͸� ��ȯ���� �ʴ� SQL ���� �ǹ��մϴ�.
    ���� ���, INSERT, UPDATE, DELETE, CREATE ���� SQL ���� ���⿡ �ش��մϴ�.
    �� �޼���� ������� ���� ���� ��ȯ*/
    public void executeNonQuery(string query)
    {
        connection.openConnection();
        OracleConnection conn = connection.getConnection();
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
            connection.closeConnection();
        }
    }

    /*"query" SQL ���� �����ϸ�,
    �̴� �����͸� ��ȯ�ϴ� SQL ���� �ǹ��մϴ�.
    ���� ���, SELECT ���� ���⿡ �ش��մϴ�.
    �� �޼���� ����� ��ȯ�� �����͸�
    DataTable ��ü�� ��� ��ȯ*/
    public DataTable executeQuery(string query)
    {
        connection.openConnection();
        OracleConnection conn = connection.getConnection();

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
            connection.closeConnection();
        }

        return dt;
    }

    public void createBoard(Board board)
    {
        string query = $"INSERT INTO c_board_test (boardNo, title, content, regDate) " +
                       $"VALUES (c_board_test_seq.NEXTVAL, '{board.title}', '{board.content}', SYSDATE)";
        executeNonQuery(query);
    }

    public List<Board> getBoardList()
    {
        string query = "SELECT * FROM c_board_test";
        DataTable dt = executeQuery(query);
        List<Board> boards = new List<Board>();
        foreach (DataRow row in dt.Rows)
        {
            boards.Add(new Board
            {
                boardNo = Convert.ToInt32(row["boardNo"]),
                title = row["title"].ToString(),
                content = row["content"].ToString(),
                regDate = Convert.ToDateTime(row["regDate"])
            });
        }
        return boards;
    }

    public Board getBoardByNo(int boardNo)
    {
        string query = $"SELECT * FROM c_board_test WHERE BoardNo = {boardNo}";
        DataTable dt = executeQuery(query);
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


    public void updateBoard(Board board)
    {
        string query = $"UPDATE c_board_test SET Title = '{board.title}', Content = '{board.content}' WHERE boardNo = {board.boardNo}";
        executeNonQuery(query);
    }

    public void deleteBoard(int boardNo)
    {
        string query = $"DELETE FROM c_board_test WHERE boardNo = {boardNo}";
        executeNonQuery(query);
    }

}
