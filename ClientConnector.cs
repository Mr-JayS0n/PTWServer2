using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PTWServer1.EntityFrameworkModel;
using System.Text.RegularExpressions;
using Newtonsoft.Json;




namespace PTWServer1
{
    public class ClientConnector: Hub
    {
        PTWDatabaseContext ctx;

        public ClientConnector(PTWDatabaseContext context)
        {
            ctx = context;
        }
        void receivDataFrmClient() //mainly to receive for PTW Form's data
        {

        }
        //receive data from client
        //convert data to string
        //clean data to escape unnecessary string
        //store in sql
        public async Task receiveDataFrmClient(Object formInfo)
        {
            Console.WriteLine(formInfo);
            ClientConnector obj = new ClientConnector(ctx);
            string[,] formData = obj.dataToString(formInfo).showMatch(formInfo.ToString());
            //formData[0,0] = SelectedPermitType   
            //        [1,0] = isWorkAtHeight
            //        [2,0] = isWorkAtHeight
            Console.WriteLine("formvalue: " + formData[0,1]);
            crudDatabase crud = new crudDatabase(ctx);
            //crud.readRecord();
            //temp comment(workable code)
            await crud.create(formData[0,1]);
            Console.WriteLine("testing");
        }
        ///--------------------------Move this code to new class
        public async Task loginUser(/*need to put parameter eg: string ID, string PW*/)
        {
            login logAcc = new login("FID0283658", "WorkAtHeight", ctx);
            logAcc.verify(logAcc); 
        }

        ///--------------------------Move this code to new class
        //https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
        Form ConvertToFormInfoType(Object obj)
        {
            Form formInfo = JsonConvert.DeserializeObject<Form>(JsonConvert.SerializeObject(obj));
            return formInfo;
        }

        //public ClientConnector regularExpression(Object formInfo)
        //{
        //    string rExpression =  @",?\""\b\w+\"":""?[\w\s]+\b\s?\x28 ?\-?\w*\-?\w*\x29 ?""*";
        //    return this;
        //}

        ///--------------------------Move this code to new class
        public ClientConnector dataToString(Object formInfo)
        {
            string _formInfo = formInfo.ToString();
            return this;
        }

        ///--------------------------Move this code to new class
        string[,] showMatch(string text)
        {
            string expr = @",?\""\b\w+\"":""?[\w\s]+\b\s?\x28?\-?\w*\-?\w*\x29?""*";
            //string expr = @"\b[M]\w+";
            //string text2 = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            Console.WriteLine("The Expression: " + expr);
            Console.WriteLine("The text: "+text);
            MatchCollection mc = Regex.Matches(text, expr);

            string[] match = new string[15];
            Console.WriteLine(mc[0].Value);
            Console.WriteLine(mc[1].Value);
            Console.WriteLine(mc.Count);

            string[,] array2D = new string[15, 2];

            for (int i = 0; i < mc.Count - 1; i++)
            {
                match[i] = mc[i].Value;
                //remove string "," by using replace string.Empty function.            
                match[i] = match[i].Replace(",", string.Empty).Replace("\"",string.Empty);
                Console.WriteLine("Values: " + match[i]);
                string[] tempMatch = match[i].Split(":");
                
                for (int a = 0; a < tempMatch.Length; a++)
                { 
                    array2D[i, a] = tempMatch[a];
                    Console.WriteLine("Array: " + array2D[i, a]);
                }
            }
            
            return array2D;
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
