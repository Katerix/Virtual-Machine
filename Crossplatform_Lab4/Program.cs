namespace Crossplatform_Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        string[] commands = {
            "0 num 9",
            "1 2",
            "2",
            "4 6",
            "2",
            "3",
            "5 7"
        };
        
        VirtualMachine vm = new VirtualMachine();
        vm.ExecuteCommands(commands);
    }
}