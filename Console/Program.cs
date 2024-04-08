string menuText = @"

Welcome to your project manager. Please select an option
    1. Add a Project
    2. Remove a Project
    3. Manage Project Tasks
";

while (true)
{
  Console.Clear();

  UserInterfaceFunctions.ViewProjectList();
  Console.WriteLine(menuText);

  var userMenuChoice = Console.ReadLine();
  switch (userMenuChoice)
  {
    case "1":
      UserInterfaceFunctions.AddNewProject();
      break;
    case "2":
      UserInterfaceFunctions.RemoveProject();
      break;
    case "3":
      UserInterfaceFunctions.ManageProjectTasksMenu();
      break;
    default:
      Console.WriteLine("Invalid option");
      break;
  }
}
