using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTWServer1.CrudDatabase.Read
{
    public class ReadPRD
    {
        private readonly PTWDatabaseContext ctx;
        #region
        public ReadPRD(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion
    }
}
