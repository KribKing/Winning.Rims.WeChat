using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winning.Rims.WeChat.Core;

namespace Winning.Rims.WeChat.Patient
{
    public class RimsInterfaceForPatient
    {

        public object Exec<T>(PatOpType type, T obj)
        {
            try
            {

                PatBaseExecInteraface jk = new PatBaseExecInteraface();
                switch (type)
                {
                    case PatOpType.None:
                        break;
                    case PatOpType.Pat_GetPatList:
                        break;
                    case PatOpType.Pat_Bind:
                        break;
                    default:
                        break;
                }
                return DataParserManager.ToObject(DataParserManager.ToJson(jk.Exec<T>(obj, type)));
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message,ex);
                throw;
            }

        }
    }
}
