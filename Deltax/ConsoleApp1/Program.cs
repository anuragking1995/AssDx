using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deltax;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeltaXRepository obj = new DeltaXRepository();
            //DateTime dt = Convert.ToDateTime("09-21-1995").Date;
            // Console.WriteLine(dt);
            Console.WriteLine(obj.AddActor("Anurag King", "09-21-1995", "Popularly known as King", "M"));
        }
    }
}
