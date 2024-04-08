using Data;
using Shared;


namespace Test;
public class PersistenceTests
{
  [Fact]
  public void CanStoreProjects()
  {
    ProjectManager.Reset();
    ProjectManager.AddProject("Test project");
    ProjectManager.AddProject("second Test project");

    // act
    ProjectManager.SaveStateToDisk();

    var filePath = Persistence.GetBasePath() + "projects.txt";

    var fileContents = File.ReadAllText(filePath);
    Assert.Contains("Test project", fileContents);
    Assert.Contains("second Test project", fileContents);
  }

  [Fact]
  public void CanLoadStoredProjects()
  {
    ProjectManager.Reset();
    ProjectManager.AddProject("Test project");
    ProjectManager.AddProject("second Test project");
    ProjectManager.MarkProjectComplete("second Test project");
    ProjectManager.SaveStateToDisk();

    // act
    ProjectManager.LoadStateFromDisk();


    List<ProjectTuple> expectedProjects = new List<ProjectTuple>()
    {
      new ProjectTuple("Test project", false),
      new ProjectTuple("second Test project", true)
    };

    Assert.Equal(expectedProjects, ProjectManager.Projects);
  }

  [Fact]
  public void CanStoreItems()
  {
    // arrange
    ProjectManager.Reset();
    ProjectManager.AddProject("Test project");
    ProjectManager.AddTaskToProject("Test project", "first test task");
    ProjectManager.AddTaskToProject("Test project", "second test task");

    // act
    ProjectManager.SaveStateToDisk();

    // assert
    var filePath = Persistence.GetBasePath() + "projectItems.txt";
    var fileContents = File.ReadAllText(filePath);
    Assert.Contains("first test task", fileContents);
    Assert.Contains("second test task", fileContents);
  }

  [Fact]
  public void CanLoadItems()
  {
    // arrange
    ProjectManager.Reset();
    ProjectManager.AddProject("Test project");
    ProjectManager.AddTaskToProject("Test project", "first test task");
    ProjectManager.AddTaskToProject("Test project", "second test task");
    ProjectManager.SaveStateToDisk();

    // act
    ProjectManager.LoadStateFromDisk();

    // assert
    List<ProjectItemTuple> expected = new List<ProjectItemTuple>()
    {
      new ProjectItemTuple("Test project", "first test task", true),
      new ProjectItemTuple("Test project", "second test task", true),
    };
    Assert.Equal(expected, ProjectManager.ProjectItems);
  }
}