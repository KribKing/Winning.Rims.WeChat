using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winning.Rims.WeChat.Core;

namespace Winning.Rims.WeChat.Doctor
{
    public class DocBaseExecInteraface
    {
        public virtual object Exec<T>(T data,DocOpType type=DocOpType.None)
        {
            if (type == DocOpType.None)
                throw new ArgumentException("操作类型为空，无法处理");
            return GlobalInstanceManager<SqlManager>.Intance.GetRimsDataTablebyProc<T>("usp_rims_wx_" + type.ToString().ToLower(), data);
        }
    }
}
