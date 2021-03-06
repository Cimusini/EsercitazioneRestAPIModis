﻿using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.WorkerServices
{

    public class WorkerServiceSQLServerDB : IWorkerServiceStudenti
    {
        private ModisContext db;

        public WorkerServiceSQLServerDB()
        {
            db = new ModisContext();
        }

        public void CreaStudente(Studente studente)
        {
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void EliminaStudente(int id)
        {
            var studente = db.Studenti.Find(id);
            db.Studenti.Remove(studente);
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

        public List<Studente> RestituisciListaStudenti()
        {
            return db.Studenti.ToList();
        }

        public Studente RestituisciStudente(int id)
        {

            //return db.Studenti.Find(id); se siamo sicuri sia una chiave 
            return db.Studenti.Where(x => x.Id == id).FirstOrDefault();
        }
    }

    public class WorkerServiceStudenti : IWorkerServiceStudenti
    {
        public void CreaStudente(Studente studente)
        {
            throw new NotImplementedException();
        }

        public void EliminaStudente(int id)
        {
            throw new NotImplementedException();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            throw new NotImplementedException();
        }

        public List<Studente> RestituisciListaStudenti()
        {
            var studente1 = new Studente { Id = 1, Cognome = "Mario", Nome = "Rossi" };
            var studente2 = new Studente { Id = 2, Cognome = "MastroCesare", Nome = "Francesco" };
            return new List<Studente> { studente1, studente2 };
        }

        public Studente RestituisciStudente(int id)
        {
            return RestituisciListaStudenti().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
