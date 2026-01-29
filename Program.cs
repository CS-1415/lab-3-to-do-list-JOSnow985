// Jaden Olvera, 1/27/26, Lab 3 - ToDo List
using System.Text;

// List of tasks we'll be working on
List<Task> taskList = [];

// Adding some example ones for now
taskList.Add(new Task(taskList.Count + 1, "Get a new Task", "Decide on a new task to put on this list."));
taskList.Add(new Task(taskList.Count + 1, "Erase old Task", "Figure out how to erase an old task."));
taskList.Add(new Task(taskList.Count + 1, "Don't complete this task", "Leave this task uncompleted, successfully."));

string tableHeader = "Jaden's To Do List App\n\n    | ID  | Task\n---------------------------------------";

// Main menu loop
while (true)
{
    Console.Clear();
    // Writing the tasks to the console
    displayTaskList(tableHeader, taskList);
    Console.WriteLine("\nPress \"+\" to add a task. Press \"x\" to toggle whether or not the task is complete. Press \"i\" to view a task's information.");

    // switch based on pressed key
    switch (Console.ReadKey(true).KeyChar)
    {
        // "+" for adding a list item
        case '=':
        case '+':
            AddNewTask(taskList);
            break;
        // "x" for toggling a task's completion
        case 'x':
        case 'X':
            Console.Write("\nPlease enter the ID of the task you want to toggle completion for: ");
            TaskOperation(tableHeader, false, taskList);
            break;
        // "i" for information on a task
        case 'i':
        case 'I':
            Console.Write("\nPlease enter the ID of the task you want information on: ");
            TaskOperation(tableHeader, true, taskList);
            break;
        default:
            break;
    }
}


// Methods
static void displayTaskList(string tableHeader, List<Task> taskList)
{
    Console.WriteLine(tableHeader);
    foreach (Task task in taskList)
    {
        task.DisplayTask();
    }
}

// Takes validated user input to add a Task to a passed list
static void AddNewTask(List<Task> taskList)
{
    string newTitle = "";
    bool validString = false;
    while (!validString)
    {
        Console.Clear();
        Console.WriteLine("What should the new task's title be?");
        string inputString = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(inputString))
        {
            newTitle = inputString;
            validString = true;
        }
        else
        {
            Console.WriteLine("Sorry, but that's not a valid title, try again?\nPress any key to try again.");
            Console.ReadKey(true);
        }
    }

    string newDescription = "";
    validString = false;
    while (!validString)
    {
        Console.Clear();
        Console.WriteLine("What should the new task's description be?");
        string inputString = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(inputString))
        {
            newDescription = inputString;
            validString = true;
        }
        else
        {
            Console.WriteLine("Sorry, but that's not a valid description, try again?\nPress any key to try again.");
            Console.ReadKey(true);
        }
    }

    taskList.Add(new Task(taskList.Count + 1, newTitle, newDescription));
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

// Method for collecting a valid input ID, searching for the task associated with that ID
// Either writes the task and it's description or toggles it's completion status
static void TaskOperation(string tableHeader, bool wantsDescription, List<Task> taskList)
{
    int targetID;
    // Make sure we get a good ID before continuing
    while (!int.TryParse(Console.ReadLine(), out targetID))
        Console.Write("Please enter a valid task ID number: ");

    // Displays the task and description or tells the user the ID wasn't found.
    if (TryFindTaskbyID(targetID, taskList, out Task? task) && task != null)
    {
        // If we're after the Description of the task we've found, display the task and the description
        if (wantsDescription)
        {
            Console.Clear();
            Console.WriteLine(tableHeader);
            task.DisplayTask();
            Console.WriteLine($"\n{task.TaskDescription}\n");
        }
        // If we're not after the description, we're trying to flip it's completion status
        else
        {
            task.MarkAsCompleted();
            return; // Skips the required key to progress below
        }
    }
    else
    {
        Console.WriteLine("\nNo task with that ID found.\n");
    }
    Console.WriteLine("\nPress any key to return to the task list.");
    Console.ReadKey();
}

// Class
public class Task
{
    // Data members for a Task, default strings for non-nullable fields
    private int _taskID;
    private string _taskTitle = "new task title";
    private string _taskDescription = "new task description";
    private bool _taskComplete = false;

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

    // Constructors
    public Task() {}
    public Task(int taskID, string title, string description)
    {
        _taskID = taskID;
        _taskTitle = title;
        _taskDescription = description;
        _taskComplete = false;
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