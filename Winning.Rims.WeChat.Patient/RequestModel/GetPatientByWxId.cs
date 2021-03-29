using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Patient.RequestModel
{
    /// <summary>
    /// 按微信标识号查询患者列表传参
    /// </summary>
    [DataContract]
    public class GetPatientByWxId
    {
        /// <summary>
        /// 微信标识
        /// </summary>
        [DataMember]
        public string WeChatId { get; set; }
    }
}
