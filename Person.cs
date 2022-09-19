using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    public class Person
    {
        public string Name { get; set; }
        public Person ChildOne { get; set; }
        public Person ChildTwo { get; set; }

        ~Person() //finalizador: metodo que se llama cuando un objeto del GC se recoge, se usan para rastrear
        {
            Console.WriteLine($"   Collecting {Name}.");
        }
    }
}
