global using ProjectTuple = (string Title, bool IsComplete);
global using ProjectItemTuple = (string ProjectTitle, string Task, bool IsComplete);

using Shared;

public static class UserInterfaceFunctions
{
  public static void AddNewProject()
  {
    Console.WriteLine("Input the name of your project:");
    string input = Console.ReadLine();
    try
    {
      ProjectManager.AddProject(input);
    }
    catch
    {
      Console.WriteLine("That was invalid, please try again");
      AddNewProject();
    }
  }

  public static void RemoveProject()
  {
    Console.WriteLine("Input the name of the project to remove:");
    string input = Console.ReadLine();
    try
    {
      ProjectManager.RemoveProject(input);
    }
    catch
    {
      Console.WriteLine("That was invalid, please try again");
      RemoveProject();
    }
  }

  public static void ViewProjectList()
  {
    string projectView = ProjectManager.GetProjectView();
    Console.WriteLine(projectView);
  }

  public static void ManageProjectTasksMenu()
  {

    Console.WriteLine("Input the name of the project to manage:");
    string projectInput = Console.ReadLine();

    Console.WriteLine(ProjectManager.GetProjectItemView(projectInput));
    

    string projectTaskMenu = @"
What would you like to do?
1. Add a Task
2. Delete a Task
3. Mark a Task as complete
4. Return to the Project Menu";
    Console.WriteLine(projectTaskMenu);

    var userMenuChoice = Console.ReadLine();
    switch (userMenuChoice)
    {
      case "1":
        AddTaskToProject(projectInput);
        break;
      case "2":
        DeleteTaskFromProject(projectInput);
        break;
      case "3":
        MarkTaskAsComplete(projectInput);
        break;
      case "4":
        return;
      default:
        Console.WriteLine("Invalid option");
        break;
    }
  }

  public static void AddTaskToProject(string projectTitle)
  {
    // TODO
  }
  public static void DeleteTaskFromProject(string projectTitle)
  {
    // TODO
  }
  public static void MarkTaskAsComplete(string projectTitle)
  {
    // TODO
  }
}