using NLog;
using ProjectConfig.ServiceLayer;
using ProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EndToEndProject.Controllers
{
    public class EmpPostApiController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        [Route("empPostAPI")]
        public HttpResponseMessage Employeedata(EmpPostData empData)
        {
            HttpResponseMessage response = null;
            bool dataFlag = true;
            try
            {
                if(string.IsNullOrEmpty(empData.EmpFirstName) || empData.EmpFirstName == null || string.IsNullOrEmpty(empData.EmpLastName) || empData.EmpLastName == null || string.IsNullOrEmpty(empData.EmpDesignation)
                ||empData.EmpDesignation == null || string.IsNullOrEmpty(empData.EmpDomain)|| empData.EmpDomain == null || string.IsNullOrEmpty(empData.EmpSalary)
                || empData.EmpSalary == null || (empData.EmpDOB ==DateTime.MinValue) || empData.EmpDOB == null || string.IsNullOrEmpty(empData.ActiveFlag)|| empData.ActiveFlag == null)
                {
                    EmpDataResponse empDataResponse = new EmpDataResponse();
                    empDataResponse.Status = "Fail";
                    empDataResponse.Message = "Please enter mandatory fields";
                    response = this.Request.CreateResponse(empDataResponse);
                    dataFlag = false;
                }
                if(dataFlag)
                {
                    var empDetails = new EmpDataServiceLayer().EmployeeData(empData);
                    response = this.Request.CreateResponse(empDetails);
                    logger.Log(NLog.LogLevel.Info, "Method Executed Successfully");
                }
             
            }
            
            catch(Exception ex)
            {
                logger.Error(ex);
                var error = new Error { Status = "Fail", ErrorDescription = ex.Message };
                response = this.Request.CreateResponse(error);
            };
            return response;
        }

        [HttpGet]
        [Route("empGetAPI")]
        public HttpResponseMessage GetEmployeeData()
        {
            HttpResponseMessage response = null;
            try
            {
                var empDetails = new EmpDataServiceLayer().GetEmployeeData();
                response = this.Request.CreateResponse(empDetails);
                logger.Log(NLog.LogLevel.Info, "Method Executed Successfully");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                var error = new Error { Status = "Fail", ErrorDescription = ex.Message };
                response = this.Request.CreateResponse(HttpStatusCode.InternalServerError,error);
            }
            return response;
        }

        [HttpPut]
        [Route("empPutAPI")]
        public HttpResponseMessage UpdateEmployeedata(UpdateEmpData updateEmpData)
        {
            HttpResponseMessage response = null;
           // UpdateEmpData updateEmpData = new UpdateEmpData();
            bool dataFlag = true;
            try
            {
                if (string.IsNullOrEmpty(updateEmpData.EmpDesignation) || updateEmpData.EmpDesignation == null || string.IsNullOrEmpty(updateEmpData.EmpDomain) || updateEmpData.EmpDomain == null
                    || string.IsNullOrEmpty(updateEmpData.Empsalary) || updateEmpData.Empsalary == null)
                {
                    EmpDataResponse empDataResponse = new EmpDataResponse();
                    empDataResponse.Status = "Fail";
                    empDataResponse.Message = "Please enter mandatory feilds";
                    response = this.Request.CreateResponse(empDataResponse);
                    dataFlag = false;
                }
                if(dataFlag)
                {
                    var empDetails = new EmpDataServiceLayer().UpdateEmployeeData(updateEmpData);
                    response = this.Request.CreateResponse(empDetails);
                    logger.Log(NLog.LogLevel.Info, "Method Executed Successfully");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                var error = new Error { Status = "Fail", ErrorDescription = ex.Message };
                response = this.Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }
            return response;
        }

        [HttpDelete]
        [Route("empDeleteAPI")]

        public HttpResponseMessage DeleteEmployeeData(DeleteEmpData deleteEmpData)
        {
            HttpResponseMessage response = null;
            bool dataFlag = true;
            try
            {
                if(deleteEmpData.EmpNo==0 ||deleteEmpData.EmpNo == null)
                {
                    EmpDataResponse dataResponse = new EmpDataResponse();
                    dataResponse.Status = "Fail";
                    dataResponse.Message = "Please enter mandatory fields";
                    response = this.Request.CreateResponse(dataResponse);
                    dataFlag = false;
                }
                if(dataFlag)
                {
                    var empDetails = new EmpDataServiceLayer().DeleteEmployeeData(deleteEmpData);
                    response = this.Request.CreateResponse(empDetails);
                    logger.Log(NLog.LogLevel.Info, "Method Executed Successfully");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                var error = new Error { Status = "Fail", ErrorDescription = ex.Message };
                response = this.Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }
            return response;
        }
    }
}
