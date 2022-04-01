using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTWServer1.EntityFrameworkModel; //Import namespace/module


namespace PTWServer1.EntityFrameworkModel
{
    public class crudDatabase
    {
        private readonly PTWDatabaseContext ctx;
        private readonly Object classDatabaseObj;

        //Constructors
        #region
        public crudDatabase() { }
        public crudDatabase(PTWDatabaseContext context, Object classObj)
        {
            ctx = context;
            classDatabaseObj = classObj;
        }
        public crudDatabase(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion

        async Task create(Form forminfo)
        {
            
            await ctx.Forms.AddAsync(forminfo);
            ctx.SaveChanges();
        }

        void delete()
        {

        }

        void update()
        {

        }

       public Form read(Form forminfo)
        {
            Form formObj = ctx.Forms.Where(f => f.FormName == forminfo.FormName && f.FormId == forminfo.FormId).SingleOrDefault();
            
            if(formObj != null)
            {
                return formObj;
            }
            return null;
        }


        
    }
}
