using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class TimeOffRequest
    {
        public int Id { get; set; }
        public long EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
