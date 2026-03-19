namespace SprShReader;

public class DataReader
{
    public List<Digimon> ReaderFs(string path)
    {
        var digimons = new List<Digimon>();
        bool firstLine = true;

        foreach (string line in File.ReadLines(path))
        {
            if (firstLine)
            {
                firstLine = false;
                continue;
            } // skip header row

            string[] col = line.Split(',');

            var digimon = new Digimon
            {
                Number = int.Parse(col[0]),     // index Number of digimon
                Name = col[1],                  // Digimon
                Stage = col[2],                 // Stage
                Type = col[3],                  // Type
                Attribute = col[4],             // Attribute
                Memory = int.Parse(col[5]),     // Memory
                EquipSlots = int.Parse(col[6]), // EquipSlot
                Hp = int.Parse(col[7]),         // Health points
                Sp = int.Parse(col[8]),         // Stamina Points
                Atk = int.Parse(col[9]),        // Attack
                Def = int.Parse(col[10]),       // Defense
                Int = int.Parse(col[11]),       // Intelligence
                Spd = int.Parse(col[12]),       // Speed
            };

            digimons.Add(digimon);
        }

        return digimons;
    }

    public void Reader(List<Digimon> digimons, string filterType, string userInput)
    {
        var results = filterType switch
        {
            "Search for digimon"   => digimons.Where(d => d.Name == userInput),
            "Find digimon by min attack" => digimons.Where(d => d.Atk >= int.Parse(userInput)),
            "Find digimon by min HP"  => digimons.Where(d => d.Hp >= int.Parse(userInput)),
            _        => Enumerable.Empty<Digimon>()
        };

        if (!results.Any())
            Console.WriteLine("No Digimon found.");
        else
            foreach (var d in results)
                Console.WriteLine($"{d.Name} | HP: {d.Hp} | ATK: {d.Atk}");
    }
}