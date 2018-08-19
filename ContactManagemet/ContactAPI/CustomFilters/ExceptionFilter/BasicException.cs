using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ContactAPI.CustomFilters
{
    

    public class BasicException : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Check the Exception Type

            if (actionExecutedContext.Exception is System.Exception)
            {
                string responseMsg;
                if(actionExecutedContext.Exception is DbUpdateException)
                    responseMsg = "Database Server error occured. Please contact administrator.";
                else
                //The Response Message Set by the Action During Ececution
                    responseMsg = "Internal Server error occured. Please contact administrator.";

                //Define the Response Message
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(responseMsg),
                    ReasonPhrase = actionExecutedContext.Exception.Message
                };


                //Create the Error Response

                actionExecutedContext.Response = response;
            }
        }
    }
}