using System.Collections.Generic;
using System.Threading.Tasks;

public class CommandQueue
{
    public static CommandQueue Instance => instance ?? (instance = new());

    private readonly Queue<ICommand> commandsToExecute;
    private bool runningCommand;
    private static CommandQueue instance;


    private CommandQueue()
    {
        commandsToExecute = new();
        runningCommand = false;
    }

    public void AddCommand(ICommand commandToQueue)
    {
        commandsToExecute.Enqueue(commandToQueue);
        RunNextCommand().WrapErrors();
    }

    private async Task RunNextCommand()
    {
        if (runningCommand) return;

        while (commandsToExecute.Count > 0)
        {
            runningCommand = true;

            var commandToExecute = commandsToExecute.Dequeue();

            await commandToExecute.Execute();
        }

        runningCommand = false;
    }
}