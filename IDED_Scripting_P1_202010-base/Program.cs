using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDED_Scripting_P1_202010_base.Logic
{
    class Program
    {
        static void Main(string[] args)
        {

            Prop cofre = new Prop(EPropType.Chest);
            Human julian = new Human( EUnitClass.Ranger , 111123, 12323123, 112312323, 1023010,9999 );
            Unit anna = new Unit(EUnitClass.Orc, 111123, 12323123, 112312323, 10001);

          Console.WriteLine( julian.Interact(anna));

            Console.WriteLine(julian.Interact(cofre));
            Console.WriteLine( julian.UnitClass);
            Console.WriteLine(julian.Attack);
            Console.WriteLine(julian.Defense);
            Console.WriteLine(julian.Speed);
            Console.WriteLine(julian.AtkRange);
            Console.WriteLine(julian.potential);
            Console.WriteLine(julian.MoveRange);
            Position mover = new Position(5, 3);
            Console.WriteLine("Posicion en x {0}, posicion en y {1}", julian.CurrentPosition.x, julian.CurrentPosition.y);
            Console.WriteLine(julian.Move(mover));
            Console.WriteLine("Posicion en x {0}, posicion en y {1}", julian.CurrentPosition.x , julian.CurrentPosition.y);

           Console.WriteLine(julian.ChangeClass(EUnitClass.Mage));



            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
