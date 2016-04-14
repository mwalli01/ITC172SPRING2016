using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// this class will connect to the database with methods to retrieve services
/// it will also retrieve all the grants for that service 
/// </summary>
public class DataClass
{
    SqlConnection connect;
    public DataClass()
    {
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ToString());
    }

    public DataTable GetServices()
    {
        DataTable tbl = null;
        tbl = new DataTable();
        string sql = "Select GrantTypeKey, GrantTypeName from GrantType";
        SqlCommand cmd = new SqlCommand(sql, connect);
        tbl = ProcessConnection(cmd);
        return tbl;
    }

    public DataTable GetGrants(int grantTypeKey)
    {
        DataTable tbl = null;
        
        string sql = "Select GrantRequestDate, GrantRequestExplanation, GrantRequestAmount from GrantRequest from GrantRequest Where GrantTypeKey=@Key";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@Key", grantTypeKey);
        
        tbl = ProcessConnection(cmd);
        return tbl;
    }
    
    private DataTable ProcessConnection(SqlCommand cmd)
    {
        DataTable tbl = new DataTable();
        SqlDataReader reader = null;

        connect.Open();

        reader = cmd.ExecuteReader();
        tbl.Load(reader);
        reader.Close();
        connect.Close();

        return tbl;
    }
}
