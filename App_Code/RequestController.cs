
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class RequestController
{
    public RequestController()
    {
    }

    public bool SendMessage(string Name, string Email, string Phone, string Message)
    {
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.AppSettings.Get("myAzure");

        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "AddContact";

        SqlParameter namePara = new SqlParameter("@name", SqlDbType.VarChar, 50);
        namePara.Value = Name;
        myCommand.Parameters.Add(namePara);

        SqlParameter emailPara = new SqlParameter("@email", SqlDbType.VarChar, 30);
        emailPara.Value = Email;
        myCommand.Parameters.Add(emailPara);

        SqlParameter phonePara = new SqlParameter("@phone", SqlDbType.VarChar, 20);
        phonePara.Value = Phone;
        myCommand.Parameters.Add(phonePara);

        SqlParameter MessagePara = new SqlParameter("@message", SqlDbType.VarChar, 200);
        MessagePara.Value = Message;
        myCommand.Parameters.Add(MessagePara);

        myConnection.Open();

        bool confirmation = false;
        int affectedRow  = myCommand.ExecuteNonQuery();
        if(affectedRow > 0)
        {
            confirmation = true;
        }

        return confirmation;
    }
}