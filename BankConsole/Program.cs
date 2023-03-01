// See https://aka.ms/new-console-template for more information
using BankConsole;

/*
//Creo Objeto accediendo al Constructor de la clase
User james = new User();
james.ID =1;
james.Name = "James";
james.Email = "james@gmail.com";
//james.Balance = 1000;
james.RegisterDate = DateTime.Now;
*/
/*
User james = new User(1,"James","james@gmail.com", 1000);

Console.WriteLine(james.ShowData());

//llamado clase static
//Storage.AddUser(james);

User pedro = new User(2,"Pedro", "pedro@gmail.com",2500);

pedro.SetBalance(-20);

System.Console.WriteLine(pedro.ShowData());

System.Console.WriteLine(pedro.ShowData("Que mas viejo"));

Client daniel = new Client(1, "Daniel", "daniel@gmail.com", 1000, 'M');

Console.WriteLine(daniel.ShowData());
daniel.SetBalance(2000);
Console.WriteLine(daniel.ShowData());

Employee luis = new Employee(1, "Luis", "luis@gmail.com", 2000, "IT");

Console.WriteLine(luis.ShowData());
luis.SetBalance(2000);
Console.WriteLine(luis.ShowData());


Storage.AddUser(daniel);
Storage.AddUser(luis);
*/
if (args.Length == 0)
    //EmailService.SenMail();
    ShowMenu();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opción: ");
    Console.WriteLine("1 -  Crear un Usuario nuevo. ");
    Console.WriteLine("2 -  Eliminar Usuario Existente. ");
    Console.WriteLine("3 - Salir. ");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if (!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un numero (1, 2 o 3).");
        else if (option > 3)
            Console.WriteLine("Debes ingresar un numero valido (1, 2 o 3)");
    }
    while (option == 0 || option > 3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
}

void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Ingresar la informaicon del usuario:");

    Console.Write("ID: ");
    int ID = int.Parse(Console.ReadLine());
    Console.Write("Nombre: ");
    string name = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();
    Console.Write("Saldo: ");
    int balance = int.Parse(Console.ReadLine());

    Console.Write("Escribe 'c' si el usuario es Cliente, 'e' si el usuario en Empleado: ");
    char userType = char.Parse(Console.ReadLine());

    User newUser;

    if (userType.Equals('c'))
    {
        Console.Write("Regimen Fiscal: ");
        char taxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, email, balance, taxRegime);
    }
    else
    {
        Console.Write("Departamento: ");
        string department = Console.ReadLine();

        newUser = new Employee(ID, name, email, balance, department);
    }

    Storage.AddUser(newUser);

    Console.WriteLine("Usuario creado");
    Thread.Sleep(2000);
    ShowMenu();


}

void DeleteUser()
{
    Console.Clear();

    Console.Write("Ingresa el ID del usuaro a  eliminar: ");
    int ID = int.Parse(Console.ReadLine());

    string result = Storage.DeleteUser(ID);

    if(result.Equals("Success"))
    {
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    }else
    {
        Console.Write(result);
        Thread.Sleep(2000);
        ShowMenu();
    }
}