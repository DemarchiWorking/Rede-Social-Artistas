using System.Collections.Generic;

namespace ArtCulture.Models
{
    public class Resposta<T>
    {
        public string Titulo { get; set; }
        public int Status { get; set; }
        public IEnumerable<T> Resultado { get; set; }
            

    }
}
