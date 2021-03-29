using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Doctor.RequestModel
{
    /// <summary>
    /// 获取治疗师信息传参
    /// </summary>
    [DataContract]
    public class GetDoctorByWxId
    {
        /// <summary>
        /// 微信标识
        /// </summary>
        [DataMember]
        public string WeChatId { get; set; }
    }
}
