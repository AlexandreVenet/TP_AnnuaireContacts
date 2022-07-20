using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AnnuaireContacts.ClassesIHM
{
	internal class Option
	{
		#region Fields

		private int _id;
		private string _title;
		private Action _action;

		#endregion



		#region Properties

		public int p_id { get => _id; set => _id = value; }
		public string p_title { get => _title; set => _title = value; }
		public Action p_action { get => _action; set => _action = value; }

		#endregion



		#region Constructors

		public Option(int id, string title, Action action = null)
		{
			p_id = id;
			p_title = title;
			_action = action;
		}

		#endregion
	}
}
