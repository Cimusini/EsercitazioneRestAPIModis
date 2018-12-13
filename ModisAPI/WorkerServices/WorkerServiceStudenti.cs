using Microsoft.EntityFrameworkCore;
using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.WorkerServices
{

    public class WorkerServiceSQLServerDB : IWorkerServiceStudenti
    {
        private ModisContext db;

        public WorkerServiceSQLServerDB(ModisContext _db)
        {
            db = _db;
        }

        public void CreaStudente(Studente studente)
        {
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void CancellaStudente(int id)
        {
            db.Entry(RestituisciStudente(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            /*var studente = db.Studenti.Find(studenteModificato.Id);
            studente.Nome = studenteModificato.Nome;
            studente.Cognome = studenteModificato.Cognome;
            studente.Indirizzo = studenteModificato.Indirizzo; equivale alla riga di codice d.entry*/

            db.Entry(studenteModificato).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }

        public List<ViewModelStudente> RestituisciListaStudenti()
        {
            return db.Studenti.Include("Corsi").
            Select(y => new ViewModelStudente
            {
                Id = y.Id,
                NomeCompleto = y.Nome + " " + y.Cognome,
                Corsi = y.StudenteCorsi.Select(
                    z => new Corso
                    {
                        CorsoId = z.Corso.CorsoId,
                        Nome = z.Corso.Nome,
                        DataInizio = z.Corso.DataInizio,
                        NumeroMassimoPartecipanti = z.Corso.NumeroMassimoPartecipanti
                    }).ToList()
            }).ToList();
        }

        public Studente RestituisciStudente(int id)
        {
            //return db.Studenti.Find(id); se siamo sicuri sia una chiave 
            return db.Studenti.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
