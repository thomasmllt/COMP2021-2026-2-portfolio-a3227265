class Program
{
    static void Main()
    {
        TodoApp app = new TodoApp();

        app.ProcessCommand("add Buy groceries");
        app.ProcessCommand("add Pay bills");
        app.ProcessCommand("show");
        app.ProcessCommand("remove 0");
        app.ProcessCommand("show");
        app.ProcessCommand("clear");
        app.ProcessCommand("show");
    }
}