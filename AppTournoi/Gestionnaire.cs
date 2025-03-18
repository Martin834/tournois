using System;
using BddtournoiContext;

namespace AppTournoi
{
    internal class Gestionnaire
    {
        public string Login { get; internal set; }
        public string MotDpass { get; internal set; }
        public int IdGestionnaire { get; internal set; }

        internal BddtournoiContext.Gestionnairesappli ToBddGestionnaire()
        {
            return new BddtournoiContext.Gestionnairesappli
            {
                Login = Login,
                MotDpass = MotDpass
            };
        }

        public static implicit operator Gestionnaire(GestionGestionnaire.Gestionnaire v)
        {
            throw new NotImplementedException();
        }
    }
}