namespace SprShReader;
using Spectre.Console;
public class Ui
{
    private List<Digimon> _digimons;
    private DataReader reader = new DataReader();
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
             .AddChoices("Search for digimon", "Find digimon by min attack", "Find digimon by min HP", "Exit"));

         switch (choice_input)
         {
             case "Search for digimon":
             {
                 userInput = AnsiConsole.Ask<string>("[green]What digimon would you like to see?[/]");
                     reader.Reader(_digimons, choice_input,userInput);
                 break;
             }
             case "Find digimon by min attack":
             {
                 userInput = AnsiConsole.Ask<string>("[green]Enter the desired minimum attack[/]");
                 reader.Reader(_digimons, choice_input,userInput);
                 break;
             }
             case "Find digimon by min HP":
                 userInput = AnsiConsole.Ask<string>("[green]Enter the desired minimum HP[/]");
                 reader.Reader(_digimons, choice_input,userInput);
                 break;
             case "Exit" :
                 break;
         }
     }
}