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
        //private readonly Object classDatabaseObj;

        //Constructors
        #region
  
        public crudDatabase(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion

        //try use partial class to split big class into small class
        #region Create/Input Data

        //C-Create New Form

        //C-Testing Template
        public async Task create(String forminfo)
        {
            Form2 newForm2 = new Form2
            {
                Id = 12,//Guid.NewGuid().ToString(),
                Age = "15"
            };

            Console.WriteLine(newForm2.Id);

            //await ctx.Form2s.AddAsync(newForm2);
            //int num =
            //ctx.SaveChanges();
            char[] trimValue = {'-','1','2','3','4','5'};
            Form3 newForm3 = new Form3
            {
                Id = "FID"+Guid.NewGuid().ToString().Replace("-",string.Empty).Remove(0,25),
                Formdate = DateTime.Now,
                FormName = forminfo,
            };

            await ctx.Form3s.AddAsync(newForm3);
            ctx.SaveChanges();
            
        }

        #endregion

        void delete()
        {

        }
        //U-Authorize/Reject Form
        void update()
        {

        }
        #region Read Data
        //R-Tracking Log

        //R-Permit Request Details

        //R-Verify Login Validator
        
        //R-Pending Requests

        //R-Testing Template
        public List<Form3>readRecord()
        {
            var form3sisNotEmpty = ctx.Form3s.SingleOrDefault();
            var formobjs = ctx.Form3s;
            List<Form3> formList = new List<Form3>(formobjs);

            if (form3sisNotEmpty != null)
            {
                foreach (var formobj in formobjs)
                {
                    Console.WriteLine(formobj.Id);
                    formList.Add(formobj);
                }
            }
            return formList;
        }
        #endregion 
    }
}
