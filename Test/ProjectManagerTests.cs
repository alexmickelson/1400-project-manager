global using ProjectTuple = (string Title, bool IsComplete);
global using ProjectItemTuple = (string ProjectTitle, string Task, bool IsComplete);

using Shared;

namespace Test;

public class ProjectManagerTests
{
    [Fact]
    public void CanAddAProject()
    {
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        List<ProjectTuple> expectedProjects = new List<ProjectTuple>()
        {
            new ProjectTuple("Test project", false)
        };

        Assert.Equal(expectedProjects, ProjectManager.Projects);
    }

    [Fact]
    public void CanRemoveAProject()
    {
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");


        ProjectManager.RemoveProject("Test project");

        List<ProjectTuple> expectedProjects = new List<ProjectTuple>() { };

        Assert.Equal(expectedProjects, ProjectManager.Projects);
    }

    [Fact]
    public void CanGetProjectListView()
    {
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        string projectView = ProjectManager.GetProjectView();

        string expectedView = "[ ] Test project";
        Assert.Equal(expectedView, projectView);
    }

    [Fact]
    public void CanMarkProjectComplete()
    {
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        //act
        ProjectManager.MarkProjectComplete("Test project");


        string projectView = ProjectManager.GetProjectView();
        string expectedView = "[X] Test project";
        Assert.Equal(expectedView, projectView);
    }

    [Fact]
    public void CannotAddTwoProjectsWithSameTitle()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        try
        {
            // act
            ProjectManager.AddProject("Test project");

            // assert
            Assert.Fail("Should throw exception while adding duplicate project");
        }
        catch(InvalidOperationException)
        {
            // assert
            Assert.True(true, "If we made it here, we correctly threw an exception");
        }
    }

    [Fact]
    public void CanAddItemToProject()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        // act
        ProjectManager.AddTaskToProject("Test project", "first test task");

        // assert
        List<ProjectItemTuple> expected = new List<ProjectItemTuple>()
        {
            new ProjectItemTuple("Test project", "first test task", false),
        };
        Assert.Equal(expected, ProjectManager.ProjectItems);
    }

    [Fact]
    public void CanAddMultipleUniqueItemsToProject()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");

        // act
        ProjectManager.AddTaskToProject("Test project", "first test task");
        ProjectManager.AddTaskToProject("Test project", "second test task");

        // assert
        List<ProjectItemTuple> expected = new List<ProjectItemTuple>()
        {
            new ProjectItemTuple("Test project", "first test task", false),
            new ProjectItemTuple("Test project", "second test task", false),
        };
        Assert.Equal(expected, ProjectManager.ProjectItems);
    }

    [Fact]
    public void CannotAddDuplicateItems()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");
        ProjectManager.AddTaskToProject("Test project", "first test task");
        try
        {
            // act
            // adding same task a second time, this is invalid
            ProjectManager.AddTaskToProject("Test project", "first test task");

            // assert
            Assert.Fail("Should throw exception while adding duplicate project");
        }
        catch(InvalidOperationException)
        {
            // assert
            Assert.True(true, "If we made it here, we correctly threw an exception");
        }
    }

    [Fact]
    public void CanMarkItemComplete()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");
        ProjectManager.AddTaskToProject("Test project", "first test task");

        // act
        ProjectManager.MarkItemComplete("Test project", "first test task");

        // assert
        List<ProjectItemTuple> expected = new List<ProjectItemTuple>()
        {
            new ProjectItemTuple("Test project", "first test task", true),
        };
        Assert.Equal(expected, ProjectManager.ProjectItems);
    }

    [Fact]
    public void CanGetProjectItemView()
    {
        // arrange
        ProjectManager.Reset();
        ProjectManager.AddProject("Test project");
        ProjectManager.AddTaskToProject("Test project", "first test task");
        ProjectManager.AddTaskToProject("Test project", "second test task");
        ProjectManager.MarkItemComplete("Test project", "second test task");

        // act
        string itemView = ProjectManager.GetProjectItemView("Test project");

        // assert
        Assert.Contains("[ ] first test task", itemView);
        Assert.Contains("[X] first test task", itemView);
    }
}