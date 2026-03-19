using SprShReader;

class Program
{
    private static int Main(string[] args)
    {
        DataReader reader = new DataReader();
        var path = "DigiDB_digimonlist.csv";
        List<Digimon> digimons = reader.ReaderFs(path);

        Ui ui = new Ui();
        ui.UI(digimons);
        ui.UserInterface();

        bool firstLine = true; 
    return 0;
    }
}