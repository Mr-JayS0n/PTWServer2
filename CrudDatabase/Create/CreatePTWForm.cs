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
            string expr = @"\""\w+\""\:\""(.*?)\""";
            //string expr = @",?\""\b\w+\"":""?[\w\s]+\b\s?\x28?\-?\w*\-?\w*\x29?""*";
            //string expr = @"\b[M]\w+";
            //string text2 = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            Console.WriteLine("The Expression: " + expr);
            Console.WriteLine("The text: " + form_Info);
            MatchCollection mc = Regex.Matches(form_Info, expr);

            string[] match = new string[64];
           //Console.WriteLine(mc[0].Value);
           // Console.WriteLine(mc[1].Value);
            Console.WriteLine(mc.Count);
            //64 Columns

            Console.WriteLine(mc[0].Value);
            string[,] array2D = new string[64,2];//[64, 2]
            
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
        public async void generatePTWForm(string newForm3)
        {
            //await ctx.Form4s.AddAsync();
            //ctx.SaveChanges();

        }
    }
}
