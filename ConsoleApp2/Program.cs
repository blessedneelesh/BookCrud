using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            DBOperation obj = new DBOperation();
            int opt;
            Console.Write("\nHere are the options :\n");
            Console.Write("1-View Data.\n2-Insert Data.\n3-Delete Data.\n4-Update Data.\n5-Exit.\n");
            Console.Write("\nInput your choice :");
            opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    obj.ReadData();
                    break;

                case 2:
                    obj.InsertData();
                    break;

                case 3:
                    obj.DeleteData();
                    break;

                case 4:
                    obj.UpdateData();
                    break;

                case 5:
                    break;

                default:
                    Console.Write("Input correct option\n");
                    break;
            }


        }
    }
}
