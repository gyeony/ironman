using System;
using System.Web.Services;
using System.Web.UI;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public void Click_Send()
    {
        string Name = Page.Request.Form["name"].ToString();
        string Email = Page.Request.Form["email"].ToString();
        string Phone = Page.Request.Form["phone"].ToString();
        string Message = Page.Request.Form["message"].ToString();

        RequestController myController = new RequestController();
        myController.SendMessage(Name, Email, Phone, Message);
    }
}