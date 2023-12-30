using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAutomationFramework.Models.Request
{
 // In this class I copy data as json and I paste as class(edit>special paste> paste JSon as classes) 
    public class CreateUserReq
    {
        public string name { get; set; }
        public string job { get; set; }
    }

}
