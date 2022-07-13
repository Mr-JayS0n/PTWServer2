using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PTWServer1.CrudDatabase.Create
{
    public class CreatePTWForm
    {
        PTWDatabaseContext ctx;

        #region
        public CreatePTWForm(PTWDatabaseContext context)
        {
            ctx = context;
        }

        #endregion
        public string[,] regexPTWForm(string form_Info)
        {
            string expr1 = @"\{\""\w+\""\:\""(.+?)\""\}"; //Capture multiple class
            string expr = @"\""\w+\""\:\""(.*?)\""";      //Capture multiple variable from a class in "JSON Format"  
            //string expr = @",?\""\b\w+\"":""?[\w\s]+\b\s?\x28?\-?\w*\-?\w*\x29?""*";
            //string expr = @"\b[M]\w+";
            //string text2 = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            Console.WriteLine("The Expression: " + expr);
            Console.WriteLine("The text: " + form_Info);
            MatchCollection mc = Regex.Matches(form_Info, expr);

            string[] match = new string[65];
           //Console.WriteLine(mc[0].Value);
           // Console.WriteLine(mc[1].Value);
            Console.WriteLine(mc.Count);
            //64 Columns

            Console.WriteLine(mc[0].Value);
            string[,] array2D = new string[65,2];//[64, 2]
            
            for (int i = 0; i < mc.Count-1 ; i++)
            {
                match[i] = mc[i].Value;
                
                Console.WriteLine("Values1: " + match[i]);
                //remove string "," by using replace string.Empty function.            
                ///match[i] = match[i].Replace(",", string.Empty).Replace("\"", string.Empty);
                match[i] = match[i].Replace("\"", string.Empty);
                Console.WriteLine("Values2: " + match[i]);
                string[] tempMatch = match[i].Split(":");

                Console.WriteLine("temporary Match 0: "+tempMatch[0]);
                Console.WriteLine("temporary Match 1: " + tempMatch[1]);

                Console.WriteLine("temporary Match Length: " + tempMatch.Length);
                                 //TODO Must change the value of 2 to tempMatch.Length-1    
                for (int a = 0; a < 2; a++)
                {
                    array2D[i, a] = tempMatch[a];
                    Console.WriteLine("Array: " + array2D[i, a]);
                }
                
            }
            return array2D;
        }
        public async void generatePTWForm(string[,] array2D)
        {
            Form5 form5 = new Form5();
            form5._1a = array2D[0, 1];  //array2D[0,1] = value; array2D[1,0] = variable name
            form5._1b = array2D[1, 1];
            form5._1c1 = array2D[2, 1];  //1c1-startDate 1c2-endDate
            form5._1c2 = array2D[3, 1];
            form5._1d = array2D[4, 1];
            form5._1e = array2D[5, 1];
            

            form5.W21 = array2D[6, 1];
            Console.WriteLine("value is : " + form5.W21);
            form5.W22 = array2D[7, 1];
            form5.W23 = array2D[8, 1];
            form5.W24a = array2D[9, 1];
            form5.W24b = array2D[10, 1];
            form5.W24c = array2D[11, 1];
            form5.W24d = array2D[12, 1];
            form5.W25 = array2D[13, 1];
            form5.W26 = array2D[14, 1];
            form5.W27 = array2D[15, 1];
            form5.W28 = array2D[16, 1];
            form5.W29 = array2D[17, 1];

            form5.C21a = array2D[18, 1];
            form5.C21b = array2D[19, 1];
            form5.C21c = array2D[20, 1];
            form5.C21d = array2D[21, 1];
            form5.C21e = array2D[22, 1];
            form5.C21f = array2D[23, 1];
            form5.C21g = array2D[24, 1];
            form5.C21h = array2D[25, 1];
            form5.C21i = array2D[26, 1];
            form5.C21j = array2D[27, 1];
            form5.C21k = array2D[28, 1];
            form5.C21l = array2D[29, 1];
            form5.C21m = array2D[30, 1];
            form5.C21n = array2D[31, 1];

            form5.C22a = array2D[32, 1];
            form5.C22b = array2D[33, 1];
            form5.C22c = array2D[34, 1];
            form5.C22d = array2D[35, 1];
            form5.C22e = array2D[36, 1];
            form5.C22f = array2D[37, 1];
            form5.C22g = array2D[38, 1];

            form5.C23a = array2D[39, 1];
            form5.C23b = array2D[40, 1];
            form5.C23c = array2D[41, 1];
            form5.C23d = array2D[42, 1];
            form5.C23e = array2D[43, 1];
            form5.C23f = array2D[44, 1];
            form5.C23g = array2D[45, 1];

            form5.C24a = array2D[46, 1];
            form5.C24b = array2D[47, 1];
            form5.C24c = array2D[48, 1];
            form5.C24d = array2D[49, 1];
            form5.C24e = array2D[50, 1];
            form5.C24f = array2D[51, 1];

            form5._3a = array2D[52, 1];
            //form5._3a = array2D[53, 1];
            form5._3b = array2D[53, 1];
            form5._3c = array2D[54, 1];
            Console.WriteLine("Form 5 3a: " + form5._3a);
            Console.WriteLine("Form 5 3b: " + form5._3b);
            Console.WriteLine("Form 5 3c: " + form5._3c);
            form5._3d = array2D[55, 1];
            form5._3e = array2D[56, 1];
            form5._3f = array2D[57, 1];
            form5._3g = array2D[58, 1];

            form5._4b = array2D[59, 1];
            form5._4c = array2D[60, 1];
            form5._4d = array2D[61, 1];
            form5._4e = array2D[62, 1];
            form5._4f = array2D[63, 1];
            form5._4g = array2D[64, 1];
            



            //Console.WriteLine("value is : "+form5.W29);

            await ctx.Form5s.AddAsync(form5);
            ctx.SaveChanges();

        }
    }
}
