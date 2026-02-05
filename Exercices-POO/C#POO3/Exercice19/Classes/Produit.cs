using System;

public class Produit
{
	public class Produit()
	{
		public int Numero { get; set; }
		public string Nom { get; set; }
		public decimal PrixUnitaire { get; set; }
		public int Stock { get; private set; }

		public Produit(int numero, string nom, decimal prix, int stockInitial = 0)
		{
			Numero = numero;
			Nom = nom;
			PrixUnitaire = prix;
			Stock = stockInitial;
		}

		public bool RetirerDuStock(int quantite)
		{
			if (quantite <= 0) return false;
			if (Stock < quantite) return false;

			Stock -= quantite;
			return true;
		}

		public void AjouterAuStock(int quantite)
		{
			if (quantite > 0)
				Stock += quantite;
		}

		public override string ToString()
		{
			return $"Le numéro : {Numero} | Le nom : {Nom} | Le prix unitaire : {PrixUnitaire} € | Le stock : {Stock}";
		}

	}
}
