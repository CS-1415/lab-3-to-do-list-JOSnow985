// Jaden Olvera, 1/27/26, Lab 3 - ToDo List
using System.Text;

Console.WriteLine("A ToDo List app!");

Task test = new(0, true);
test.DisplayTask();
test.DisplayDescription();
test.MarkAsCompleted();
test.DisplayTask();

class Task
{
    // Data members for a Task
    private int _taskID;
    private string _taskTitle = "Improve ToDo List Code";
    private string _taskDescription = "Make the code better!";
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

    // Constructor
    public Task(int taskID, bool taskComplete)
    {
        _taskID = taskID;
        _taskComplete = taskComplete;
    }

    // Methods
    // Writes the completion status, ID, and task name to a line in the console
    public void DisplayTask()
    {
        // Build string to represent the current task
        StringBuilder taskString = new();

        // Checks if task has been set as complete
        if (_taskComplete == true)
            taskString.Append("[X] | ");
        else
            taskString.Append("[ ] | ");
        
        // Appends the task's ID number, aligned to the left in a "field" 3 digits wide
        taskString.AppendFormat("{0,-3}", _taskID);

        // Appends the task's title
        taskString.Append($" | {_taskTitle}");

        Console.WriteLine(taskString.ToString());
    }
    // Displays the task description
    public void DisplayDescription()
    {
        Console.WriteLine(_taskDescription);
    }
    // Toggles completion status
    public void MarkAsCompleted()
    {
        if (_taskComplete == false)
            _taskComplete = true;
        else
            _taskComplete = false;
    }
}