using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Winning.Rims.WeChat.Patient;
using Winning.Rims.WeChat.Patient.RequestModel;

namespace Winning.Rims.WeChat.Controllers
{
    /// <summary>
    /// 康复微信接口-患者端
    /// </summary>
    public class PatientController : ApiController
    {
        /// <summary>
        /// 按微信标识号查询患者列表
        /// </summary>
        /// <param name="getPatientByWxId">微信标识号</param>
        /// <returns></returns>
        [HttpPost]
        public object GetPatientByWxId(GetPatientByWxId getPatientByWxId)
        {
            return new RimsInterfaceForPatient().Exec<GetPatientByWxId>(PatOpType.Pat_GetPatList, getPatientByWxId);
        }
        /// <summary>
        /// 绑定患者信息
        /// </summary>
        /// <param name="bindPatient">患者绑定信息</param>
        /// <returns></returns>
        [HttpPost]
        public object BindPatient(BindPatient bindPatient)
        {
            return new RimsInterfaceForPatient().Exec<BindPatient>(PatOpType.Pat_Bind, bindPatient);
        }
       
    }
}