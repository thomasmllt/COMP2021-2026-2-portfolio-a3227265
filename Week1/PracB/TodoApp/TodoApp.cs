public class TodoApp
{
    private List<string> tasks = new List<string>();
    private Dictionary<string, List<int>> tags = new Dictionary<string, List<int>>();

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

                    List<string> tagNames = new List<string>(tags.Keys);
                    foreach (string tagName in tagNames)
                    {
                        List<int> updatedIndices = new List<int>();
                        foreach (int existingIndex in tags[tagName])
                        {
                            if (existingIndex == index)
                            {
                                continue;
                            }

                            updatedIndices.Add(existingIndex > index ? existingIndex - 1 : existingIndex);
                        }

                        tags[tagName] = updatedIndices;
                    }

                    Console.WriteLine($"Removed: {removed}");
                }
                else
                {
                    Console.WriteLine("Error: Invalid or out-of-range index.");
                }
                break;

            case "clear":
                tasks.Clear();
                tags.Clear();
                Console.WriteLine("To-do list cleared.");
                break;

            case "tag":
                try
                {
                    string[] tagParts = argument.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                    if (tagParts.Length < 2)
                    {
                        throw new ArgumentException("Usage: tag [index] [name]");
                    }

                    int tagIndex = int.Parse(tagParts[0]);
                    string tagName = tagParts[1].Trim();

                    if (string.IsNullOrWhiteSpace(tagName))
                    {
                        throw new ArgumentException("Tag name cannot be empty.");
                    }

                    if (tagIndex < 0 || tagIndex >= tasks.Count)
                    {
                        throw new IndexOutOfRangeException("Index is out of range.");
                    }

                    if (!tags.ContainsKey(tagName))
                    {
                        tags[tagName] = new List<int>();
                    }

                    if (tags[tagName].Contains(tagIndex))
                    {
                        throw new InvalidOperationException("That task already has this tag.");
                    }

                    tags[tagName].Add(tagIndex);
                    Console.WriteLine($"Tagged task {tagIndex} with '{tagName}'.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Index must be a number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "get-tagged":
                try
                {
                    string tagName = argument.Trim();
                    if (string.IsNullOrWhiteSpace(tagName))
                    {
                        throw new ArgumentException("Usage: get-tagged [tag]");
                    }

                    List<int> taggedIndices = tags[tagName];
                    if (taggedIndices.Count == 0)
                    {
                        Console.WriteLine($"No tasks tagged '{tagName}'.");
                        break;
                    }

                    bool foundAny = false;
                    foreach (int taggedIndex in taggedIndices)
                    {
                        if (taggedIndex < 0 || taggedIndex >= tasks.Count)
                        {
                            throw new IndexOutOfRangeException("A tagged index is out of range.");
                        }

                        Console.WriteLine($"{taggedIndex}: {tasks[taggedIndex]}");
                        foundAny = true;
                    }

                    if (!foundAny)
                    {
                        Console.WriteLine($"No tasks tagged '{tagName}'.");
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"Error: Tag '{argument.Trim()}' does not exist.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            default:
                Console.WriteLine("Error: Unknown command. Use add [item], show, remove [index], clear, tag [index] [name] or get-tagged [tag].");
                break;
        }
    }
}