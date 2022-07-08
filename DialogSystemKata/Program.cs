// See https://aka.ms/new-console-template for more information

using DialogSystem;
using DialogSystemKata;

Console.WriteLine("Hello, World!");

var dialogSystem = new DialogSystem.DialogSystem(new DialogNodeStructure(Dialogs.Dialog));

var nodeDialog = dialogSystem.GetNode(1);
Console.WriteLine(nodeDialog.GetText());
Console.WriteLine(nodeDialog.GetReaction());
Console.WriteLine();
foreach (var nodeAction in nodeDialog.GetActions())
{
    Console.WriteLine($"{nodeAction.Number.ToString()} - {nodeAction.ActionTxt}");
}

var consoleKeyInfo = Console.ReadLine();
Console.WriteLine(Convert.ToInt32(consoleKeyInfo));

var first = nodeDialog.GetActions().First(action => action.Number.ToString().Equals(consoleKeyInfo));
var chooseAction = dialogSystem.ChooseAction(new NodeActionTaken(nodeDialog.GetId(),first.Number));

Console.Clear();

Console.WriteLine(chooseAction.GetText());
Console.WriteLine(chooseAction.GetReaction());
Console.WriteLine();
foreach (var nodeAction in chooseAction.GetActions())
{
    Console.WriteLine($"{nodeAction.Number.ToString()} - {nodeAction.ActionTxt}");
}