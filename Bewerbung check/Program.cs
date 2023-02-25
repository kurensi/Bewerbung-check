using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        List<string> list = new List<string>();
        List<string> list2 = laden("example.txt");
        while (true)
        {
            try
            {
                Console.Write($"Geben sie den Namen der Firma ein: ");
                string x = Console.ReadLine();
                Console.Write($"Wähle 1 für hinzufügen 2 zur abfrage:  ");
                int wahl = Convert.ToInt32(Console.ReadLine());

                if (wahl == 1)
                {
                    list.Add(x);
                    Console.Clear();
                    Console.WriteLine($"Die Firma wurde hinzugefügt");
                    speicher(list, "example.txt");
                    Console.Write($"\nDrücke eine taste um fortzufahren.............");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (wahl == 2)
                {
                    if (list2.Contains(x))
                    {
                        Console.Clear();
                        Console.WriteLine($"Die Firma wurde bereits angeschrieben");
                        Console.Write($"\nDrücke eine taste um fortzufahren.............");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Firma nicht vorhanden");
                        Console.Write($"\nDrücke eine taste um fortzufahren.............");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Falsche eingabe");
                    Console.Write($"\nDrücke eine taste um fortzufahren.............");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    static void speicher(List<string> list, string filename)
    {
        // Textdatei öffnen und Inhalt anhängen
        using (StreamWriter writer = File.AppendText(filename))
        {
            foreach (string item in list)
            {
                writer.WriteLine(item);
            }
        }
    }

    static List<string> laden(string filename)
    {
        List<string> list = new List<string>();

        // Überprüfen, ob die Datei existiert
        if (File.Exists(filename))
        {
            // Textdatei laden und Inhalt ausgeben
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
        }

        return list;
    }
}