using System;
using System.IO;
using SprShReader;

class Program
{
    

    private static int Main(string[] args)
    {
        ReaderF reader = new ReaderF();
        var path = "DigiDB_digimonlist.csv";
        List<Digimon> digimons = reader.ReaderFs(path);

        Ui ui = new Ui();
        ui.UI(digimons);
        ui.UserInterface();
        
      

        bool firstLine = true; 
        foreach (string line in File.ReadLines(path))
        {
            if (firstLine) { firstLine = false; continue; }

            string[] col = line.Split(',');

            var digimon = new Digimon
            {
                Number     = int.Parse(col[0]),
                Name       = col[1],
                Stage      = col[2],
                Type       = col[3],
                Attribute  = col[4],
                Memory     = int.Parse(col[5]),
                EquipSlots = int.Parse(col[6]),
                Hp         = int.Parse(col[7]),
                Sp         = int.Parse(col[8]),
                Atk        = int.Parse(col[9]),
                Def        = int.Parse(col[10]),
                Int        = int.Parse(col[11]),
                Spd        = int.Parse(col[12]),
            };

            digimons.Add(digimon);
        }
        // foreach (var d in digimons)
        // {
        //     Console.WriteLine($"{d.Name} | {d.Stage} | HP: {d.Hp} | ATK: {d.Atk}");
        // }
    return 0;
    }
}