using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Winning.Rims.WeChat.Doctor;
using Winning.Rims.WeChat.Doctor.RequestModel;

namespace Winning.Rims.WeChat.Controllers
{
    /// <summary>
    /// 康复微信接口-治疗师端
    /// </summary>
    public class DoctorController : ApiController
    {
        /// <summary>
        /// 按微信标识号查询治疗师列表
        /// </summary>
        /// <param name="getDoctorByWxId">微信标识号</param>
        /// <returns></returns>
        [HttpPost]
        public object GetDoctorByWxId(GetDoctorByWxId getDoctorByWxId)
        {
            return new RimsInterfaceForDoctor().Exec<GetDoctorByWxId>(DocOpType.Doc_GetList, getDoctorByWxId);
        }
    }
}