﻿using System;
using System.Globalization;
using System.Text.Json;

namespace Notes
{
    class Program
    {

        // Skapa lista med JSON
        private static List<Inlagg> inlaggList = new List<Inlagg>(); // list of Things
        private static string filename = "ronjasguestbook.json"; // Filnamn för listan

        // Meny
        public static void DisplayMenu()
        {

            Console.WriteLine("1 - Skriv inlägg");
            Console.WriteLine("2 - Ta bort inlägg\n");
            Console.WriteLine("X - Avsluta");

            char option = Console.ReadKey(true).KeyChar; // Användare väljer alternativ, tangentknapp visas ej i konsolen, använder KeyChar för att returnera knapp


            if (option == '1')
            {
                WritePost(); // Anropa skriva inlägg
            }
            else if (option == '2')
            {
                RemovePost(); // Anropa ta bort inlägg
            }
            else if (option == 'X' || option == 'x')
            {
                Quit(); // Anropa avsluta
            }
            else
            {
                Console.WriteLine("Ogilitigt valt, försök igen.");
            }

        }

        // Skriv inlägg
        public static void WritePost()
        {
            Console.Clear(); // Rensa konsolen

            Inlagg myObj = new(); // Instansering av nytt inlägg


            // Kontrollera att namn inte är tomt
            while (true)
            {
                Console.WriteLine("Skriv ditt namn :)");
                myObj.Name = Console.ReadLine(); // Hämta namn från inmatning

                if (string.IsNullOrEmpty(myObj.Name))
                {
                    Console.WriteLine("Du måste ange ditt namn för att kunna skriva ett inlägg.");
                    Console.WriteLine("Var snäll och försök igen.");
                }
                else
                {
                    break; // Avbryt om namnet är ifyllt
                }
            }

            // Kontrollera att inlägg inte är tomt
            while (true)
            {
                Console.WriteLine("Skriv ett inlägg :)");
                myObj.Post = Console.ReadLine(); // Hämta inlägg från inmatning

                if (string.IsNullOrEmpty(myObj.Post))
                {
                    Console.WriteLine("Du måste skriva något i ditt inlägg.");
                    Console.WriteLine("Vänligen försök igen.");
                }
                else
                {
                    break; // Avbryt om inlägget är ifyllt
                }
            }

            // Lägg till inlägg i lista
            inlaggList.Add(myObj);

            // Spara som JSON
            SavePost();



            // Skriv ut inlägget som användaren skrev
            Console.WriteLine("Tack för ditt inlägg!");

            // Låt användaren trycka på knapp innan skärm rensas
            Console.WriteLine("Tryck på valfri knapp på tangentbordet för att fortsätta.");
            Console.ReadKey();
            Console.Clear(); // Rensa konsolen

            // Visa alla inlägg
            ShowAllPosts();
            // Visa menyn
            DisplayMenu();

        }

        // Visa inlägg
        public static void ShowAllPosts()
        {
            Console.WriteLine("RONJAS GÄSTBOK\n");

            // Om det inte finns några tidigare inlägg
            if (inlaggList.Count == 0)
            {
                Console.WriteLine("Det finns inga inlägg att visa ännu.\n");
            }
            else
            {
                // Annars-loopa igenom listan med inlägg och visa för användaren
                for (int i = 0; i < inlaggList.Count; i++)
                {
                    Console.WriteLine($"[{i}] {inlaggList[i].Name} - {inlaggList[i].Post}\n");
                }
            }

        }

        // Ta bort inlägg
        public static void RemovePost()
        {

            Console.Clear(); // Rensa konsolen

            // Visa alla inlägg
            ShowAllPosts();
            Console.WriteLine("Ange det nummer för inlägget du vill ta bort:");

            bool indexInput = false; // Flagga input som false först

            // While-loop för kontroll av inmatning/borttagning av inlägg
            while (!indexInput) 
            { 

                // Parsa inmatning från användare, spara i variabel index
                bool delete = int.TryParse(Console.ReadLine(), out int index);

                // Kontroll att inmatning stämmer med index i inläggslistan,
                // Om true - ta bort inlägg
                if (delete && index >= 0 && index < inlaggList.Count)
                {
                    inlaggList.RemoveAt(index);
                    SavePost();
                    Console.WriteLine("Inlägget har tagits bort.");
                    indexInput = true; // Flagga input som true
                }
                else // Om false, be användaren testa igen
                {
                    Console.WriteLine("Inlägget hittades inte, försök igen.");
                }
            }

            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();  // Ta användarinmatning
            Console.Clear();  // Rensa konsolen 

            // Visa alla inlägg
            ShowAllPosts();

            // Visa menyn
            DisplayMenu();

        }

        // Spara till JSON-fil
        public static void SavePost()
        {
            string jsonString = JsonSerializer.Serialize(inlaggList, new JsonSerializerOptions { WriteIndented = true }); // Omvandla objekt till JSONsträng och indentera
            File.WriteAllText(filename, jsonString); // Spara strängen till filen "filename" (ronjasguestbook)
        }


        // Läs in inlägg från JSON-filen
        public static void LoadGuestbook()
        {
            if (File.Exists(filename)) // Kontrollera att filen finns
            {
                string jsonString = File.ReadAllText(filename); // om den finns, läs in innehåll och lagra i jsonString-variabel
                                                                // Omvandla strängen tillbaks till en lista av objektet, använder ?? för att ge tom lista som standardvärde(om fil är tom eller ej kan deseraliseras)
                inlaggList = JsonSerializer.Deserialize<List<Inlagg>>(jsonString) ?? new List<Inlagg>();
            }
        }


        // Avsluta
        public static void Quit()
        {
            Console.Clear(); // Rensa konsolen
            Console.WriteLine("Hejdå :)");
            Environment.Exit(0); // Avsluta programmet
        }




        static void Main(string[] args)
        {

            // Läs in ev befintliga inlägg från fil
            LoadGuestbook();

            // Visa ev befintliga inlägg
            ShowAllPosts();

            // Visa menyn
            DisplayMenu();

        }
    }

}
