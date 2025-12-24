using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Helper
{
    public class UserSession
    {
        public int UserId { get; set; }
        public long EmployeeId { get; set; } 
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
    }
}
