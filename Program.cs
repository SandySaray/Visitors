using System;
using System.Collections.Generic;

namespace BesucherStatistik
{ 
    public class BesucherEintrag
    {
        public DateTime Zeit;
     
        public int personen;
        public bool kommRein;
    }

    class Program
    {
        static void Main(string[] args)
        {
          var besucherStatistik =new List<BesucherEintrag>
          {
            new BesucherEintrag { Zeit = new DateTime(2025, 10, 1, 9, 0, 0), personen = 5, kommRein = true },
            new BesucherEintrag { Zeit = new DateTime(2025, 10, 1, 10, 0, 0), personen = 3, kommRein = true },
            new BesucherEintrag { Zeit = new DateTime(2025, 10, 1, 11, 0, 0), personen = 2, kommRein = false },
            new BesucherEintrag { Zeit = new DateTime(2025, 10, 2, 12, 0, 0), personen = 4, kommRein = true },  
            new BesucherEintrag { Zeit = new DateTime(2025, 10, 1, 13, 0, 0), personen = 1, kommRein = false }
          };

           

            var table = CountVisitors(besucherStatistik);
            for (int i=0; i<2; i++)
            {
                Console.WriteLine($"Tag {i+1}:");
                for (int j=0; j<10; j++)
                {
                    Console.WriteLine($"Stunde {j+9}: {table[i,j]} Besucher");
                }
            }
            Console.WriteLine("Besucherstatistik erfolgreich erstellt.");
        }

        static int [,] CountVisitors(List<BesucherEintrag>entries)
        {
            int anzahlTage=31;

            int[,] visitors = new int [anzahlTage, 10];

            for (int i= 0; i< entries.Count; i++)
            {
                var entry = entries[i];
                int day=entries[i].Zeit.Day;
                int hour= entries[i].Zeit.Hour;
                
                int row= day -1;
                int column =hour -9;

                if (entry.kommRein)
                {
                    for (int j=column; j<10;j++)
                    {
                        visitors[row,j]+= entry.personen; // Anzahl der Personen, die reinkommen
                    }
                }
                else 
                {
                    for (int j=column+1 ; j< 10 ; j++)
                    {
                        visitors[row,j] -= entry.personen; // Anzahl der Personen, die rausgehen
                    }
                }
            }
            return visitors;
        } 
    }
}