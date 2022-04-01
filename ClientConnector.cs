using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PTWServer1.EntityFrameworkModel;



namespace PTWServer1
{
    public class ClientConnector: Hub
    {
        PTWDatabaseContext ctx;
        void receivDataFrmClient() //mainly to receive for PTW Form's data
        {

        }


        
        public async void sendDataFrmServer() //!!!!!must give input parameter for client in future
        {
            
            Console.WriteLine("sendDataFrmServer()");//testing
            ////Any enquiry(input) request from enduser, code must be changed into proper structure in later stage.
            ////For Testing and Demo only
            Form demoForm = new Form();
            demoForm.FormId = 001;
            demoForm.FormName = "Jay";
            ////Perform "Read" function from crudDatabase()
            //crudDatabase crD = new crudDatabase(ctx);   //create constructor for performing CRUD(with Database Context)
            //Form formInfo = crD.read(demoForm);          //read(specificData) and store the entire Form(class) result into Form variable
            await Clients.Caller.SendAsync("responseDataFrmServer", demoForm);//send the entire Form data to client site's (receivedDataFrmServer) function
       
        }

        void clientRequestData()  //eg: client request to view homepage, recordpage
        {

        }

        void encrypt()
        {

        }

        void decrpyt()
        {

        }

        void convertJson()
        {

        }

        void convertString()
        {

        }
    }
}
