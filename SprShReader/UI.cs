namespace SprShReader;
using Spectre.Console;
public class Ui
{
    private List<Digimon> _digimons;

    public void UI(List<Digimon> digimons)
    {
        _digimons = digimons;
    }

     
     public void UserInterface (){
         string userInput = "";
             int result=0;
         var choice_input = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
             .Title("[green]What would you like to see?[/]")
             .AddChoices("Search for digimon", "Find digimon by min attack", "Option2", "Option2", "Exit"));

         switch (choice_input)
         {
             case "Search for digimon":
             {
                 userInput = AnsiConsole.Ask<string>("[green]What digimon would you like to see?[/]");
                     var results = _digimons
                         .Where(d => d.Name == userInput)
                         .Select(d => new { d.Name, d.Hp, d.Atk });
                     if (!results.Any())
                         Console.WriteLine($"No Digimon found with a name given {userInput}");
                     else
                         foreach (var d in results)
                             Console.WriteLine($"{d.Name} | HP: {d.Hp} | ATK: {d.Atk}");
                 break;
             }
             case "Find digimon by min attack":
             {
                 userInput = AnsiConsole.Ask<string>("[green]What digimon would you like to see?[/]");
                 var results = _digimons
                     .Where(d => d.Atk >= int.Parse(userInput))
                     .Select(d => new { d.Name, d.Hp, d.Atk });

                 if (!results.Any())
                     Console.WriteLine($"No Digimon found with a minimum ATK of {userInput}");
                 else
                     foreach (var d in results)
                         Console.WriteLine($"{d.Name} | HP: {d.Hp} | ATK: {d.Atk}");

                 break;
             }
             case "Multiplication":
                 break;
             case "Division":
                 break;
             case "Exit" :
                 break;
         }
     }
     public static void ParseWarning(string input)
     {
          AnsiConsole.MarkupLine($"[bold red]Warning:[/] Unable to parse '{input}' as an integer. Please Check the CSV file.");
     }
}