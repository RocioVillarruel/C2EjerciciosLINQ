using System;
using System.Collections.Generic;
using System.Linq;
public class program{
static void Main(string[] args)
{
    List<Jugador> jugadores=new List<Jugador> ();
    jugadores.Add(new Jugador("estrada", 2, "Basquet", "123"));
    jugadores.Add(new Jugador("ayala", 3, "Basquet", "23"));
    jugadores.Add(new Jugador("becerra", 4, "Basquet", "12334"));
    jugadores.Add(new Jugador("ponce", 5, "futbol", "44"));
    jugadores.Add(new Jugador("gatica", 8, "futbol", "5"));
    jugadores.Add(new Jugador("bustos", 3, "voley", "7"));
    int seleccion=0, selec2=0;
        do{
            Console.WriteLine("INGRESE UNA OPCION \n1-INGRESAR JUGADOR. \n2-MOSTRAR TODOS LOS JUGADORES INGRESADOS. \n3-OPERACIONES \n4-Salir");
            seleccion = Convert.ToInt32(Console.ReadLine());
        switch(seleccion)
            {
                case 1: cargarJugadores(jugadores);
                        break;
                case 2: mostrarJugadores(jugadores);
                        break;
                case 3: do
                            {
                                Console.WriteLine   ("INGRESE UNA OPCION \n1-ORDENAR ALFABETICAMENTE \n2-MOSTRAR CUANTOS JUGADORES HAY DE CADA DEPORTE \n3-BUSCAR JUGADOR POR ID \n4-VOLVER ");
                                selec2 = Convert.ToInt32(Console.ReadLine());
                                switch (selec2)
                                {
                                    case 1: ordenarJugadores(jugadores);
                                            break;
                                    case 2: agrupar(jugadores);
                                            break;
                                    case 3: buscarJugador(jugadores);
                                            break;
                                    default:
                                            break;
                                }
                            }while(selec2!=4);
                        break;
                default:
                        break;
            }}while(seleccion!=4);

}
static void cargarJugadores(List<Jugador> n)
    {
        Console.WriteLine("*******CARGAR JUGADOR*******\n");
        Console.WriteLine("INGRESE APELLIDO DEL JUGADOR:");
        string nombre= Console.ReadLine();
        Console.WriteLine("INGRESE NUMERO DE CAMISETA:");
        int camiseta= Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("INGRESE DEPORTE QUE PRACTICA:");
        string deporte= Console.ReadLine();
        Console.WriteLine("INGRESE ID DEL JUGADOR:");
        string id= Console.ReadLine();
        Console.WriteLine("\n");
        n.Add(new Jugador(nombre,camiseta,deporte,id));
    }

static void buscarJugador(List<Jugador> jugadores)
{
    Console.WriteLine("*******BUSCAR JUGADOR*******\n");
    Console.WriteLine("INGRESE ID DEL JUGADOR A BUSCAR :");
    string buscar=Console.ReadLine();
    IEnumerable<Jugador> jugador = from n in jugadores
                                    where n.id==buscar 
                                    select n;
    if (! jugador.Any()) //si no devuelve nada entonces no existe tal id
    {
        Console.WriteLine("EL ID INGRESADO NO PERTENECE A NINGUN JUGADOR .");   
    }
    else{
    foreach(Jugador n1 in jugador)
    {
        n1.getDatosJugador();
    }
    }
}

static void mostrarJugadores(List<Jugador> jugadores)
{
    Console.WriteLine("*******JUGADORES*******\n");
    foreach(Jugador n in jugadores)
    {
        n.getDatosJugador();
    }
}

static void ordenarJugadores(List<Jugador> jugadores)
{
    Console.WriteLine("*******JUGADORES ORDENADOS ALFABETICAMENTE*******\n");
    IEnumerable<Jugador> jugador = jugadores.OrderBy(n=>n.nombre).ToList(); //ordena alfabeticamente
    foreach(Jugador n1 in jugador)
    {
        n1.getDatosJugador();
    }
}

static void agrupar(List<Jugador> jugadores)
{
    var totalJ = from n in jugadores group n by n.deporte into totals select new //agrupa dependiendo el deporte y muestra cuantos hay de cada uno 
{
    deporte = totals.Key,
    Total=totals.Sum(c=>c.cantidad)
};

foreach (var total in totalJ)
{
    Console.WriteLine("******DEPORTE Y CANTIDAD DE JUGADORES******");
    Console.WriteLine($"{total.deporte} {total.Total}");
}
}

}
