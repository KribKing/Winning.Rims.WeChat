using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Winning.Rims.WeChat.Patient;

namespace Winning.Rims.WeChat.Controllers
{
    /// <summary>
    /// 康复微信接口-初入接口
    /// </summary>
    public class RimsWeChatController : ApiController
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
    }
}
