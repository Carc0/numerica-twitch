using System.Threading.Tasks;

public class WaterHojaCommand : ICommand
{
    private readonly TalloController talloController;
    private readonly PlantEnums.HojaType hojaType;


    public WaterHojaCommand(TalloController _talloController, PlantEnums.HojaType _hojaType)
    {
        talloController = _talloController;
        hojaType = _hojaType;
    }

    public async Task Execute()
    {
        talloController.WaterHoja(hojaType);

        // TODO

        await Task.Yield();
    }
}
