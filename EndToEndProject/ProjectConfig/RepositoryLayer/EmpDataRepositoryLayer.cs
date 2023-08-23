using ProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConfig.RepositoryLayer
{
   public class EmpDataRepositoryLayer
    {
        public EmpDataResponse EmployeeData(EmpPostData empPostData)
        {
            EmpDataResponse empDataResponse = new EmpDataResponse();
            using(DataBaseManager dataBaseManager = new DataBaseManager())
            {
                using(SqlTransaction transaction = dataBaseManager.sqlConnection.BeginTransaction("EmployeeData"))
                {
                    dataBaseManager.sqlCommand = new SqlCommand("[dbo].[SP_PostEmployeeData]", dataBaseManager.sqlConnection, transaction);
                    dataBaseManager.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpFirstName", SqlDbType.VarChar).Value = empPostData.EmpFirstName;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpLastName", SqlDbType.VarChar).Value = empPostData.EmpLastName;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpDesignation", SqlDbType.VarChar).Value = empPostData.EmpDesignation;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpDomain", SqlDbType.VarChar).Value = empPostData.EmpDomain;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpSalary", SqlDbType.VarChar).Value = empPostData.EmpSalary;
                    dataBaseManager.sqlCommand.Parameters.Add("@EmpDOB", SqlDbType.DateTime).Value = empPostData.EmpDOB;
                    dataBaseManager.sqlCommand.Parameters.Add("@ActiveFlag", SqlDbType.VarChar).Value = empPostData.ActiveFlag;
                    int result = dataBaseManager.sqlCommand.ExecuteNonQuery();
                    if(result >0)
                    {
                        transaction.Commit();
                        empDataResponse.Status = "Success";
                        empDataResponse.Message = "data Inserted successfully";
                    }
                    else
                    {
                        throw new Exception("Enter correct input");
                    }
                    return empDataResponse;
                }
            }
        }
        
        public GetEmpResponse GetEmployeeData()
        {
            GetEmpResponse getEmpResponse = new GetEmpResponse();
            List<GetEmpData> lstDetails = new List<GetEmpData>();
            GetEmpData getEmpData = new GetEmpData();
            using(DataBaseManager dataBaseManager = new DataBaseManager())
            {
                dataBaseManager.sqlCommand = new SqlCommand("SP_GetEmployeeDetails", dataBaseManager.sqlConnection);
                dataBaseManager.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader sqlDataReader = dataBaseManager.sqlCommand.ExecuteReader())
                {
                    if(sqlDataReader.HasRows)
                    {
                        while(sqlDataReader.Read())
                        {
                            getEmpData = new GetEmpData()
                            {
                                EmpNo = sqlDataReader.IsDBNull(0) ? (int?)null : sqlDataReader.GetInt32(0),
                                EmpFirstName = sqlDataReader.IsDBNull(1) ? string.Empty : sqlDataReader.GetString(1),
                                EmpLastName = sqlDataReader.IsDBNull(2) ? string.Empty : sqlDataReader.GetString(2),
                                EmpDesignation = sqlDataReader.IsDBNull(3) ? string.Empty :sqlDataReader.GetString(3),
                                EmpDomain = sqlDataReader.IsDBNull(4) ? string.Empty : sqlDataReader.GetString(4),
                                EmpSalary = sqlDataReader.IsDBNull(5) ? string.Empty : sqlDataReader.GetString(5),
                                EmpDOB = sqlDataReader.IsDBNull(6) ? (DateTime?)null : sqlDataReader.GetDateTime(6),
                                CreatedDate = sqlDataReader.IsDBNull(7) ? (DateTime?)null : sqlDataReader.GetDateTime(6),
                                ActiveFlag = sqlDataReader.IsDBNull(8) ? string.Empty : sqlDataReader.GetString(8),
                            };
                            lstDetails.Add(getEmpData);
                        }
                        getEmpResponse.listEmployeeDetails = lstDetails.ToList();
                       
                    }
                    return getEmpResponse;
                }
            }
        }

        public EmpDataResponse UpdateEmployeeData(UpdateEmpData updateEmpData)
        {
            EmpDataResponse response = new EmpDataResponse();
          //  UpdateEmpData updateEmpData = new UpdateEmpData();
            using (DataBaseManager dataBasemanager = new DataBaseManager())
            {
                
                //dataBasemanager.sqlCommand.Parameters.AddWithValue("@EmpNo", updateEmpData.EmpNo);
                using (SqlTransaction transaction = dataBasemanager.sqlConnection.BeginTransaction("UpdateEmployeeData"))
                {
                    try
                    {
                        dataBasemanager.sqlCommand = new SqlCommand("SP_UpdateEmployeedetails", dataBasemanager.sqlConnection,transaction);
                        dataBasemanager.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        dataBasemanager.sqlCommand.Parameters.Add("@EmpNo", SqlDbType.Int).Value = updateEmpData.EmpNo;
                        dataBasemanager.sqlCommand.Parameters.Add("@EmpDesignation", SqlDbType.VarChar).Value = updateEmpData.EmpDesignation;
                        dataBasemanager.sqlCommand.Parameters.Add("@EmpDomain", SqlDbType.VarChar).Value = updateEmpData.EmpDomain;
                        dataBasemanager.sqlCommand.Parameters.Add("@EmpSalary", SqlDbType.VarChar).Value = updateEmpData.Empsalary;
                        int result = dataBasemanager.sqlCommand.ExecuteNonQuery();
                        if(result >0)
                        {
                            transaction.Commit();
                            response.Status = "Success";
                            response.Message = "Data updated successfully";
                        }
                        else
                        {
                            throw new Exception("Please enter valid Employee Number");
                        }
                        return response;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public EmpDataResponse DeleteEmployeeData(DeleteEmpData deleteEmpData)
        {
            EmpDataResponse dataResponse = new EmpDataResponse();
            using(DataBaseManager dataBaseManager = new DataBaseManager())
            {
                using(SqlTransaction transaction = dataBaseManager.sqlConnection.BeginTransaction("DeleteEmployeeData"))
                {
                    try
                    {
                        dataBaseManager.sqlCommand = new SqlCommand("SP_DeleteEmployeeData", dataBaseManager.sqlConnection, transaction);
                        dataBaseManager.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        dataBaseManager.sqlCommand.Parameters.Add("@EmpNo", SqlDbType.VarChar).Value = deleteEmpData.EmpNo;
                        dataBaseManager.sqlCommand.ExecuteNonQuery();
                        int result = dataBaseManager.sqlCommand.ExecuteNonQuery();
                        if (result == -1)
                        {
                            throw new Exception("Please enter valid userId");
                        }
                        transaction.Commit();
                        dataResponse.Status = "Success";
                        dataResponse.Message = "Data removed succesfully";
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    return dataResponse;
                }
            }
        }
    }
}
