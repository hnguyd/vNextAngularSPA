using Microsoft.AspNet.Mvc;
using System;

namespace WebAPI.Common
{
    public class Util
    {
        /// <summary>
        /// If HTTP Result 200, then enter statusMesage and null for statusCode. Otherwise, provide a statusCode
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static JsonResult GetJsonResult(string statusMessage, int? statusCode)
        {
            JsonResult jsonResult = new JsonResult(statusMessage);
            if (statusCode != null)
                jsonResult.StatusCode = statusCode;
            return jsonResult;
        }
    }
}