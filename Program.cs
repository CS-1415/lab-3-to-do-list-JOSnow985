// Jaden Olvera, 1/27/26, Lab 3 - ToDo List
Console.WriteLine("A ToDo List app!");

class Task
{
    // Data members for a Task
    private int _taskID;
    private string _taskTitle = "";
    private string _taskDescription = "";
    private bool _taskComplete;

    // Getters and Setters
    public int TaskID
    {
        get => _taskID;
        set => _taskID = value;
    }
    public string TaskTitle
    {
        get => _taskTitle;
        set => _taskTitle = value;
    }
    public string TaskDescription
    {
        get => _taskDescription;
        set => _taskDescription = value;
    }
    public bool TaskComplete
    {
        get => _taskComplete;
        set => _taskComplete = value;
    }

    // Methods
    // Displays the completion status, ID, and task name
    public void DisplayTask()
    {
        Console.Write("stub");
    }
    // Displays the task description
    public void DisplayDescription()
    {
        Console.Write("stub");
    }
    // Toggles completion status
    public void MarkAsCompleted()
    {
        Console.Write("stub");
    }
}