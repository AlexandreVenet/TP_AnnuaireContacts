using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_AnnuaireContacts.ClassesDonnees;
using TP_AnnuaireContacts.Helpers;

namespace TP_AnnuaireContacts.ClassesIHM
{
	internal class IHM
	{
		#region Fields

		private State _state;
		private Annuaire _annuaire;
		private bool _isPlaying;
		private int _currentOptionSelected;

		private Option[] _optionsEcranPrincipal;
		private Option[] _optionsAfficher;
		private Option[] _optionsChercher;

		private bool _isContactAdded;

		private bool _hasMadeSearch;
		private Contact _currentSearched;

		private bool _hasDeleted;

		private bool _hasModified;
		private int _modifiedContactIndex;
		private Option[] _optionsModifier;
		private bool _isCurrentlyModifying;
		private Option[] _optionsModifierRetour;
		private int _chosenModif;

		#endregion



		#region Constructors

		public IHM()
		{
			_currentOptionSelected = 0;
			_annuaire = new();
			_isPlaying = true;
			_state = State.EcranPrincipal;

			_optionsEcranPrincipal = new Option[]
			{
				new Option(0, "Afficher les contacts",()=> ChangeState(State.Afficher) ),
				new Option(1, "Ajouter un contact",()=> ChangeStateAndLocker(ref _isContactAdded,State.Ajouter) ),
				// Idem que ceci dans le corps de la fonction anonyme :
				//{
				//	_isContactAdded = false;
				//	ChangeState(State.Ajouter);
				//}),
				new Option(2, "Modifier un contact",()=> ChangeStateAndLocker(ref _hasModified,State.Modifier) ),
				new Option(3, "Supprimer un contact",()=> ChangeStateAndLocker(ref _hasDeleted,State.Supprimer) ),
				new Option(4, "Chercher un contact",()=> ChangeStateAndLocker(ref _hasMadeSearch,State.Chercher) ),
				new Option(5, "Quitter", ()=> ChangeState(State.Quitter) )
			};

			_optionsAfficher = new Option[]
			{
				new Option(0, "Retour",()=> ChangeState(State.EcranPrincipal) ),
			};

			_optionsChercher = new Option[]
			{
				new Option(0, "Nouvelle recherche",()=> ChangeStateAndLocker(ref _hasMadeSearch,State.Chercher) ),
				new Option(1, "Retour",()=> ChangeState(State.EcranPrincipal) ),
			};

			_isContactAdded = false;
			_hasMadeSearch = false;

			_hasDeleted = false;

			_hasModified = false;
			_optionsModifier = new Option[]
			{
				new Option(0, "Prénom", ()=> PropertyToModify(0)),
				new Option(1, "Nom", ()=> PropertyToModify(1)),
				new Option(2, "Date naissance", ()=> PropertyToModify(2)),
				new Option(3, "Adresse numéro", ()=> PropertyToModify(3)),
				new Option(4, "Adresse rue", ()=> PropertyToModify(4)),
				new Option(5, "Adresse code postal", ()=> PropertyToModify(5)),
				new Option(6, "Adresse ville", ()=> PropertyToModify(6)),
				new Option(7, "Adresse pays", ()=> PropertyToModify(7)),
				new Option(8, "Téléphone", ()=> PropertyToModify(8)),
				new Option(9, "Adresse courriel", ()=> PropertyToModify(9)),
				new Option(10, "Retour", ()=>
				{
					_isCurrentlyModifying = false;
					_hasModified = false;
					ChangeState(State.EcranPrincipal);
				}),
			};
			_isCurrentlyModifying = false;
			_optionsModifierRetour = new Option[]
			{
				new Option(0, "Retour", ()=> ChangeStateAndLocker(ref _isCurrentlyModifying,State.Modifier) ),
			};
			_chosenModif = 0;

			GameLoop();
		}

		#endregion



		#region Mini State Machine Methods

		private void ChangeState(State nextState)
		{
			Console.Clear();
			_currentOptionSelected = 0;
			_state = nextState;
		}

		private void ChangeStateAndLocker(ref bool locker, State nextState)
		{
			locker = false;
			ChangeState(nextState);
		}

		private void GameLoop()
		{
			while(_isPlaying)
			{
				switch (_state)
				{
					case State.EcranPrincipal:
						EcranPrincipal();
						break;
					case State.Afficher:
						Afficher();
						break;
					case State.Ajouter:
						Ajouter();
						break;
					case State.Modifier:
						Modifier();
						break;
					case State.Supprimer:
						Supprimer();
						break;
					case State.Chercher:
						Chercher();
						break;
					case State.Quitter:
						Environment.Exit(0);
						break;
					default:
						break;
				}
			}
		}

		private void EcranPrincipal()
		{
			Titre("Annuaire de contacts");
			Console.WriteLine("Bienvenue dans ce programme.");
			MenuOptions(ref _optionsEcranPrincipal);
		}

