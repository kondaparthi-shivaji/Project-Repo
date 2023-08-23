using ProjectConfig.RepositoryLayer;
using ProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConfig.ServiceLayer
{
   public class EmpDataServiceLayer
    {
        public EmpDataResponse EmployeeData(EmpPostData empPostData)
        {
            try
            {
                return new EmpDataRepositoryLayer().EmployeeData(empPostData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public GetEmpResponse GetEmployeeData()
        {
            try
            {
                return new EmpDataRepositoryLayer().GetEmployeeData();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public EmpDataResponse UpdateEmployeeData(UpdateEmpData updateEmpData)
        {
            try
            {
                return new EmpDataRepositoryLayer().UpdateEmployeeData(updateEmpData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public EmpDataResponse DeleteEmployeeData(DeleteEmpData deleteEmpData)
        {
            try
            {
                return new EmpDataRepositoryLayer().DeleteEmployeeData(deleteEmpData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
