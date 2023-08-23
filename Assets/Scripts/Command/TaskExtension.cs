using System.Threading.Tasks;

public static class TaskExtension
{
    public static async void WrapErrors(this Task task)
    {
        await task;
    }
}