namespace Crossplatform_Lab4;

/// <summary>
/// Virtual Machine
/// </summary>
public class VirtualMachine
{
    #region Private Fieds

    /// <summary>
    /// The numeric variables
    /// </summary>
    readonly Dictionary<string, int> NumericVariables = new Dictionary<string, int>();

    /// <summary>
    /// The memory stack
    /// </summary>
    readonly Stack<int> MemoryStack = new Stack<int>();

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="VirtualMachine"/> class.
    /// </summary>
    public VirtualMachine()
    {
        NumericVariables = new Dictionary<string, int>();
        MemoryStack = new Stack<int>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Executes the commands.
    /// </summary>
    /// <param name="commands">The commands.</param>
    public bool ExecuteCommands(IEnumerable<string> commands)
    {
        foreach (var command in commands)
        {
            Console.WriteLine($"\nInput: {command}");

            string[] commandParts = command.Replace(",", "").Split(" ");

            if (!HandleCommand(commandParts))
                return false;
        }

        return true;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the command.
    /// </summary>
    /// <param name="commandParts">The command parts.</param>
    bool HandleCommand(string[] commandParts)
    {
        var task = Convert.ToByte(commandParts[0]);

        bool result = false;

        switch ((CommandCode)task)
        {
            case CommandCode.CRTVAR:
                result = CreateVariable(commandParts[1], int.Parse(commandParts[2]));
                break;

            case CommandCode.PUSH:
                result = Push(int.Parse(commandParts[1]));
                break;

            case CommandCode.ADD:
                result = Add(commandParts[1]);
                break;

            case CommandCode.SUBSTR:
                result = Subtract(commandParts[1]);
                break;

            case CommandCode.INC:
                result = Increment();
                break;

            case CommandCode.DECR:
                result = Decrement();
                break;
        }

        return result;
    }

    /// <summary>
    /// Creates the variable.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    bool CreateVariable(string name, int value)
    {
        try
        {
            NumericVariables[name] = value;
        }
        catch
        {
            return false;
        }


        Console.WriteLine($"Created variable: {name}={value}");

        return true;
    }

    /// <summary>
    /// Pushes the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    bool Push(int value)
    {
        try
        {
            MemoryStack.Push(value);
        }
        catch
        {
            return false;
        }

        PrintResult(CommandCode.PUSH);
        return true;
    }

    /// <summary>
    /// Increments this instance.
    /// </summary>
    bool Increment()
    {
        try
        {
            int variable = MemoryStack.Pop();
            MemoryStack.Push(variable + 1);
        }
        catch
        {
            return false;
        }

        PrintResult(CommandCode.INC);
        return true;
    }

    /// <summary>
    /// Decrements this instance.
    /// </summary>
    bool Decrement()
    {
        try
        {
            int variable = MemoryStack.Pop();
            MemoryStack.Push(variable - 1);
        }
        catch
        {
            return false;
        }

        PrintResult(CommandCode.DECR);
        return true;
    }

    /// <summary>
    /// Adds the specified variable name.
    /// </summary>
    /// <param name="varName">Name of the variable.</param>
    bool Add(string varName)
    {
        try
        {
            int var2 = varName.StartsWith("$") ? MemoryStack.Pop() : int.Parse(varName);
            int var1 = MemoryStack.Pop();
            MemoryStack.Push(var1 + var2);
        }
        catch
        {
            return false;
        }

        PrintResult(CommandCode.ADD);
        return true;
    }

    /// <summary>
    /// Subtracts the specified variable name.
    /// </summary>
    /// <param name="varName">Name of the variable.</param>
    bool Subtract(string varName)
    {
        try
        {
            int var2 = varName.StartsWith("$") ? MemoryStack.Pop() : int.Parse(varName);
            int var1 = MemoryStack.Pop();
            MemoryStack.Push(var1 - var2);
        }
        catch
        {
            return false;
        }

        PrintResult(CommandCode.SUBSTR);
        return true;
    }

    /// <summary>
    /// Prints the result.
    /// </summary>
    /// <param name="command">The command.</param>
    void PrintResult(CommandCode? command = null) => Console.WriteLine($"{command}: {MemoryStack.Peek()}");

    #endregion
}