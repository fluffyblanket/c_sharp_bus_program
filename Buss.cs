using System;
using System.Collections.Generic;
namespace Bussen
{
	class Buss
	{
		public Passagerare[] passagerareVektor;

		private int antal_passagerare;
		public int Antal_Passagerare { get { return antal_passagerare; } }

		public Buss(int inAntal_Passagerare)
		{
			antal_passagerare = inAntal_Passagerare;

			passagerareVektor = new Passagerare[Antal_Passagerare];
		}

		/// <summary>
		/// Kör de olika metoderna som finns i klassen.
		/// </summary>
		public void Run()
		{
			bool running = true;
			while (running)
			{
				int menyval = Menyval();

				switch (menyval)
				{
					case 1:
						AddPassenger();
						break;

					case 2:
						PrintBuss();
						break;

					case 3:
						PrintGender();
						break;

					case 4:
						Console.WriteLine("\nAlla passagerares " +
							"sammanlagda ålder:");
						Console.WriteLine(CalcTotalAge() + " år.");
						break;

					case 5:
						Console.WriteLine("\nPassagerarnas genomsnittliga " +
							"ålder:");
						Console.WriteLine(CalcAverageAge() + " år.");
						break;

					case 6:
						Console.WriteLine("\nDen äldsta passageraren är " +
							MaxAge() + " år gammal.");
						break;

					case 7:
						FindAge();
						break;

					case 8:
						SortBuss();
						break;

					case 9:
						bool x = true;
						int poke = 0;

						while (x)
						{
							Console.WriteLine("Vilken passagerare vill du " +
								"peta på?");

							poke = ReadInt() - 1;

							if (poke >= 0 &&
								poke <= passagerareVektor.Length - 1)
							{
								x = false;
							}
							else
							{
								Console.WriteLine("Hm, pröva igen, ange ett " +
									"heltal mellan " + (passagerareVektor.Length -
									(passagerareVektor.Length - 1)) +
									" och " + passagerareVektor.Length + ".");
							}
						}

						Passagerare.Poke(passagerareVektor[poke]);
						break;

					case 10:
						Console.WriteLine("\nVilken passagerare går av?");
						int index = ReadInt() - 1;

						GettingOff(passagerareVektor, index);

						Console.WriteLine("\nPassagerare " + (index + 1) + " har gått " +
							"av!");
						break;

					case 11:
						running = false;
						break;

					default:
						Console.WriteLine("\nDu har inte angett ett" +
							"giltigt menyval, försök igen!");
						break;
				}
			}

			Console.WriteLine("\nHejdå!");
		}

		/// <summary>
		/// Skriver ut en meny och läser in användarens menyval
		/// </summary>
		/// <returns>En int som representerar val i menyn</returns>
		static public int Menyval()
		{
			Console.WriteLine("\n" +
				"Välj från menyn:\n" +
				"1. Lägg till passagerare \n" +
				"2. Skriv ut alla passagerares åldrar \n" +
				"3. Skriv ut alla passagerares kön \n" +
				"4. Skriv ut passagerarnas sammanlagda ålder \n" +
				"5. Skriv ut passagerarnas genomsnittsålder \n" +
				"6. Skriv ut högsta åldern i bussen \n" +
				"7. Skriv ut alla med en viss ålder \n" +
				"8. Sortera passagerare efter ålder \n" +
				"9. Peta på en passagerare och se vad som händer \n" +
				"10. Låt en passagerare stiga av bussen \n" +
				"11. Avsluta programmet \n");

			int val = ReadInt();

			return val;
		}

		/// <summary>
		/// Läser in en int från användaren
		/// </summary>
		/// <returns>användarens int</returns>
		static public int ReadInt()
		{
			int number = 0;

			bool x = true;
			do
			{
				try
				{
					number = int.Parse(Console.ReadLine());
					x = false;
				}
				catch (Exception)
				{
					Console.WriteLine("Du skrev inte in ett giltigt " +
						"heltal, testa igen!\n");
				}
			} while (x);

			return number;
		}

		/// <summary>
		/// Läser in ett av tre kön 
		/// </summary>
		/// <returns>en string med ett av tre kön i lowercase</returns>
		static public string ReadGender()
		{
			string gender = null;

			bool x = true;
			do
			{
				Console.WriteLine("Ickebinär, " +
					"Man eller Kvinna:");

				gender = Console.ReadLine().ToLower();

				if (gender == "ickebinär" || gender == "kvinna" ||
					gender == "man")
				{
					x = false;
				}
				else
				{
					Console.WriteLine("\nHm, något blev fel. Skriv in " +
						"passagerarens kön.");
				}
			} while (x);

			return gender;
		}

