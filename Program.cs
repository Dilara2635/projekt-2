using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace projekt_2
{
    class Program
    {
        public static string path = (@"C:\Users\Dilara2635\source\repos\projekt-programmering\bin\Debug\net8.0\Ham.txt");

        class User
        {
            //det her er varibler

            public string Telefonnummer { get; set; }
            public string Fornavn { get; set; }
            public string Efternavn { get; set; }
            public string Email { get; set; }
            public int Alder { get; set; }
            public string Adresse { get; set; }
            public string Postnummer { get; set; }
            public string By { get; set; }
            public int Nyhedsbrev { get; set; }

            public static string[] entries = { };
            static int usercount = 0; //antal af brugere

            public static void Main()
            {
                Mainmenu();
            }

            public static void Sidevalg()
            {
                /// <summary>
                /// varibler: int og string
                /// While loop
                /// Koden viser en liste af brugere(som er læst fra filen) 
                /// i sideopedelende. 
                /// Det betyder det er kun et antal brugere som er f.eks. 13 brugere som bliver vist af gangen
                /// og man kan også bladre frem og tilbage mellem siderne inde i programmet.
                /// 
                /// Læsning af data er at programmet først læser filen, som indholder oplysninger om brugerne, 
                /// som hver linje i filen repræsentere en bruger og det liver gemt i en liste 2 som er visning.
                /// <summary> 
                int side = 1;
                int page = 0;
                int UserPerPage = 13; 
                string[] alleBrugererArr = File.ReadAllLines(path);
                List<string> alleBrugerer = alleBrugererArr.ToList();
                alleBrugerer.IndexOf(alleBrugerer[13 * page], 13);

                while (true)
                {
                    Console.Clear();
                    for (int i = page * UserPerPage; i < Math.Min((page + 1) * UserPerPage, alleBrugererArr.Length); i++ )
                        Console.WriteLine( alleBrugererArr[i]);
                    Console.WriteLine("\n[+] næste side [-] forrige side [Q} afslut");
                    string input = Console.ReadLine().ToUpper();

                    if (input == "Q") break;
                    if (input == "+" && (page + 1) * UserPerPage < alleBrugererArr.Length) page++;
                    if (input == "-" && page > 0) page--;
                }
                 
            }

            public static void Login()
            {
                ///<summary>
                /// Her bliver login kode lavet.
                /// Her bruger vi string variblen, if loop og while loop. 
                /// Indtastning af password ligger under søgifil og visallebruger
                ///</summary>
                string username;
                string rigtigpassword = "TECBallerup";
                string access;
                string accessdenied;
                string brugerinput = "";

                while (brugerinput != rigtigpassword)
                {
                    Console.Write("Enter password: ");
                    brugerinput = Console.ReadLine();

                    if (brugerinput != rigtigpassword)
                    {
                        Console.WriteLine("forkert password, tast igen");
                    }
                }

                Console.WriteLine("korrekt passowrd, velkommen.");
            }

            public static void Mainmenu()
            {
                while (true)
                {
                    /// <summary>
                    /// Her bliver vores menuen lavet. 
                    /// Her opretter vi en bruger i standeren,
                    /// Her vi finder vi vores bruger skrevet i systemet og viser det frem.
                    /// Her indtaster vi også en kode til vores bruger for login
                    /// Tilsidst afslutter vi med exit
                    /// </summary>



                    Console.Clear();
                    Console.Write("velkommen til informationsstanderen");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("vælg en mulighed");
                    Console.WriteLine();
                    Console.WriteLine("1. Opret bruger: ");
                    Console.WriteLine("2. Søg bruger: ");
                    Console.WriteLine("3. Vis alle brugere: ");
                    Console.WriteLine("4. Vis aldergennemsnit: ");
                    Console.WriteLine("5. Exit: ");

                    /// </summary>
                    /// Her bruger vi det valgte menupunkt.
                    /// Her bruger vi switch case loop.
                    /// </summary>
                    switch (Console.ReadLine())
                    {
                        case "1":
                            OpretteBruger();
                            break;
                        case "2":
                            Login();
                            SøgIFil();
                            break;
                        case "3":
                            Sidevalg();
                            Login();
                            VisAlleBruger();
                            break;
                        case "4":
                            CalculatAverageAge();
                            break;
                        case "5":
                            Console.WriteLine("Her afslutter programmet: ");
                            break;
                        default:
                            Console.WriteLine("Forkert indtast, prøv igen: ");
                            break;
                    }
                }
            }

            public static void OpretteBruger()
            {
                /// </summary>
                /// Varibler: string, bool og int.
                /// Her starter vi koden ved at oprette bruger, hvor bruger indtaster sin oplysninger.
                /// Her bruger vi if else og foreach loopen.
                /// <summary> 
                string Fornavn, Efternavn, Telefonnummer, Email, Adresse, Postnummer, By, Entry;
                int Alder, Nyhedsbrev;
                bool isPhoneNumberValid = true;
                Console.Clear();
                Console.Write("Enter Fornavn: ");
                Fornavn = Console.ReadLine();
                Console.Write("Enter Efternavn: ");
                Efternavn = Console.ReadLine();
                Console.Write("Enter Alder: ");
                Alder = int.Parse(Console.ReadLine());
                Console.Write("Enter Telefonnummer: ");
                Telefonnummer = Console.ReadLine();
                Console.Write("Enter Email: ");
                Email = Console.ReadLine();
                Console.Write("Enter Adresse: ");
                Adresse = Console.ReadLine();
                Console.Write("Enter Postnummer: ");
                Postnummer = Console.ReadLine();
                Console.Write("Enter By: ");
                By = Console.ReadLine();
                Console.Write("Enter Nyhedsbrev (12, 4, 1): ");
                Nyhedsbrev = int.Parse(Console.ReadLine());

                /// <summary>
                /// Her finder man ud af om telefonnummet findes eller ikke findes i systemet. 
                /// </summary>
                var valid = IsPhoneNumberValid(isPhoneNumberValid, Telefonnummer);

                if (valid)
                {
                    Entry = $"Fornavn: {Fornavn}, Eftrnavn: {Efternavn}, Alder: {Alder}, Telefonnummer: {Telefonnummer}, Email: {Email}, Adresse: {Adresse}, Postnummer: {Postnummer}, By: {By}";
                    var brugerData = entries.Append(Entry).ToArray();
                    foreach (var bruger in brugerData)
                    {
                        File.AppendAllText(path, bruger + Environment.NewLine);
                        Console.WriteLine("Bruger er oprettet");
                    }
                }
                else
                {
                    Console.WriteLine("Brugeren blev ikke oprettet. Telefonnummer findes allerede");
                }
                Console.WriteLine("Tast enter for komme tilbage til menuen...");
                Console.ReadKey();
            }
            
            /// <summary>
            /// Varibler: bool og string.
            /// Foreach, return og if loop.
            /// IsPhoneNumberValid metoden tjekker om den indtastede telefonnummer allerede findes i filen.
            /// </summary>
            public static bool IsPhoneNumberValid(bool isPhoneNumberValid, string Telefonnummer)
            {
                /// Læser hele filen igennem
                foreach (var line in File.ReadAllLines(path))
                {
                    if (isPhoneNumberValid)
                    {
                        // Tjekker om den indtastede telefonnummer i "line" variablet indeholder værdien i "Telefonnummer",
                        // hvis den gøre, bliver isPhoneNumverValid sat til false.
                        // Hvis den ikke, forsætter foreach loopen med at læse alle linjer igennem og returnere true, hvis nummeret ikke findes.
                        if (line.Contains(Telefonnummer))
                        {
                            return isPhoneNumberValid = false;
                        }
                    }
                }
                return true;
            }

            public static void SøgIFil()
            {
                /// <summary>
                /// Varibler: string.
                /// Brug af foreach og if loop.
                /// </summary>
                Console.Clear();
                Console.Write("Søg: ");
                string search = Console.ReadLine();
                Console.WriteLine();

                /// <summary> 
                /// Læser hele filen igennem, og viser kun brugere som matcher med vores "search".
                /// </summary> 
                foreach (var line in File.ReadAllLines(path))
                {
                    if (line.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"bruger fundet: {line}");
                    }
                }
                Console.WriteLine("Tast enter for komme tilbage til menuen...");
                Console.ReadKey();
            }

            /// <summary>
            /// Her bruger vi foreach loop. 
            /// Her finder vi ud af hvordan vi regner gemmesnits alderen om den runder ned eller op.
            /// </summary>
            public static void VisAlleBruger()
            {
                Console.Clear();

                foreach (var line in File.ReadAllLines(path))
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine();
                Console.WriteLine("Tast enter for komme tilbage til menuen...");
                Console.ReadKey();

            }

            public static void CalculatAverageAge()
            {
                /// <summary>
                /// Varibler: int og string.
                /// Her bruger vi foreach og if else loopen. 
                /// Her starter vi med skrive koden inde i programmet, så vi kan se om gennemsnit af alder runder op eller ned.
                /// </summary>
                int usercount = 0;

                Console.Clear();
                usercount = File.ReadAllLines(path).Count();
                foreach (var line in File.ReadAllLines(path))
                {
                    usercount++;
                }

                if (usercount == 0)
                {
                    Console.WriteLine("Ingen bruger er oprettet");
                }
                else
                {
                    int totalage = 0;
                    foreach (var line in File.ReadAllLines(path))
                    {
                        string[] parts = line.Split(',');
                        foreach (var part in parts)
                        {
                            if (part.Contains("Alder"))
                            {
                                int Age = int.Parse(part.Split(':')[1].Trim());
                                totalage += Age;
                            }
                        }
                    }

                    double averageage = (double)totalage / usercount;
                    Console.WriteLine($"Gemmesnitsalderen: {averageage:N0} år");

                }
                Console.ReadLine();
            }

        }
    }
}