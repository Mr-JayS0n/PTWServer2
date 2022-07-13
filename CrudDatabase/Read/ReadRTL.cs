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
                Console.WriteLine("currentVal1: "+currentVal);
            }
            else
            {
                currentVal = Math.Abs(numberofId - (currentPage*rowperPage) + offSet);
                // 20      =             28       -    ( 2     *     8 )    +    8
                Console.WriteLine("currentVal2: " + currentVal);
            }  

            
            
            for(int i = rowperPage; i > 0; i--)
            {
                Console.WriteLine("currentValLoop: " + currentVal);
                var Id = ctx.Form5s.Where(i => i.Id == currentVal).FirstOrDefault<Form5>().Id;

                Console.WriteLine("Id: "+Id);
                //doesn't work//var data = ctx.Form3s.Where(i=>i.Id2 == 1).ToList();


                var data1 = from dat in ctx.Form5s
                            where dat.Id == currentVal
                            select new
                            {
                                Id = dat.Id,
                                _1a = dat._1a,
                                _1b = dat._1b,
                                _1c1 = dat._1c1,
                                _1c2 = dat._1c2,
                                _1d = dat._1d,
                                _1e = dat._1e,
                                w21 = dat.W21,
                                w22 = dat.W22,
                                w23 = dat.W23,
                                w24a = dat.W24a,
                                w24b = dat.W24b,
                                w24c = dat.W24c,
                                w24d = dat.W24d,
                                w25 = dat.W25,
                                w26 = dat.W26,
                                w27 = dat.W27,
                                w28 = dat.W28,
                                w29 = dat.W29,

                                c21a = dat.C21a,
                                c21b = dat.C21b,
                                c21c = dat.C21c,
                                c21d = dat.C21d,
                                c21e = dat.C21e,
                                c21f = dat.C21f,
                                c21g = dat.C21g,
                                c21h = dat.C21h,
                                c21i = dat.C21i,
                                c21j = dat.C21j,
                                c21k = dat.C21k,
                                c21l = dat.C21l,
                                c21m = dat.C21m,
                                c21n = dat.C21n,

                                c22a = dat.C22a,
                                c22b = dat.C22b,
                                c22c = dat.C22c,
                                c22d = dat.C22d,
                                c22e = dat.C22e,
                                c22f = dat.C22f,
                                c22g = dat.C22g,

                                c23a = dat.C23a,
                                c23b = dat.C23b,
                                c23c = dat.C23c,
                                c23d = dat.C23d,
                                c23e = dat.C23e,
                                c23f = dat.C23f,
                                c23g = dat.C23g,

                                c24a = dat.C24a,
                                c24b = dat.C24b,
                                c24c = dat.C24c,
                                c24d = dat.C24d,
                                c24e = dat.C24e,
                                c24f = dat.C24f,

                                _3a = dat._3a,
                                _3b = dat._3b,
                                _3c = dat._3c,
                                _3d = dat._3d,
                                _3e = dat._3e,
                                _3f = dat._3f,
                                _3g = dat._3g,

                                _4a = dat._4a,
                                _4b = dat._4b,
                                _4c = dat._4c,
                                _4d = dat._4d,
                                _4e = dat._4e,
                                _4f = dat._4f,
                                _4g = dat._4g,

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
            int formisNotEmpty = ctx.Form5s.Count();
            

            //Console.WriteLine(formisNotEmpty);

            if (formisNotEmpty != 0)
            {
                //find the latest id
                var findlatestidResult1 = ctx.Form5s.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                Console.WriteLine("findlatestidResult: "+findlatestidResult1);
                return findlatestidResult1;
            } 
            return 0;
        }

        public String returnSpecificId(int reqId)
        {
            String stack = String.Empty;

            Console.WriteLine("current reqId: " + reqId);
            var Id = ctx.Form5s.Where(i => i.Id == reqId).FirstOrDefault<Form5>().Id;

            Console.WriteLine("Id: " + Id);


            var data1 = from dat in ctx.Form5s
                        where dat.Id == Id
                        select new
                        {
                            Id = dat.Id,
                            _1a = dat._1a,
                            _1b = dat._1b,
                            _1c1 = dat._1c1,
                            _1c2 = dat._1c2,
                            _1d = dat._1d,
                            _1e = dat._1e,
                            w21 = dat.W21,
                            w22 = dat.W22,
                            w23 = dat.W23,
                            w24a = dat.W24a,
                            w24b = dat.W24b,
                            w24c = dat.W24c,
                            w24d = dat.W24d,
                            w25 = dat.W25,
                            w26 = dat.W26,
                            w27 = dat.W27,
                            w28 = dat.W28,
                            w29 = dat.W29,

                            c21a = dat.C21a,
                            c21b = dat.C21b,
                            c21c = dat.C21c,
                            c21d = dat.C21d,
                            c21e = dat.C21e,
                            c21f = dat.C21f,
                            c21g = dat.C21g,
                            c21h = dat.C21h,
                            c21i = dat.C21i,
                            c21j = dat.C21j,
                            c21k = dat.C21k,
                            c21l = dat.C21l,
                            c21m = dat.C21m,
                            c21n = dat.C21n,

                            c22a = dat.C22a,
                            c22b = dat.C22b,
                            c22c = dat.C22c,
                            c22d = dat.C22d,
                            c22e = dat.C22e,
                            c22f = dat.C22f,
                            c22g = dat.C22g,

                            c23a = dat.C23a,
                            c23b = dat.C23b,
                            c23c = dat.C23c,
                            c23d = dat.C23d,
                            c23e = dat.C23e,
                            c23f = dat.C23f,
                            c23g = dat.C23g,

                            c24a = dat.C24a,
                            c24b = dat.C24b,
                            c24c = dat.C24c,
                            c24d = dat.C24d,
                            c24e = dat.C24e,
                            c24f = dat.C24f,

                            _3a = dat._3a,
                            _3b = dat._3b,
                            _3c = dat._3c,
                            _3d = dat._3d,
                            _3e = dat._3e,
                            _3f = dat._3f,
                            _3g = dat._3g,

                            _4a = dat._4a,
                            _4b = dat._4b,
                            _4c = dat._4c,
                            _4d = dat._4d,
                            _4e = dat._4e,
                            _4f = dat._4f,
                            _4g = dat._4g,
                        };

            foreach (var item in data1)
            {
                //Console.WriteLine("data1" + item.ToString());
                stack += item.ToString();
                stack = stack.Replace("@", "@" + Environment.NewLine);

            }

            return stack;
            //return stack;  
        }
    }
}
