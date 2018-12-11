using System;
using System.Collections.Generic;

namespace ModisAPI.Models
{
    public class Corso
    {
        public int CorsoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInizio { get; set; }
        public int DataInOre { get; set; }
        public int Livello { get; set; }
        public int NumeroMassimoPartecipanti { get; set; } //aggiunta dopo
        public IList<StudenteCorso> StudenteCorsi { get; set; }

    }
}
