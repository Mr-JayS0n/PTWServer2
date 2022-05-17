 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTWServer1.EntityFrameworkModel
{
    public class login
    {
        string id;
        string password; 
        PTWDatabaseContext ctx;
        public login(string ID, string PW, PTWDatabaseContext context)
        {
            id = ID;
            password = PW;
            ctx = context;
        }

        public Form3 verify(login obj)
        {
            Form3 formObj = ctx.Form3s.Where(i => i.Id == obj.id  && i.FormName == obj.password).SingleOrDefault();

            if (formObj != null)
            {
                Console.WriteLine(formObj.Id);
                return formObj;
            }
            return null;

        } 
    }
}
