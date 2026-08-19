public class TodoApp
{
    private List<string> tasks = new List<string>();

    public void ProcessCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Please enter a command.");
            return;
        }

        string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string command = parts[0].ToLower();
        string argument = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        switch (command)
        {
            case "add":
                if (string.IsNullOrWhiteSpace(argument))
                {
                    Console.WriteLine("Error: Task cannot be empty.");
                }
                else
                {
                    tasks.Add(argument);
                    Console.WriteLine($"Added: {argument}");
                }
                break;

            case "show":
                if (tasks.Count == 0)
                {
                    Console.WriteLine("Your to-do list is empty.");
                }
                else
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i}: {tasks[i]}");
                    }
                }
                break;

            case "remove":
                if (int.TryParse(argument, out int index) && index >= 0 && index < tasks.Count)
                {
                    string removed = tasks[index];
                    tasks.RemoveAt(index);
                    Console.WriteLine($"Removed: {removed}");
                }
                else
                {
                    Console.WriteLine("Error: Invalid or out-of-range index.");
                }
                break;

            case "clear":
                tasks.Clear();
                Console.WriteLine("To-do list cleared.");
                break;

            default:
                Console.WriteLine("Error: Unknown command. Use add [item], show, remove [index], or clear.");
                break;
        }
    }
}