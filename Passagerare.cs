// Jag skickar med detta också, även om det inte används.
// Började skissa för jag tyckte det var kul, men kom inte så långt.

using System;
namespace Bussen
{
    public class Passagerare
    {
        /// <summary>
        /// Konstruktor för att skapa objekt av klassen Passagerare
        /// </summary>
        /// <param name="inAge"></param>
        /// <param name="inGender"></param>
        public Passagerare(int inAge, string inGender)
        {
            age = inAge;
            gender = inGender;
        }

        private int age;
        public int Age { get { return age; } }

        private string gender;
        public string Gender { get { return gender; } }

        /// <summary>
        /// Petar på passagerare och skriver ut en reaktion
        /// beroende på passagerares ålder & kön
        /// </summary>
        /// <param name="passagerare"></param>
        public static void Poke(Passagerare passagerare)
        {
            switch (passagerare.gender)
            {
                case "kvinna":
                    if (passagerare.Age <= 25)
                    {
                        Console.WriteLine("- Hej!");
                    }
                    else if (passagerare.Age >= 26 && passagerare.Age <= 50 )
                    {
                        Console.WriteLine("- Vill du ha tuggummi?");
                    }
                    else if (passagerare.Age >= 51 && passagerare.Age <= 75)
                    {
                        Console.WriteLine("- Zzzzzzz");
                    }
                    else if (passagerare.Age >= 76 && passagerare.Age <= 100)
                    {
                        Console.WriteLine("- Ursäkta vad sa du?");
                    }
                    else
                    {
                        Console.WriteLine("- Jag är jävligt gammal!");
                    }
                    break;

                case "man":
                    if (passagerare.Age <= 25)
                    {
                        Console.WriteLine("- Har du en iPhone-laddare?");
                    }
                    else if (passagerare.Age >= 26 && passagerare.Age <= 50)
                    {
                        Console.WriteLine("- Vilka snygga skor du har!");
                    }
                    else if (passagerare.Age >= 51 && passagerare.Age <= 75)
                    {
                        Console.WriteLine("- Ska jag flytta väskan?");
                    }
                    else if (passagerare.Age >= 76 && passagerare.Age <= 100)
                    {
                        Console.WriteLine("- Ursäkta?");
                    }
                    else
                    {
                        Console.WriteLine("- Huff huff huff");
                    }
                    break;

                case "ickebinär":
                    if (passagerare.Age <= 25)
                    {
                        Console.WriteLine("- Vad heter du?");
                    }
                    else if (passagerare.Age >= 26 && passagerare.Age <= 50)
                    {
                        Console.WriteLine("- Kolla vilken fin pin jag har!");
                    }
                    else if (passagerare.Age >= 51 && passagerare.Age <= 75)
                    {
                        Console.WriteLine("- Vill du ha en macka?");
                    }
                    else if (passagerare.Age >= 76 && passagerare.Age <= 100)
                    {
                        Console.WriteLine("- Vad tycker du om Beatles?");
                    }
                    else
                    {
                        Console.WriteLine("Rock n roll baby");
                    }
                    break;

                default:
                    Console.WriteLine("Oj, nåt blev fel - undrar vad som hände");
                    break;
            }
        }
    }
}
