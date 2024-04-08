global using ProjectTuple = (string Title, bool IsComplete);
global using ProjectItemTuple = (string ProjectTitle, string Task, bool IsComplete);

namespace Data;

public static class Persistence
{
  public static void SaveProjectsToFile(List<ProjectTuple> projects)
  {
    var filePath = GetBasePath() + "projects.txt";

  }
  public static void SaveProjectItemsToFile(List<ProjectItemTuple> projectItems)
  {
    var filePath = GetBasePath() + "projectItems.txt";

  }

  public static List<ProjectTuple> LoadProjectsFromFile()
  {
    var filePath = GetBasePath() + "projects.txt";
    
    // TODO
    return new();
  }

  public static List<ProjectItemTuple> LoadProjectItemsFromFile()
  {
    var filePath = GetBasePath() + "projectItems.txt";

    // TODO
    return new();
  }

  public static string GetBasePath()
  {
    if (Directory.GetCurrentDirectory().Contains("Console"))
      return "../";
    if (Directory.GetCurrentDirectory().Contains("Test"))
      return "../../../../";
    return "./";
  }
}
