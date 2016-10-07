#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;

#endregion

namespace ESDemo
{
    //[JustInTimeActivation(true)]
    public class JITA : ServicedComponent
    {
        private DateTime m_CreateStamp;
        public JITA()
        {
            m_CreateStamp = DateTime.Now;
        }

        public DateTime GetCreateStamp()
        {
            //ContextUtil.DeactivateOnReturn = true;
            return m_CreateStamp;
        }
    }
}
