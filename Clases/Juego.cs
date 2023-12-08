namespace Tarea.Clases
{
    public class Juego
    {

        public Juego() { }

        public int Id_Juego { get; set; }
        public int Serial_Number { get; set; }
        public int Anio_Publicacion { get; set; }
        public string Casa_Fabricante { get; set; }
        public List<TipoDeJuego> Tipo_De_Juego { get; set; }
    }
}
