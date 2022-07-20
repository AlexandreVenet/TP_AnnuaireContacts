using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_AnnuaireContacts.Helpers;

namespace TP_AnnuaireContacts.ClassesDonnees
{
	internal class Contact : Personne
	{
		#region Fields

		private Adresse _adresse;
		private string _telephone;
		private string _email;

		#endregion



		#region Properties

		internal Adresse p_adresse { get => _adresse; set => _adresse = value; }
		public string p_telephone 
		{ 
			get => _telephone; 
			set
			{
				if (!MyRegEx.IsPhone(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_telephone = MyRegEx.FormatPhone(value);
				}
				
			}
		}
		public string p_email 
		{ 
			get => _email; 
			set
			{
				if (!MyRegEx.IsEmail(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_email = value;
				}
			}
		}

		#endregion



		#region Constructors

		public Contact()
		{
			p_adresse = new Adresse();
		}

		public Contact(string firstName, string lastName, DateOnly birthDate, Adresse adresse, string telephone, string email) 
			: base(firstName, lastName, birthDate)
		{
			p_adresse = adresse;
			p_telephone = telephone;
			p_email = email;
		}

		#endregion



		#region Object overrides

		public override string ToString()
		{
			return $@"Contact :
   id :		{p_id}
   firstName :	{p_firstName}
   lastName :	{p_lastName}
   birthDate :	{p_birthDate}
   adresse :	{p_adresse.p_numero} rue {p_adresse.p_rue} {p_adresse.p_codePostal} {p_adresse.p_ville} {p_adresse.p_pays}
   telephone : {p_telephone}
   email :	{p_email}";
		}

		#endregion
	}
}
