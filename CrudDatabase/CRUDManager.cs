using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTWServer1.CrudDatabase.Create;
using PTWServer1.CrudDatabase.Read;
using Microsoft.AspNetCore.SignalR;
using System.Threading;

namespace PTWServer1.CrudDatabase
{
    public class CRUDManager: Hub
    {
        PTWDatabaseContext ctx;
        String _readList = String.Empty;
        #region
        public CRUDManager(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion

        List<int> a = new List<int>();
        
        public async void crud_controller(string function_Name, Object data)
        {                                                           //data = form_Info, page_Number
            Console.WriteLine(function_Name);
            string[] subfunction_Name = function_Name.Split(".");   //function_Name = ReadForm.caller_read_RTL/CreateForm.receiver_create_PTWForm
            switch (subfunction_Name[0])                            //subfunction_Name[0] = CreateForm/ReadForm 
            {                                                       //subfunction_Name[1] = caller_read_RTL/receiver_craete_PTWForm
                case "CreateForm":
                    CreateForm createForm = new CreateForm(ctx);
                    createForm.receiver_create(subfunction_Name[1], data.ToString());
                    break;
                
                case "ReadForm":
                    Console.WriteLine("ReadForm");
                    ReadForm readForm = new ReadForm(ctx);
                    _readList = readForm.caller_read(subfunction_Name[1], int.Parse(data.ToString()));
                    Console.WriteLine(_readList);

                    if (_readList.Substring(0, 11) == "callread001")
                    {
                        await Clients.Caller.SendAsync("hconnection_read_RTL", _readList);
                    }
                    else if (_readList.Substring(0, 11) == "callread002")
                    {
                        //Console.WriteLine("callread002");
                        await Clients.Caller.SendAsync("hconnection_read_RTL_Details", _readList);
                    }
                    break; 
            }
        }
    }
}
