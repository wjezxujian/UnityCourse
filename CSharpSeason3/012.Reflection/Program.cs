using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _012.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();

            Type type = my.GetType();
            Console.WriteLine(type.Name);
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.Assembly);

            FieldInfo[] fields = type.GetFields();
            foreach(FieldInfo field in fields)
            {
                Console.Write(field.Name + "    ");
            }

            Console.WriteLine();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertie in properties)
            {
                Console.Write(propertie.Name + "    ");
            }

            Console.WriteLine();

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write(method.Name + "    ");
            }


            Console.WriteLine();
            Assembly assembly = type.Assembly;
            Console.WriteLine(assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t);
            }



            Console.ReadKey();

        }
    }
}
