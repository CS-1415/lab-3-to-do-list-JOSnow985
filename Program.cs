// Jaden Olvera, 1/27/26, Lab 3 - ToDo List
using System.Text;

// List of tasks we'll be working on
List<Task> taskList = [];

// Adding some example ones for now
taskList.Add(new Task(taskList.Count, "TestTitle1", "TestDesc1", false));
taskList.Add(new Task(taskList.Count, "TestTitle2", "TestDesc2", false));
taskList.Add(new Task(taskList.Count, "TestTitle3", "TestDesc3", false));

string tableHeader = "Jaden's To Do List App\n\n    | ID  | Task\n-------------------------------------------";

// Writing the tasks to the console
displayTaskList(tableHeader, taskList);
Console.WriteLine("\nPress \"+\" to add a task. Press \"x\" to toggle whether or not the task is complete. Press \"i\" to view a task's information.");



// Methods
static void displayTaskList(string tableHeader, List<Task> taskList)
{
    Console.WriteLine(tableHeader);
    foreach (Task task in taskList)
    {
        task.DisplayTask();
    }
}

// Searches passed list for a Task with a matching ID. Returns a bool with a possibly null out if the ID wasn't found.
static bool TryFindTaskbyID(int targetID, List<Task> taskList, out Task? foundTask)
{
    // Iterates through the list looking for the Task with the targetID
    foreach (Task task in taskList)
    {
        if (task.TaskID == targetID)
        {
            foundTask = task;
            return true;
        }
    }
    foundTask = null;
    return false;
}

// Clears current view and displays header, then calls TryFind to get the requested task, displays it, then displays the description.
static void DisplayTaskInfo(string tableHeader, int targetID, List<Task> taskList)
{
    Console.Clear();
    Console.WriteLine(tableHeader);

    // Displays the task and description or tells the user the ID wasn't found.
    if (TryFindTaskbyID(targetID, taskList, out Task? task) && task != null)
    {
        task.DisplayTask();
        Console.WriteLine($"\n{task.TaskDescription}\n");
    }
    else
    {
        Console.WriteLine("\nNo task with that ID found.\n");
    }
    Console.WriteLine("\nPress any key to return to the task list.");
    Console.ReadKey();
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