using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Patient.RequestModel
{

    /// <summary>
    /// 绑定患者信息
    /// </summary>
    [DataContract]
    public class BindPatient
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        [DataMember]
        public string PatName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IndentityId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
        /// <summary>
        /// 微信号标识
        /// </summary>
        [DataMember]
        public string WeChatId { get; set; }
    }
}