		private void Afficher()
		{
			Titre(_optionsEcranPrincipal[0].p_title);

			if (_annuaire.p_contacts.Count == 0)
			{
				Console.WriteLine("Annuaire vide");
			}
			else
			{
				for (int i = 0; i < _annuaire.p_contacts.Count; i++)
				{
					string lastChar = "\n";

					if (i == _annuaire.p_contacts.Count - 1)
					{
						lastChar = "";
					}

					Console.WriteLine(_annuaire.p_contacts[i].ToString() + lastChar);
				}
			}

			MenuOptions(ref _optionsAfficher);
		}

		private void Ajouter()
		{
			Titre(_optionsEcranPrincipal[1].p_title);

			if (!_isContactAdded)
			{
				Console.WriteLine("Renseigner les valeurs pour ajouter un contact à l'annuaire.\n");

				Contact newContact = new();

				ConsoleHelper.TextColorDarkYellow("1. Identité\n");

				SetPrenom(ref newContact);
				SetNom(ref newContact);
				SetDate(ref newContact);

				ConsoleHelper.TextColorDarkYellow("\n2. Adresse\n");

				SetAdresseNumero(ref newContact);
				SetAdresseRue(ref newContact);
				SetAdresseCodePostal(ref newContact);
				SetAdresseVille(ref newContact);
				SetAdressePays(ref newContact);

				ConsoleHelper.TextColorDarkYellow("\n3. Contact\n");

				SetTelephone(ref newContact);
				SetCourriel(ref newContact);

				// assigner un nouvel ID sur la base de l'id max de la liste
				int maxId = -1;
				for (int i = 0; i < _annuaire.p_contacts.Count; i++)
				{
					int currentItem = _annuaire.p_contacts[i].p_id;
					if (currentItem > maxId)
					{
						maxId = currentItem;
					}
				}

				try
				{
					newContact.p_id = maxId + 1;
				}
				catch (ArgumentOutOfRangeException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}

				_annuaire.p_contacts.Add(newContact);

				_isContactAdded = true;

				Console.Clear();
			}
			else
			{
				Console.WriteLine("Le contact a été ajouté.");
				MenuOptions(ref _optionsAfficher);
			}

		}

		private void Chercher()
		{
			Titre(_optionsEcranPrincipal[4].p_title);

			if (!_hasMadeSearch)
			{
				_currentSearched = null;
				Console.Write("Chercher le premier contact portant ce nom : ");
				string userStr = Console.ReadLine();
				foreach (var item in _annuaire.p_contacts)
				{
					if (item.p_lastName == userStr)
					{
						_currentSearched = item;
						break;
					}
				}
				_hasMadeSearch = true;
				Console.Clear();
			}
			else
			{
				if(_currentSearched == null)
				{
					Console.WriteLine("Aucun contact trouvé.");
				}
				else
				{
					Console.WriteLine(_currentSearched);
				}
				MenuOptions(ref _optionsChercher);
			}
		}

		private void Supprimer()
		{
			Titre(_optionsEcranPrincipal[3].p_title);

			if(!_hasDeleted)
			{
				_currentSearched = null;
				Console.Write("Supprimer le premier contact portant ce nom : ");
				string userStr = Console.ReadLine();
				foreach (var item in _annuaire.p_contacts)
				{
					if (item.p_lastName == userStr)
					{
						_currentSearched = item;
						_annuaire.p_contacts.Remove(item);
						break;
					}
				}
				_hasDeleted = true;
				Console.Clear();
			}
			else
			{
				if (_currentSearched == null)
				{
					Console.WriteLine("Aucun contact trouvé.");
				}
				else
				{
					Console.WriteLine("Le contact a été supprimé.");
				}
				MenuOptions(ref _optionsAfficher);
			}

		}

