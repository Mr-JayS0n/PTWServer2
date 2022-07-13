using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTWServer1.CrudDatabase.Create
{
    public class CreateForm
    {

        PTWDatabaseContext ctx;
        //TODO use Form4 to save data
        string[] formData;
        #region
        public CreateForm(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion


        
        public async void receiver_create(string function_Name, string form_Info)
        {
            switch(function_Name)
            {
                case "receiver_create_PTWForm":
                    Console.WriteLine("receiver_create_PTWForm");
                    CreatePTWForm createPTWForm = new CreatePTWForm(ctx);
                    Console.WriteLine("FormInfo: " + form_Info);
                    string[,] array2D = createPTWForm.regexPTWForm(form_Info);  //run regular expression for data cleansing
                    createPTWForm.generatePTWForm(array2D);                     //insert the necessary data into database
                    break;

            }
        }  
        
        
 

    }
}
