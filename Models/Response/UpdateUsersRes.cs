using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAutomationFramework.Models.Response
{

    // I did not create a sepparate class for update request, because update request body is same with 
    //create user request. you need a class for each diff model
    public class UpdateUsersRes
    {
        public string name { get; set; }
        public string job { get; set; }
        public DateTime updatedAt { get; set; }
    }

}
