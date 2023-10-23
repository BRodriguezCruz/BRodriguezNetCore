// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("Por favor selecciona la opcion que requieres: ");
Console.WriteLine(" 1) Mostrar Lista de registros");
Console.WriteLine(" 2) Mostrar receta especifica");
Console.WriteLine(" 3) Ingresar nuevo usuario");
Console.WriteLine(" 4) Editar usuario");
Console.WriteLine(" 5) Eliminar usuario");
Console.WriteLine(" Presione ENTER despues de ingresar el numero de consulta");
int x = int.Parse(Console.ReadLine());

switch (x)
{
    case 1:
        PL.Receta.GetAll();
        Console.ReadKey();
        break;

    case 2:
        PL.Receta.GetById();
        Console.ReadKey();
        break;
    
    case 3:
        PL.Receta.Add();
        Console.ReadKey();
        break;
    
        case 4:
            PL.Receta.Update();
            Console.ReadKey();
            break;

        case 5:
            PL.Receta.Delete();
            Console.ReadKey();
            break;
    
    default:
        Console.WriteLine("No existe esta opcion");
        break;
}
*/
//----------------------------------------------------------------------------------------------------------------------------

Console.WriteLine("Por favor selecciona la opcion que requieres: ");
Console.WriteLine(" 1) CONSULTAR RECETAS");
Console.WriteLine(" 2) CONSULTAR PACIENTES");
Console.WriteLine(" Presione ENTER despues de ingresar el numero de consulta");
int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.WriteLine("Por favor selecciona la opcion que requieres: ");
        Console.WriteLine(" 1) Mostrar Lista de registros");
        Console.WriteLine(" 2) Mostrar receta especifica");
        Console.WriteLine(" 3) Ingresar nueva receta");
        Console.WriteLine(" 4) Editar receta");
        Console.WriteLine(" 5) Eliminar receta");
        Console.WriteLine(" Presione ENTER despues de ingresar el numero de consulta");
        int x = int.Parse(Console.ReadLine());

        switch (x)
        {
            case 1:
                PL.Receta.GetAll();
                Console.ReadKey();
                break;

            case 2:
                PL.Receta.GetById();
                Console.ReadKey();
                break;

            case 3:
                PL.Receta.Add();
                Console.ReadKey();
                break;

            case 4:
                PL.Receta.Update();
                Console.ReadKey();
                break;

            case 5:
                PL.Receta.Delete();
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("No existe esta opcion");
                break;
        }
        Console.ReadKey();
        break;

    case 2:
        
        Console.ReadKey();
        break;

    default:
        Console.WriteLine("No existe esta opcion");
        break;
}
