using System;
namespace Bussen
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hej och välkommen till Bussen! \n" +
				"Skapa din buss genom att skriva in hur många platser " +
				"din buss har:");

			int input = 0;
			bool running = true;
			do
			{
				try
				{
					input = int.Parse(Console.ReadLine());
					running = false;
				}
				catch (Exception)
				{
					Console.WriteLine("Du skrev inte in ett giltigt " +
						"heltal, testa igen!");
				}
			} while (running);

			//Skapar ett objekt av typen Buss som heter minbuss
			Buss minbuss = new Buss(input);

			// Kör metoden Run
			minbuss.Run();

			// Väntar på knapptryck för att avsluta
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}