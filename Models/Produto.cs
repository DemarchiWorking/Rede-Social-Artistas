namespace ArtCulture.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public float Valor { get; set; }
    }
}
