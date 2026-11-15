
List<double> Precio = new List<double>();
List<string> Producto = new List<string>();  //lo primero que hago es crear las lista, producto tipo string, y precio tipo double

int opcion = 0;

do
{
    Console.WriteLine("Tienda de juanito");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Mostrar productos ");
    Console.WriteLine("3. Buscar productos ");
    Console.WriteLine("4. Modificar producto");
    Console.WriteLine("5. Eliminar un producto");
    Console.WriteLine("6. Mostrar, total,mayor,menor,y promedio");   // este es el menu
    Console.WriteLine("7. Ordenar lista");
    Console.WriteLine("0. Termine");
    Console.WriteLine("Elige una opcion");

    int.TryParse(Console.ReadLine(), out opcion);


    switch (opcion)
    {
        case 1:
            Agregar(Producto, Precio);
            break;

        case 2:
            Mostrar(Producto, Precio);      //los casos aqui se llaman a los metodos que estan abajo
            break;

        case 3:
            Buscar(Producto, Precio);
            break;

        case 4:
            Modificar(Producto, Precio);
            break;

        case 5:
            Eliminar(Producto, Precio);
            break;

        case 6:
            Estadisticas(Producto, Precio);
            break;


        case 7:
            Ordenar(Producto, Precio);
            break;

        default:
            Console.WriteLine("opcion incorrecta");
            break;


    }


} while (opcion != 0);


//aqui empiezo con los metodos

static void Agregar(List<string> Producto, List<double> Precio) //agregar
{
    Console.Write("Nombre del producto: ");
    string nombre = Console.ReadLine();

    Console.Write("Precio del producto: ");
    double precio = double.Parse(Console.ReadLine());

    if (precio < 0 || nombre == "")
    {
        Console.WriteLine("Invalido");
    }
    else
    {
        Producto.Add(nombre);
        Precio.Add(precio);
        Console.WriteLine("Producto agregado");
    }
}


static void Mostrar(List<string> Producto, List<double> Precio) //mostrar producto
{
    if (Producto.Count == 0)
    {
        Console.WriteLine("no hay productos");
    }
    else
    {
        for (int i = 0; i < Producto.Count; i++)
        {
            Console.WriteLine(Producto[i] + " - RD$" + Precio[i]);
        }
    }
}

static void Buscar(List<string> Producto, List<double> Precio) //buscar
{
    Console.Write("Ingrese el producto que desea buscar: ");
    string nombre = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < Producto.Count; i++)
    {
        if (Producto[i] == nombre)
        {
            Console.WriteLine("Producto: " + Producto[i]);
            Console.WriteLine("Precio: " + Precio[i]);

            encontrado = true;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Producto no encontrado.");
    }
}

static void Modificar(List<string> Producto, List<double> Precio) //modificar
{
    Console.Write("Ingrese el producto a modificar: ");
    string nombre = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < Producto.Count; i++)
    {
        if (Producto[i] == nombre)
        {
            Console.Write("Nuevo nombre: ");
            string NuevoNombre = Console.ReadLine();

            Console.Write("Nuevo precio: ");
            double NuevoPrecio = double.Parse(Console.ReadLine());

            if (NuevoPrecio < 0 || NuevoNombre == "")
            {
                Console.WriteLine("Invalido");
            }
            else
            {
                Producto[i] = NuevoNombre;
                Precio[i] = NuevoPrecio;

                Console.WriteLine("Producto modificado");
                break;
            }
            encontrado = true;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Producto no encontrado");
    }
}

static void Eliminar(List<string> Producto, List<double> Precio) //eliminar
{
    Console.Write("Ingrese el producto a eliminar: ");
    string nombre = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < Producto.Count; i++)
    {
        if (Producto[i] == nombre)
        {
            Producto.RemoveAt(i);
            Precio.RemoveAt(i);

            encontrado = true;

            Console.WriteLine("Producto eliminado");
            break;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Producto no encontrado");
    }
}

static void Estadisticas(List<string> Producto, List<double> Precio) //esto es como un recibo
{
    if (Producto.Count == 0)
    {
        Console.WriteLine("No hay productos registrados");
        return;
    }

    double mayor = Precio[0];
    double menor = Precio[0];
    double suma = 0;

    for (int i = 0; i < Precio.Count; i++)
    {
        if (Precio[i] > mayor)
        {
            mayor = Precio[i];
        }

        if (Precio[i] < menor)
        {
            menor = Precio[i];
        }
    }

    foreach (double p in Precio)
    {
        suma = suma + p;
    }

    double promedio = suma / Precio.Count;

    Console.WriteLine("Cantidad de productos: " + Producto.Count);
    Console.WriteLine("Precio mayor: " + mayor);
    Console.WriteLine("Precio menor: " + menor);
    Console.WriteLine("Precio promedio: " + promedio);
}

static void Ordenar(List<string> Producto, List<double> Precio) //ordenar los productoss
{
    Producto.Sort();

    Console.WriteLine("Productos ordenados:");

    foreach (string p in Producto)
    {
        Console.WriteLine(p);
    }
}