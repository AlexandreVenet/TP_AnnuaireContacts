using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_AnnuaireContacts.Helpers;

namespace TP_AnnuaireContacts.ClassesDonnees
{
	internal class Adresse
	{
		#region Fields

		private int _numero;
		private string _rue;
		private string _codePostal;
		private string _ville;
		private string _pays;

		#endregion



		#region Properties

		public int p_numero 
		{ 
			get => _numero; 
			set
			{
				if (value < 1)
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_numero = value;
				}
			}
		}
		public string p_rue 
		{ 
			get => _rue;
			set
			{
				if (!MyRegEx.IsLieu(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_rue = value;
				}
			}
		}
		public string p_codePostal 
		{ 
			get => _codePostal; 
			set
			{
				if (!MyRegEx.IsCodePostal(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_codePostal = value;
				}
			}
		}
		public string p_ville 
		{ 
			get => _ville;
			set
			{
				if (!MyRegEx.IsLieu(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_ville = value;
				}
			}
		}
		public string p_pays 
		{ 
			get => _pays;
			set
			{
				if (!MyRegEx.IsLieu(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_pays = value;
				}
			}
		}

		#endregion



		#region Constructors

		public Adresse()
		{

		}

		public Adresse(int numero, string rue, string codePostal, string ville, string pays)
		{
			p_numero = numero;
			p_rue = rue;
			p_codePostal = codePostal;
			p_ville = ville;
			p_pays = pays;
		}

		#endregion



		#region Object overrides

		public override string ToString()
		{
			return $@"
      numero : {p_numero}
      rue : {p_rue}
      codePostal : {p_codePostal}
      ville : {p_ville}
      pays : {p_pays}";
		}

		#endregion
	}
}
