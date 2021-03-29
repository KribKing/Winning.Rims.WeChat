using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winning.Rims.WeChat.Core;

namespace Winning.Rims.WeChat.Doctor
{
    public class RimsInterfaceForDoctor
    {
        public object Exec<T>(DocOpType type, T obj)
        {
            try
            {
                DocBaseExecInteraface jk = new DocBaseExecInteraface();
                return DataParserManager.ToObject(DataParserManager.ToJson(jk.Exec<T>(obj, type)));
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
