class Program
{
    static void Main()
    {
        TodoApp app = new TodoApp();

        app.ProcessCommand("add Buy groceries");
        app.ProcessCommand("add Pay bills");
        app.ProcessCommand("add Submit assignment");
        app.ProcessCommand("show");

        app.ProcessCommand("tag 0 urgent");
        app.ProcessCommand("tag 2 urgent");

        Console.WriteLine("Tasks tagged as 'urgent':");
        app.ProcessCommand("get-tagged urgent");

        app.ProcessCommand("remove 0");
        app.ProcessCommand("show");
        Console.WriteLine("Tasks tagged as 'urgent':");
        app.ProcessCommand("get-tagged urgent");

        app.ProcessCommand("clear");
        app.ProcessCommand("show");
    }
}