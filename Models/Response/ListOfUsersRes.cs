using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAutomationFramework.Models.Response
{
  

//I coppied the response data for listOfUsers in reqresin website
//I created a class and I click: edit> Paste special> Paste JSon as classes
public class ListOfUsersRes
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public Data[] data { get; set; }
    public Support support { get; set; }
}

public class Support
{
    public string url { get; set; }
    public string text { get; set; }
}

public class Data
{
    public int id { get; set; }
    public string email { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string avatar { get; set; }
}
}