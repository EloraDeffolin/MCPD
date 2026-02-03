using System;

public class User
{
    public object NomComplet { get; internal set; }

    public class User()
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Adresse Adresse { get; set; }

        public User(string nom, string prenom, Adresse adresse)
        {
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
        }

        public override string ToString()
        {
            return $"Le prénom {Prenom} , le nom {Nom.ToUpper()} est l'adresse : {Adresse} .";
        }

        public string NomComplet => $"Prénom : {Prenom} et nom : {Nom}";
    }

}
