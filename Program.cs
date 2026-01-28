// Jaden Olvera, 1/27/26, Lab 3 - ToDo List
using System.Text;

Console.WriteLine("A ToDo List app!");

// List of tasks we'll be working on
List<Task> taskList = [];

// Adding some example ones for now
taskList.Add(new Task(taskList.Count, "TestTitle1", "TestDesc1", false));
taskList.Add(new Task(taskList.Count, "TestTitle2", "TestDesc2", false));
taskList.Add(new Task(taskList.Count, "TestTitle3", "TestDesc3", false));

// Writing the tasks to the console
Console.WriteLine("    | ID  | Task");
foreach (Task item in taskList)
{
    item.DisplayTask();
}

// Class
class Task(int taskID, string taskTitle, string taskDescription, bool taskComplete)
{
    // Data members for a Task, default strings for non-nullable fields
    private int _taskID = taskID;
    private string _taskTitle = taskTitle;
    private string _taskDescription = taskDescription;
    private bool _taskComplete = taskComplete;

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