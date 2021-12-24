class Jugador
{
    public string nombre { get; set; }
    public int camiseta { get; set; }
    public string deporte { get; set; }
    public string id { get; set; }
    public int cantidad { get; set; }

    public Jugador(string nombre, int camiseta, string deporte, string id)
    {
        this.nombre=nombre;
        this.camiseta=camiseta;
        this.deporte=deporte;
        this.id=id;
        this.cantidad=1;
    }

    public void getDatosJugador()
    {
        Console.WriteLine("NOMBRE DEL JUGADOR :"+nombre+"\nNUMERO DE CAMISETA:"+camiseta+ "\nDEPORTE QUE PRACTICA: "+deporte+" \nID: "+id+"\n");
    }

    public void buscarJugador(string dep)
    {
        
    }
}
