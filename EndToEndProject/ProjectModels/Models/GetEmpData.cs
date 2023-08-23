using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels.Models
{
    public class GetEmpResponse
    {
        public List<GetEmpData> listEmployeeDetails { get; set; }
    }
    public class GetEmpData
    {
        public int? EmpNo { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpDomain { get; set; }
        public string EmpSalary { get; set; }
        public DateTime? EmpDOB { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ActiveFlag { get; set; }
    }
}