		private void Modifier()
		{
			Titre(_optionsEcranPrincipal[2].p_title);

			if(!_hasModified)
			{
				_currentSearched = null;
				if(_annuaire.p_contacts.Count > 0)
				{
					Console.Write("Modifier le premier contact portant ce nom : ");
					string userStr = Console.ReadLine();
					for (int i = 0; i < _annuaire.p_contacts.Count; i++)
					{
						Contact c = _annuaire.p_contacts[i];
						if(c.p_lastName == userStr)
						{
							_currentSearched = c;
							_modifiedContactIndex = i;
							break;
						}
					}
				}
				_hasModified = true;
				Console.Clear();
			}
			else
			{
				if(_annuaire.p_contacts.Count == 0)
				{
					Console.WriteLine("L'annuaire est vide.");
					MenuOptions(ref _optionsAfficher);
				}
				else if (_currentSearched == null)
				{
					Console.WriteLine("Aucun contact trouvé.");
					MenuOptions(ref _optionsAfficher);
				}
				else
				{
					// Ici, procédure de modification
					if (!_isCurrentlyModifying)
					{
						Console.WriteLine($"Modifier le contact à l'id {_currentSearched.p_id} : ");
						MenuOptions(ref _optionsModifier);
					}
					else
					{
						Console.WriteLine($"{_optionsModifier[_chosenModif].p_title} à modifier \n");
						switch (_chosenModif)
						{
							case 0:
								SetPrenom(ref _currentSearched);
								break;
							case 1:
								SetNom(ref _currentSearched);
								break;
							case 2:
								SetDate(ref _currentSearched);
								break;
							case 3:
								SetAdresseNumero(ref _currentSearched);
								break;
							case 4:
								SetAdresseRue(ref _currentSearched);
								break;
							case 5:
								SetAdresseCodePostal(ref _currentSearched);
								break;
							case 6:
								SetAdresseVille(ref _currentSearched);
								break;
							case 7:
								SetAdressePays(ref _currentSearched);
								break;
							case 8:
								SetTelephone(ref _currentSearched);
								break;
							case 9:
								SetCourriel(ref _currentSearched);
								break;
							default:
								break;
						}
						_annuaire.p_contacts[_modifiedContactIndex] = _currentSearched;
						Console.WriteLine($"\nModification effectuée");
						MenuOptions(ref _optionsModifierRetour);
					}
				}
			}
		}

		private void PropertyToModify(int selectedOption)
		{
			_chosenModif = selectedOption;
			_isCurrentlyModifying = true;
			ChangeState(State.Modifier);
		}

		#endregion



		#region Methods UI

		private void Titre(string titre)
		{
			ConsoleHelper.dashType = ConsoleHelper.DashType.SuperEquals;
			ConsoleHelper.LineDarkYellow();
			ConsoleHelper.TextColorYellow(titre);
			ConsoleHelper.LineDarkYellow();
			Console.WriteLine();
		}

		private void MenuOptions(ref Option[] arrayMenuOptions)
		{
			// Afficher 
			Console.WriteLine();
			for (int i = 0; i < arrayMenuOptions.Length; i++)
			{
				string text = "  " + arrayMenuOptions[i].p_title + " ";
				if (i == _currentOptionSelected)
				{
					ConsoleHelper.TextBackgroundDarkYellow(text);
				}
				else
				{
					ConsoleHelper.TextColorYellow(text);
				}
			}

			ConsoleHelper.TextColorDarkGray("\n[HAUT/BAS naviguer] [ENTREE valider]");

			// Touches clavier
			ConsoleKey key = Console.ReadKey().Key;
			if (key == ConsoleKey.DownArrow)
			{
				_currentOptionSelected++;
			}
			else if (key == ConsoleKey.UpArrow)
			{
				_currentOptionSelected--;
			}
			else if (key == ConsoleKey.Enter)
			{
				arrayMenuOptions[_currentOptionSelected].p_action();
				return;
			}

			if (_currentOptionSelected < 0)
			{
				_currentOptionSelected = arrayMenuOptions.Length - 1;
			}
			else if (_currentOptionSelected > arrayMenuOptions.Length - 1)
			{
				_currentOptionSelected = 0;
			}

			// Rafraîchir
			Console.Clear();
		}

		#endregion



		#region Modification methods

		private void SetPrenom(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Prénom (première lettre en majuscule) : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_firstName = userStr;
					return;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetNom(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Nom (première lettre en majuscule) : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_lastName = userStr;
					return;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetDate(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Date (jour/mois/annee) : ");
				if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dateOk))
				{
					try
					{
						contact.p_birthDate = dateOk;
						break;
					}
					catch (FormatException e)
					{
						ConsoleHelper.TextColorDarkRed("  " + e.Message);
					}
				}
				else
				{
					ConsoleHelper.TextColorDarkRed("  Erreur de format");
				}
			}
		}

		private void SetAdresseNumero(ref Contact contact)
		{
			while (true)
			{
				Console.Write("N° : ");
				if (int.TryParse(Console.ReadLine(), out int userInt))
				{
					try
					{
						contact.p_adresse.p_numero = userInt;
						break;
					}
					catch (FormatException e)
					{
						ConsoleHelper.TextColorDarkRed("  " + e.Message);
					}
				}
				else
				{
					ConsoleHelper.TextColorDarkRed("  Erreur de format");
				}
			}
		}

		private void SetAdresseRue(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Rue : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_adresse.p_rue = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetAdresseCodePostal(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Code postal : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_adresse.p_codePostal = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetAdresseVille(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Ville : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_adresse.p_ville = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetAdressePays(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Pays : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_adresse.p_pays = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetTelephone(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Tél : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_telephone = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		private void SetCourriel(ref Contact contact)
		{
			while (true)
			{
				Console.Write("Adresse courriel : ");
				string userStr = Console.ReadLine();
				try
				{
					contact.p_email = userStr;
					break;
				}
				catch (FormatException e)
				{
					ConsoleHelper.TextColorDarkRed("  " + e.Message);
				}
			}
		}

		#endregion
	}
}
