using System;

namespace Garbage_Collector
{
    class Program
    {
        static void ShortLives (Person parent)
        {
            Person fred = new Person
            {
                Name = "Fred",
                ChildOne = new Person { Name = "Bamm-Bamm"}
            };
            parent.ChildTwo = fred.ChildOne;
        }
        static void Run( )
        {
            Person wilma = new Person
            {
                Name = "Wilma",
                ChildOne = new Person { Name = "Pebbles" }
            };
            ShortLives(wilma);

            Console.WriteLine("Leaving 'ShortLives'...");

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static void Main()
        {
            Run();

            Console.WriteLine("\nLeaving  'Run'...");

            GC.Collect();// lo ideal es no hacerlo, el  GC sabe cuando es apropiado realizar una recolleción
            GC.WaitForPendingFinalizers(); // el programa terminará cuando llamen a los finalizadores 

            Console.ReadLine();
        }

        //ShortLives es usado para hacer referencia de bambam a wilma y declarar que tambien es hijo de ella
        //Una vez que bambam es asignado cómo hijo2 de Wilma se disposea la memoria que uasaba para fred
        //Una vez finalizada la coneccion entre hijos y pades
        //Disposea a BammBamm, Pebbles y Wilma
    }
}
