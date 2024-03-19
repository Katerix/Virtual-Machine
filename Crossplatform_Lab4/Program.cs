namespace Crossplatform_Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        string[] commands = {
            "0 num 5",
            "1 3",
            "4 6",
            "2",
            "5 2",
            "3"
        };

        VirtualMachine vm = new VirtualMachine();
        vm.ExecuteCommands(commands);
    }
}