		/// <summary>
		/// Lägger till en eller flera element i vektorn passagerare
		/// </summary>
		public void AddPassenger()
		{
			if (passagerareVektor[passagerareVektor.Length - 1] != null)
			{
				Console.WriteLine("Bussen är full, det går inte att" +
						" lägga till fler passagerare!");
			}
			else
			{
				for (int i = 0; i < passagerareVektor.Length; i++)
				{
					if (passagerareVektor[i] != null)
					{
						continue;
					}
					else
					{
						Console.WriteLine("\nSkriv in åldern på " +
						"passagerare " + (i + 1) + ":");

						int age = ReadInt();

						Console.WriteLine("\nSkriv in kön på " +
						"passagerare " + (i + 1));

						string gender = ReadGender();

						passagerareVektor[i] = new Passagerare(age, gender);

						if (i != passagerareVektor.Length - 1)
						{
							Console.WriteLine("\nVill du lägga till" +
							  " en passagerare till?\n" +
							  "Tryck 1 för ja, 2 för nej.");

							int val = ReadInt();

							if (val == 2)
							{
								break;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Skriver ut alla Age-properties i passagerareVektor
		/// </summary>
		public void PrintBuss()
		{
			Console.WriteLine("\nAlla passagerares åldrar:");

			for (int i = 0; i < passagerareVektor.Length; i++)
			{
				if (passagerareVektor[i] != null)
				{
					Console.WriteLine("Passagerare " + (i + 1) + " är " +
					passagerareVektor[i].Age + " år gammal");
				}
				else
				{
					break;
				}
			}
		}

		/// <summary>
		/// Skriver ut alla element i vektorn passagerare
		/// </summary>
		public void PrintGender()
		{
			Console.WriteLine("\nAlla passagerares kön:");

			for (int i = 0; i < passagerareVektor.Length; i++)
			{
				if (passagerareVektor[i] != null)
				{
					Console.WriteLine("Passagerare " + (i + 1) + " är " +
					passagerareVektor[i].Gender + ".");
				}
				else
				{
					break;
				}
			}
		}

		/// <summary>
		/// Räknar ut summan av alla element i vektorn passagerare
		/// </summary>
		/// <returns>En int med summan av vektorns element</returns>
		public int CalcTotalAge()
		{
			int total = 0;
			for (int i = 0; i < passagerareVektor.Length; i++)
				total += passagerareVektor[i].Age;

			return total;
		}

		/// <summary>
		/// Räknar ut genomsnittet av elementens värde i vektorn passagerare
		/// </summary>
		/// <returns>En double med genomsnittsvärde</returns>
		public double CalcAverageAge()
		{
			double summa = 0.0;

			for (int i = 0; i < passagerareVektor.Length; i++)
				summa += passagerareVektor[i].Age;

			double resultat = summa / antal_passagerare;

			return Math.Round(resultat, 2);
		}

		/// <summary>
		/// Hittar den/de element i vektorn passagerare som har högst värde
		/// </summary>
		/// <returns>En int med indexnummer för element med högst värde</returns>
		public int MaxAge()
		{
			int max = passagerareVektor.Length - 1;

			for (int i = 0; i < max; i++)
			{
				int nrLeft = max - i;

				for (int j = 0; j < nrLeft; j++)
				{
					if (passagerareVektor[j].Age > passagerareVektor[j + 1].Age)
					{
						Passagerare temp = passagerareVektor[j];
						passagerareVektor[j] = passagerareVektor[j + 1];
						passagerareVektor[j + 1] = temp;
					}
				}
			}

			return passagerareVektor[max].Age;
		}

		/// <summary>
		/// Låter användaren söka efter element i vektorn passageare
		/// med visst värde eller inom ett visst spann. 
		/// </summary>
		public void FindAge()
		{
			bool running = true;

			do
			{
				Console.WriteLine("\nVälj från menyn: " +
				"\n1. Sök efter en specifik ålder" +
				"\n2. Sök efter åldrar inom ett visst spann" +
				"\n3. Återvänd till huvudmenyn\n");

				int menyval = ReadInt();

				switch (menyval)
				{
					case 1:
						Console.WriteLine("\nSkriv in åldern du söker efter:");
						int age = ReadInt();

						bool ageFound = false;

						Console.WriteLine();

						for (int i = 0; i < passagerareVektor.Length; i++)
						{

							if (passagerareVektor[i].Age == age)
							{
								Console.WriteLine("Passagerare " +
									(i + 1) + " är " + age
									+ " år gammal.");

								ageFound = true;
							}
						}

						if (!ageFound)
						{
							Console.WriteLine("\nIngen passagerare har den " +
								"angivna åldern.");
						}
						break;

					case 2:
						Console.WriteLine("\nSkriv in den lägsta åldern " +
							"för sökningen:");
						int age1 = ReadInt();
						Console.WriteLine("\nSkriv in den högsta åldern " +
							"för sökningen:");
						int age2 = ReadInt();

						bool ageSpanFound = false;

						Console.WriteLine();

						for (int i = 0; i < passagerareVektor.Length; i++)
						{
							if (passagerareVektor[i].Age >= age1
								&& passagerareVektor[i].Age <= age2)
							{
								Console.WriteLine("Passagerare " + (i + 1) +
									" är " + passagerareVektor[i].Age
									+ " år gammal.");

								ageSpanFound = true;
							}
						}

						if (!ageSpanFound)
						{
							Console.WriteLine("\nInga passagerare befinner sig "
								+ "inom det angivna åldersspannet");
						}
						break;

					case 3:
						running = false;
						break;

					default:
						Console.WriteLine("Du skrev inte in ett giltigt" +
							" menyval, försök igen!");
						break;
				}

			} while (running);
		}

		/// <summary>
		/// Sorterar vektorn passagerare efter Age-propertiens värde
		/// och skriver ut dem
		/// </summary>
		public void SortBuss()
		{
			int max = passagerareVektor.Length - 1;

			for (int i = 0; i < max; i++)
			{
				int nrLeft = max - i;

				for (int j = 0; j < nrLeft; j++)
				{
					if (passagerareVektor[j] != null)
                    {
                        if (passagerareVektor[j + 1] == null)
                        {
							break;
                        }
                        else if (passagerareVektor[j].Age > passagerareVektor[j + 1].Age)
                        {
							Passagerare temp = passagerareVektor[j];
							passagerareVektor[j] = passagerareVektor[j + 1];
							passagerareVektor[j + 1] = temp;
						}
					}
                    else
                    {
						break;
                    }
					
				}

			}

			Console.WriteLine();

			for (int i = 0; i < passagerareVektor.Length; i++)
            {
                if (passagerareVektor[i] != null)
                {
					Console.WriteLine("Passagerare " + (i + 1) + ": "
					+ passagerareVektor[i].Age + " år gammal.");
				}
            }
				
		}

		/// <summary>
        /// Överlagring av SortBuss som tar en Passagerare-vektor som
        /// parameter och sorterar den, utan att skriva ut till anv.
        /// </summary>
        /// <param name="vektor">en Passagerare-vektor</param>
		public void SortBuss(Passagerare[] vektor)
        {
			int max = vektor.Length - 1;

			for (int i = 0; i < max; i++)
			{
				int nrLeft = max - i;

				for (int j = 0; j < nrLeft; j++)
				{
					if (vektor[j].Age > vektor[j + 1].Age)
					{
						Passagerare temp = vektor[j];
						vektor[j] = vektor[j + 1];
						vektor[j + 1] = temp;
					}
				}

			}
		}

		/// <summary>
        /// Skiss för metod som tar bort en passagerare ur vektorn och
        /// sorterar om vektorn 
        /// </summary>
		public Passagerare[] GettingOff(Passagerare[] passagerareVektor,
			int index)
        {
			passagerareVektor[index] = null;

			List<Passagerare> nullLista = new List<Passagerare>();
			List<Passagerare> ifylldLista = new List<Passagerare>();

            for (int i = 0; i < passagerareVektor.Length; i++)
            {
                if (passagerareVektor[i] != null)
                {
					ifylldLista.Add(passagerareVektor[i]);
                }
                else
                {
					nullLista.Add(passagerareVektor[i]);
                }
            }

			Passagerare[] ifylldVektor = new Passagerare[ifylldLista.Count];

            for (int i = 0; i < ifylldVektor.Length; i++)
            {
				ifylldVektor[i] = ifylldLista[i];
            }

			SortBuss(ifylldVektor);

			Passagerare[] nyPassagerareVektor =
				new Passagerare[ifylldLista.Count + nullLista.Count];

            for (int i = 0; i < (nyPassagerareVektor.Length - nullLista.Count); i++)
            {
				nyPassagerareVektor[i] = ifylldVektor[i];
            }

			return nyPassagerareVektor;
        }
	}
}
