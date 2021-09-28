using business.business.element;
using business.business.Elementos.element;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaTypes = typeof(Elemento).Assembly.GetTypes()
                                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ElementoDependente)))
                                .Select(type => type).ToList();

            foreach (var t in listaTypes)
            {
                Console.WriteLine(t.Name);
            }


            Console.WriteLine("OK");

            Console.Read();
        }
    }
}
