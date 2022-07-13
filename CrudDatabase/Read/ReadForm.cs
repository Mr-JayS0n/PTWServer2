using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PTWServer1.CrudDatabase.Read; //not required because are under same module

namespace PTWServer1.CrudDatabase.Read
{
    public class ReadForm: Hub
    {
        private readonly PTWDatabaseContext ctx;
        ReadRTL readRTL;
        ReadPRD readPRD;


        public ReadForm(PTWDatabaseContext context)
        {
            ctx = context;
        }

        //Client Code reference
        //this.signalrhubservice?.hubConnection.invoke("caller_read", function_Name, page_Number)
        public String caller_read(string function_Name, int page_Number)
        {
            switch(function_Name)
            {
                case "caller_read_RTL": //run called_Read_RTL Function
                    Console.WriteLine("caller_read_RTL");
                    readRTL = new ReadRTL(ctx);
                    String _find8id = readRTL.findthe8id(page_Number);
                    return "callread001" + _find8id;

                case "caller_read_RTL_Details":
                    readRTL = new ReadRTL(ctx);
                    Console.WriteLine("caller_read_RTL_Details");
                    int reqId = page_Number;
                    String _specificId = readRTL.returnSpecificId(reqId);
                    return "callread002"+_specificId;

                case "caller_read_PRD": //run called_Read_PDR Function
                    Console.WriteLine("caller_read_PRD");
                    readPRD = new ReadPRD(ctx);
                    return null;
            }
            return null;
        } 
    }
}
