string menuText = @"

Welcome to your project manager. Please select an option
    1. Add a Project
    2. Remove a Project
    3. Mark Project Complete
    4. Manage Project Tasks
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
      UserInterfaceFunctions.MarkProjectComplete();
      break;
    case "4":
      UserInterfaceFunctions.ManageProjectTasksMenu();
      break;
    default:
      Console.WriteLine("Invalid option");
      break;
  }
}
