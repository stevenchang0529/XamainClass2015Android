using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L04_Async
{
    class Program
    {
         static void Main(string[] args)
        {
            Write();
            Console.ReadKey();
        }




        async
        static void Write()
        {
            Console.WriteLine("Start");
            //Test();
            await Test();
            Console.WriteLine("End");

            
        }

        static Task Test()
        {
           
          return   Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Test");
            });
        }
        
        
    }
}
