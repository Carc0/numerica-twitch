using System.Threading.Tasks;

public class CreateTalloCommand : ICommand
{
    private readonly TalloController talloController;


    public CreateTalloCommand(TalloController _talloController)
    {
        talloController = _talloController;
    }

    public async Task Execute()
    {
        talloController.CreateTallo();

        // TODO

        await Task.Yield();
    }
}