using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winning.Rims.WeChat.Core;

namespace Winning.Rims.WeChat.Patient
{
    public class PatBaseExecInteraface
    {
        public virtual object Exec<T>(T data,PatOpType type=PatOpType.None)
        {
            if (type == PatOpType.None)
                throw new ArgumentException("操作类型为空，无法处理");
            return GlobalInstanceManager<SqlManager>.Intance.GetRimsDataTablebyProc<T>("usp_rims_wx_"+type.ToString().ToLower(), data);
        }
    }
}
