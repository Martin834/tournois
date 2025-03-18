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

        public List<Gestionnairesappli> GetAllGestionnaires()
        {
            return bdd.Gestionnairesapplis.ToList();
        }

        public Tournoi GetTournoiByName(string name)
        {
            return bdd.Tournois.FirstOrDefault(t => t.Intitule == name);
        }

        public Gestionnairesappli GetGestionnaireById(int id)
        {
            return bdd.Gestionnairesapplis.FirstOrDefault(g => g.IdGestionnaire == id);
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

        public void AddParticipant(Participant participant)
        {
            bdd.Participants.InsertOnSubmit(participant);
            bdd.SubmitChanges();
        }

        public void UpdateParticipant(Participant participant)
        {
            var existingParticipant = bdd.Participants.SingleOrDefault(p => p.Id == participant.Id);
            if (existingParticipant != null)
            {
                existingParticipant.Nom = participant.Nom;
                existingParticipant.Prenom = participant.Prenom;
                existingParticipant.DateNaissance = participant.DateNaissance;
                existingParticipant.Sexe = participant.Sexe;
                bdd.SubmitChanges();
            }
        }

        public void DeleteParticipant(int idParticipant)
        {
            var participant = bdd.Participants.SingleOrDefault(p => p.Id == idParticipant);
            if (participant != null)
            {
                bdd.Participants.DeleteOnSubmit(participant);
                bdd.SubmitChanges();
            }
        }


        public void AddGestionnaire(Gestionnairesappli gestionnaireAppli)
        {
            bdd.Gestionnairesapplis.InsertOnSubmit(gestionnaireAppli);
            bdd.SubmitChanges();
        }

        public void UpdateGestionnaire(Gestionnairesappli gestionnaireAppli)
        {
            var existingGestionnaire = bdd.Gestionnairesapplis.SingleOrDefault(s => s.IdGestionnaire == gestionnaireAppli.IdGestionnaire);

            if (existingGestionnaire != null)
            {
                existingGestionnaire.Login = gestionnaireAppli.Login;
                bdd.SubmitChanges();
            }
        }

        public void DeleteGestionnaire(int idGestionnaire)
        {
            var gestionnaire = bdd.Gestionnairesapplis.SingleOrDefault(s => s.IdGestionnaire == idGestionnaire);

            if (gestionnaire != null)
            {
                bdd.Gestionnairesapplis.DeleteOnSubmit(gestionnaire);
                bdd.SubmitChanges();
            }
        }
    }
}