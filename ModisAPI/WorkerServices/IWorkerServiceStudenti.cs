using System.Collections.Generic;
using ModisAPI.Models;

namespace ModisAPI.WorkerServices
{
    public interface IWorkerServiceStudenti
    {
        List<ViewModelStudente> RestituisciListaStudenti();
        Studente RestituisciStudente(int id);
        void CreaStudente(Studente studente);
        void ModificaStudente(Studente studenteModificato);
        void CancellaStudente(int id);
    }
}