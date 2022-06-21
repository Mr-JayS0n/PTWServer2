using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTWServer1.EntityFrameworkModel;


namespace PTWServer1.CrudDatabase.Read
{
    public class ReadRTL
    {
        private readonly PTWDatabaseContext ctx;
        #region
        public ReadRTL(PTWDatabaseContext context)
        {
            ctx = context;
        }
        #endregion

        ////findthe8id----success
        //display 8 rows data based on the page and latest data by ID

        ///TODO**Object must chg to the Form's Class in later stage
        public String findthe8id(int currentPage)
        {  //(1)Assign the latest id
           //(2)Define the Rows To Display in a Page
           //(3)Find the current id that is iterating 
           //TODO deliver the data to client
            List<Object> _8id = new List<Object>();
            Console.WriteLine("Current Page: "+currentPage);
            int rowperPage = 8;
            
            int maxPage;

            int numberofId = findlatestid();
            Console.WriteLine("Number of Id: " + numberofId);
            // 28
            int totalPage = numberofId / rowperPage; //quotient = totalNumber/rowperPage
            // 3          =     28     /     8
            Console.WriteLine("Total Page: " + totalPage);
            int remainder = numberofId % rowperPage;
            // 4          =     28     /     8
            Console.WriteLine("Remainder: " + remainder);

            String stack = String.Empty;

            int currentVal;

            int offSet = 8;

            if(remainder>0)
            {
                maxPage = totalPage + 1;
                // 4    =     3     + 1
            }
            else
            {
                maxPage = totalPage;
                // 4    =     3
            }

            if(currentPage == maxPage && remainder>0)
            {
                currentVal = remainder;
                //currentVal = Math.Abs(numberofId - (currentPage*rowperPage));
                // 4       =             28       -      4     *     8
                rowperPage = currentVal;
                Console.WriteLine("currentVal: "+currentVal);
            }
            else
            {
                currentVal = Math.Abs(numberofId - (currentPage*rowperPage) + offSet);
                // 20      =             28       -    ( 2     *     8 )    +    8
            }  

            
            
            for(int i = rowperPage; i > 0; i--)
            {
                
                var Id = ctx.Form3s.Where(i => i.Id2 == currentVal).FirstOrDefault<Form3>().Id2;

                Console.WriteLine("Id: "+Id);
                //doesn't work//var data = ctx.Form3s.Where(i=>i.Id2 == 1).ToList();
            

                var data1 = from dat in ctx.Form3s
                            where dat.Id2 == currentVal
                            select new
                            {
                                a = dat.Id2,
                                b = dat.Id,
                                c = dat.Formdate,
                                d = dat.FormName
                            };
                //IQueryable<Object> v = from dat in ctx.Form3s
                //                 where dat.Id2 == currentVal
                //                 select new
                //                 {
                //                     a = dat.Id2,
                //                     b = dat.Id,
                //                     c = dat.Formdate,
                //                     d = dat.FormName
                //                 };

                //Console.WriteLine("v:"+v);

                _8id.Add(data1);
                
                foreach(var item in data1)
                {
                    Console.WriteLine("data1"+item.ToString());
                    stack+=item.ToString();
                    stack = stack.Replace("@","@" + Environment.NewLine);
                    
                }
                
                //Console.WriteLine("hi: {0}", data1  );
               

                //foreach (var datas in data)
                //{
                //    Console.WriteLine("hihi :{0}", datas);
                //}
                ////var Id = (from a in ctx.Form3s 
                ////          where a.Id2 == currId select a).FirstOrDefault().Id2;
                ///
                //Console.WriteLine("id: "+Id);

                //foreach (var d in data3)
                //{
                //    Console.WriteLine("data: " + d);
                //}
                //Console.WriteLine("data: "+data3);
                currentVal -= 1;
            }
            Console.WriteLine("stack: " + stack);
            return stack;
        }

        

        ////findthe8id----success
        //find the lastest data by ID

        ///TODO**Object must chg to the Form's Class in later stage
        public int findlatestid()
        {
            //string findlatestidResult = "1";
            //string findlatestidResult = "0";
            int formisNotEmpty = ctx.Form3s.Count();
            

            //Console.WriteLine(formisNotEmpty);

            if (formisNotEmpty != 0)
            {
                //find the latest id
                var findlatestidResult1 = ctx.Form3s.OrderByDescending(x => x.Id2).FirstOrDefault().Id2;
                Console.WriteLine("findlatestidResult: "+findlatestidResult1);
                return findlatestidResult1;
            }
            
            return 0;
        }
    }
}
