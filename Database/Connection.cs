using Oracle.ManagedDataAccess.Client;

public class Connection
{
	private OracleConnection conn;
	private string strCon
        = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))
		              (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE))); User Id=c##hr2; Password=1234;";
    public OracleConnection GetConnection()
    {
        return conn;
    }
    public void OpenConnection()
    {
        try
        {
            if (conn == null)
            {
                conn = new OracleConnection(strCon);
            }
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : The Database Connected is fail..." + e.Message);
        }
    }

   public void CloseConnection()
    {
        if (conn != null)
        {
            conn.Close();
        }
    }
}