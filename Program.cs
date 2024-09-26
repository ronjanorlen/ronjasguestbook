using System;
// Enklare menysystem:
// Kunna lägga till inlägg - ägare + inlägg, ej tomma fält

// Kunna ta bort inlägg - ta bort efter valt index

// Visa alla poster - ska visa vem som skrev och vad hen skrev

// Inlägg ska serialiseras/deserialiseras samt sparas på fil antingen
// binärt eller som json så att tidigare inmatad data finns lagrad

// felhantering så att inmatningsfält inte är tomma

// efer varje genomfört menyval ska skärmen skrivas om genom att rensa
// konsolen och sen skriver om den. Console.Clear
namespace Notes
{
    class Program
    {

        // Meny
        public static void DisplayMenu() {
        
        Console.WriteLine("1 - Skriv inlägg");
        Console.WriteLine("2 - Ta bort inlägg");
        Console.WriteLine("X - Avsluta");

        char option = Console.ReadKey(true).KeyChar;

        if (option == '1')
        {
            WritePost();
        }
        else if (option == '2') 
        {
            RemovePost();
        }
        else if (option == 'X' || option == 'x')
        {
            Quit();
        }
        else 
        {
            Console.WriteLine("Ogilitigt valt, försök igen.");
        }

    }

    // Skriv inlägg
    public static void WritePost() {
        Console.Clear(); // Rensa konsolen
        Console.WriteLine("Du vill skriva ett inlägg");

          Inlagg myObj = new(); // Instansering av nytt inlägg


          // Kontrollera att namn inte är tomt
          while(true)
          {
            Console.WriteLine("Skriv ditt namn :)");
             myObj.Name = Console.ReadLine(); // Hämta namn från inmatning

             if (string.IsNullOrEmpty(myObj.Name))
             {
                Console.WriteLine("Du måste ange ditt namn för att kunna skriva ett inlägg.");
                Console.WriteLine("Var snäll och försök igen.");
             } else {
                break; // Avbryt om namnet är ifyllt
             }
          }

          // Kontrollera att inlägg inte är tomt
          while(true)
          {
            Console.WriteLine("Skriv ett inlägg :)");
             myObj.Post = Console.ReadLine(); // Hämta inlägg från inmatning

             if (string.IsNullOrEmpty(myObj.Post))
             {
                Console.WriteLine("Du måste skriva något i ditt inlägg.");
                Console.WriteLine("Vänligen försök igen.");
             } else {
                break; // Avbryt om inlägget är ifyllt
             }
          }

              // Lägg till inlägg i lista
             

             // Spara som JSON
             


            // Skriv ut inlägget som användaren skrev
            Console.Clear(); // Rensa konsolen
            Console.WriteLine("Inlägg tillagt");
            Console.WriteLine($"{myObj.Name} skrev:");
             Console.WriteLine($"{myObj.Post}");
             
    }

    // Visa inlägg
    public static void ShowAllPosts() {
        Console.Clear(); // Rensa konsolen
        Console.WriteLine("Alla inlägg i gästboken:");

    }

    // Ta bort inlägg
    public static void RemovePost() {
        Console.Clear(); // Rensa konsolen
        Console.WriteLine("Du vill ta bort ett inlägg");
        Console.WriteLine("Ange det nummer för inlägget du vill ta bort:");

        // Visa alla inlägg
        ShowAllPosts(); 

    }

    // Spara till JSON-fil


    // Läs in inlägg från JSON-filen
   

    // Avsluta
    public static void Quit() {
        Console.WriteLine("hejdå :)");
        Environment.Exit(0); // Avsluta programmet
    }




        static void Main(string[] args)
        {   
            // Välkomna till menyn
            Console.WriteLine("Hej, vad vill du göra?");
            // 1 - skriva inlägg, 2 - ta bort inlägg, X - avsluta

            // Läs in ev befintliga inlägg från fil

            // Visa menyn
            while (true) {
                DisplayMenu();
            }
            
        }
    }

}
