using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("        Task2");
            Console.WriteLine("     variable type\n");
            int a= 12;
            Int32 b= 13;
            byte c= 14;
            Byte d= 15;
            long e= 16;
            Int64 f= 17;
            char g= 'k';
            Char i= 'i';
            object k= 20;
            Object l=29;
            string o= "erer";
            String p= "sdl";
            

            Type type_a= a.GetType();
            Type type_b= b.GetType();
            Type type_c= c.GetType();
            Type type_d= d.GetType();
            Type type_e= e.GetType();
            Type type_f= f.GetType();
            Type type_g= g.GetType();
            Type type_i= i.GetType();            
            Type type_k= k.GetType();
            Type type_l= l.GetType();
            Type type_o= o.GetType();
            Type type_p= p.GetType();





            Console.WriteLine($"type_a= {type_a}, type_b= {type_b},\ntype_c= {type_c}, type_d= {type_d}\ntype_e= {type_e}, type_f= {type_f}, \ntype_g= {type_g}, type_i= {type_i}, \ntype_k= {type_k}, type_l= {type_l}, \ntype_o= {type_o}, type_p= {type_p}");
            Console.ReadKey();
        }
    }
}
