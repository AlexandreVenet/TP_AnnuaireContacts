using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_AnnuaireContacts.Helpers;

namespace TP_AnnuaireContacts.ClassesDonnees
{
	internal class Personne
	{
		#region Fields

		private int _id;
		private string _firstName;
		private string _lastName;
		private DateOnly _birthDate;

		#endregion



		#region Properties

		public int p_id 
		{ 
			get => _id; 
			set
			{
				if(value < 0)
				{
					throw new ArgumentOutOfRangeException("Valeur non prise en charge");	
				}
				else
				{
					_id = value;
				}
			}
		}
		public string p_firstName 
		{ 
			get => _firstName; 
			set
			{
				if(!MyRegEx.IsName(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_firstName = value;
				}
			}
		}
		public string p_lastName 
		{ 
			get => _lastName;
			set
			{
				if (!MyRegEx.IsName(value))
				{
					throw new FormatException("Erreur de format");
				}
				else
				{
					_lastName = value;
				}
			}
		}
		public DateOnly p_birthDate 
		{ 
			get => _birthDate; 
			set
			{
				if(value.Year < 1900 || value > DateOnly.FromDateTime(DateTime.Now))
				{
					throw new FormatException("Date incorrecte");
				}
				else
				{
					_birthDate = value;
				}
			}
		}

		#endregion



		#region Constructors

		public Personne()
		{

		}

		public Personne(string firstName, string lastName, DateOnly birthDate)
		{
			p_firstName = firstName;
			p_lastName = lastName;
			p_birthDate = birthDate;
		}

		#endregion
	}
}
