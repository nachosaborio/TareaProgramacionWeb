namespace Tarea.Models
{
    public class Videojuego
    {
        public int IdJuego { get; set; }
        public string SerialNumber { get; set; }
        public int AnnoDePublicacion { get; set; }
        public string CasaFabricante { get; set; }
        public List<TipoDeJuego> TiposDeJuego { get; set; }
    }
}
