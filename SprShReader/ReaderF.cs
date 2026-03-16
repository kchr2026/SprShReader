namespace SprShReader;

public class ReaderF
{
    public List<Digimon> ReaderFs(string path)
    {
        var digimons = new List<Digimon>();
        bool firstLine = true;

        foreach (string line in File.ReadLines(path))
        {
            if (firstLine) { firstLine = false; continue; } // skip header row

            string[] col = line.Split(',');

            var digimon = new Digimon
            {
                Number     = int.Parse(col[0]),  // Number
                Name       = col[1],             // Digimon
                Stage      = col[2],             // Stage
                Type       = col[3],             // Type
                Attribute  = col[4],             // Attribute
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

        return digimons;
    }
}