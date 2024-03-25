namespace CarGallery.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly Fundacao { get; set; }
        public List<Carro> Carros { get; set; } = new List<Carro>();
    }
}
