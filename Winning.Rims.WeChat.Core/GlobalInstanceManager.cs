using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Core
{
    public class GlobalInstanceManager<T>
    {
        private static T _intance;
        private static readonly object lockflag = new object();
        public static T Intance
        {
            get
            {
                if (_intance == null)
                {
                    lock (lockflag)
                    {
                        if (_intance == null)
                        {
                            _intance = Activator.CreateInstance<T>();
                        }
                    }                 
                }
                return _intance;
            }
        }
    }
}
