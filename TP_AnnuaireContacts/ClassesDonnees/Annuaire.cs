using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AnnuaireContacts.ClassesDonnees
{
	internal class Annuaire
	{
		#region Fields

		private List<Contact> _contacts;

		#endregion



		#region Properties

		internal List<Contact> p_contacts { get => _contacts; set => _contacts = value; }

		#endregion



		#region Constructors

		public Annuaire()
		{
			p_contacts = new List<Contact>();

			// ajouter un élément dans la liste dès le départ
			Contact x = new("Toto", "Zéro", new(1900, 1, 1), new(1, "Rue", "01000", "Ville", "Pays"), "0600000000", "to@to.to");
			p_contacts.Add(x);
		}

		#endregion
	}
}
