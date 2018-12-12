using System.Collections.Generic;

namespace ModisAPI.Models
{
    public class ViewModelStudente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public List<Corso> Corsi { get; set; } = new List<Corso>();

    }
}