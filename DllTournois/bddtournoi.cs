using BddtournoiContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllTournois
{
    public class bddtournoi
    {
        private BddtournoiDataContext bdd;

        public bddtournoi(string user, string mdp, string serveurIp, string port)
        {
            bdd = new BddtournoiDataContext("User Id=" + user + ";Password=" + mdp + ";Host=" + serveurIp + ";Port=" + port + ";Database=bddtournois;Persist Security Info=True");
        }

        public List<Tournoi> GetAllTournois()
        {
            return bdd.Tournois.ToList();
        }

        public List<Sport> GetAllSports()
        {
            return bdd.Sports.ToList();
        }

        public List<string> GetAllTournoisBySport(int sport)
        {
            return bdd.Tournois.Where(t => t.Sport == sport).Select(t => t.Intitule).ToList();
        }

        public List<string> GetAllParticipantsByTournoi(int tournoi)
        {
            return bdd.Participants.Where(p => p.Tournoi == tournoi).Select(p => p.Nom).ToList();
        }

        public List<Participant> GetAllParticipants()
        {
            return bdd.Participants.ToList();
        }

        public Tournoi GetTournoiByName(string name)
        {
            return bdd.Tournois.FirstOrDefault(t => t.Intitule == name);
        }

        public List<Participant> GetParticipantByName(string name)
        {
            return bdd.Participants.Where(p => p.Nom.ToLower().Contains(name.ToLower())).ToList();
        }


        public void AddTournoi(Tournoi tournoi)
        {
            bdd.Tournois.InsertOnSubmit(tournoi);
            bdd.SubmitChanges();
        }

        public void UpdateTournoi(Tournoi tournoi)
        {
            var existingTournoi = bdd.Tournois.SingleOrDefault(t => t.IdTournoi == tournoi.IdTournoi);

            if (existingTournoi != null)
            {
                existingTournoi.Intitule = tournoi.Intitule;
                existingTournoi.DateTournoi = tournoi.DateTournoi;
                existingTournoi.Sport = tournoi.Sport;
                bdd.SubmitChanges();
            }
        }

        public void DeleteTournoi(int idTournoi)
        {
            var tournoi = bdd.Tournois.SingleOrDefault(t => t.IdTournoi == idTournoi);

            if (tournoi != null)
            {
                bdd.Tournois.DeleteOnSubmit(tournoi);
                bdd.SubmitChanges();
            }
        }

        public void AddSport(Sport sport)
        {
            bdd.Sports.InsertOnSubmit(sport);
            bdd.SubmitChanges();
        }

        public void UpdateSport(Sport sport)
        {
            var existingSport = bdd.Sports.SingleOrDefault(s => s.IdSport == sport.IdSport);

            if (existingSport != null)
            {
                existingSport.Intitule = sport.Intitule;
                bdd.SubmitChanges();
            }
        }

        public void DeleteSport(int idSport)
        {
            var sport = bdd.Sports.SingleOrDefault(s => s.IdSport == idSport);

            if(sport != null)
            {
                bdd.Sports.DeleteOnSubmit(sport);
                bdd.SubmitChanges();
            }
        }
    }
}