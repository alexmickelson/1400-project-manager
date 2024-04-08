global using ProjectTuple = (string Title, bool IsComplete);
global using ProjectItemTuple = (string ProjectTitle, string Task, bool IsComplete);

namespace Shared;

public static class ProjectManager
{
  public static List<ProjectTuple> Projects = new();
  public static List<ProjectItemTuple> ProjectItems = new();

  public static void AddProject(string title)
  {
    foreach (var project in Projects)
    {
      if (project.Title == title)
      {
        throw new Exception("Cannot add project with duplicate title");
      }
    }

    ProjectTuple newProject = new ProjectTuple();
    newProject.Title = title;
    newProject.IsComplete = false;

    Projects.Add(newProject);
  }

  public static void AddTaskToProject(string projectTitle, string itemTask)
  {
    // TODO
  }

  public static string GetProjectView()
  {
    string output = "Projects: \n";
    foreach (var project in Projects)
    {
      string checkedString = project.IsComplete ? "[X]" : "[ ]";
      output += checkedString + " " + project.Title;
    }
    return output;
  }

  public static void MarkProjectComplete(string title)
  {
    for (int i = 0; i < Projects.Count; i++)
    {
      if (Projects[i].Title == title)
      {
        var updatedProject = new ProjectTuple();
        updatedProject.Title = title;
        updatedProject.IsComplete = true;

        Projects[i] = updatedProject;
      }
    }
  }

  public static void RemoveProject(string title)
  {
    int indexToRemove = -1;
    for (int i = 0; i < Projects.Count; i++)
    {
      if (Projects[i].Title == title)
        indexToRemove = i;
    }

    Projects.RemoveAt(indexToRemove);
  }

  public static void Reset()
  {
    Projects = [];
    ProjectItems = [];
  }

  public static void MarkItemComplete(string projectTitle, string itemTask)
  {
    // TODO
  }
  public static string GetProjectItemView(string projectTitle)
  {
    // TODO
    return "";
  }

  public static void SaveStateToDisk()
  {
    // TODO
  }
  public static void LoadStateFromDisk()
  {
    // TODO
  }
}
