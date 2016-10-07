#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;
using System.Data;

namespace ESDemob
{

    [SecurityRole("Manager")]
    public class RBDemo
    {
        public RBDemo() {}

        public DataSet GetManagerData()
        {
            //implementation
            return new DataSet();
        }

        [SecurityRole("Executuve")]
        public DataSet GetExecutiveData()
        {
            //implementation
            return new DataSet();
        }
    }
}
