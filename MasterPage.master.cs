using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Tags
{
    public ObjectId _id { get; set; }
    public string name { get; set; }
    public string live { get; set; }
    public string psn { get; set; }
    public string steam { get; set; }
    public string wiiu { get; set; }
    public string games { get; set; }
    public string delKey { get; set; }
}

public static class Global
{
    static MongoClient _client;
    static string _database;
 
    public static MongoClient client
    {
        get
        {
            return new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["GamerTagDBConnectionString"].ConnectionString);
        }
    }

    public static IMongoDatabase database
    {
        get
        {
            return client.GetDatabase("gtdb");
        }
    }

}

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
