using AgentPortal.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPortal.ClassApp
{
    public class CurrentClass
    {
        public static Employee CurrentEmployee { get; set; }
        public static Queries CurrentAdress { get; set; }
    }
}
