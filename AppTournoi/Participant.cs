using System;

namespace AppTournoi
{
    internal class Participant
    {
        public string Nom { get; internal set; }
        public string Prenom { get; internal set; }
        public DateTime DateNaissance { get; internal set; }
        public string Sexe { get; internal set; }
        public byte[] Photo { get; internal set; }
        public int Tournoi { get; internal set; }

        internal BddtournoiContext.Participant ToBddParticipant()
        {
            return new BddtournoiContext.Participant
            {
                Nom = Nom,
                Prenom = Prenom,
                DateNaissance = DateNaissance,
                Sexe = Sexe,
                Photo = Photo,
                Tournoi = Tournoi
            };
        }
    }
}