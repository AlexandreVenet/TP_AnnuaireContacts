using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AnnuaireContacts.Helpers
{
	internal class ConsoleHelper
	{
		/// <summary>
		/// Afficher un texte dans une certaine couleur.
		/// </summary>
		/// <param name="color">Enum de la couleur du texte</param>
		/// <param name="message">Le texte</param>
		public static void ColorText(ConsoleColor color, string message)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		/// <summary>
		/// Afficher un texte dans une couleur et un fond dans une autre couleur.
		/// </summary>
		/// <param name="color">Enum de la couleur du texte</param>
		/// <param name="backgroundColor">Enum de la couleur du fond</param>
		/// <param name="message">Le texte</param>
		public static void ColorTextBackground(ConsoleColor color, ConsoleColor backgroundColor, string message)
		{
			Console.BackgroundColor = backgroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		/// <summary>
		/// Afficher un texte en noir.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorBlack(string message) => ColorText(ConsoleColor.Black, message);
		/// <summary>
		/// Afficher un texte en bleu.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorBlue(string message) => ColorText(ConsoleColor.Blue, message);
		/// <summary>
		/// Afficher un texte en cyan.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorCyan(string message) => ColorText(ConsoleColor.Cyan, message);
		/// <summary>
		/// Afficher un texte en gris.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorGray(string message) => ColorText(ConsoleColor.Gray, message);
		/// <summary>
		/// Afficher un texte en vert.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorGreen(string message) => ColorText(ConsoleColor.Green, message);
		/// <summary>
		/// Afficher un texte en magenta.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorMagenta(string message) => ColorText(ConsoleColor.Magenta, message);
		/// <summary>
		/// Afficher un texte en rouge.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorRed(string message) => ColorText(ConsoleColor.Red, message);
		/// <summary>
		/// Afficher un texte en blanc.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorWhite(string message) => ColorText(ConsoleColor.White, message);
		/// <summary>
		/// Afficher un texte en jaune.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorYellow(string message) => ColorText(ConsoleColor.Yellow, message);
		/// <summary>
		/// Afficher un texte en bleu sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkBlue(string message) => ColorText(ConsoleColor.DarkBlue, message);
		/// <summary>
		/// Afficher un texte en cyan sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkCyan(string message) => ColorText(ConsoleColor.DarkCyan, message);
		/// <summary>
		/// Afficher un texte en gris sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkGray(string message) => ColorText(ConsoleColor.DarkGray, message);
		/// <summary>
		/// Afficher un texte en vert sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkGreen(string message) => ColorText(ConsoleColor.DarkGreen, message);
		/// <summary>
		/// Afficher un texte en magenta sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkMagenta(string message) => ColorText(ConsoleColor.DarkMagenta, message);
		/// <summary>
		/// Afficher un texte en rouge sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkRed(string message) => ColorText(ConsoleColor.DarkRed, message);
		/// <summary>
		/// Afficher un texte en jaune sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextColorDarkYellow(string message) => ColorText(ConsoleColor.DarkYellow, message);

		/// <summary>
		/// Afficher un texte blanc sur fond noir.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundBlack(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.Black, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond bleu.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundBlue(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Blue, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond cyan.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundCyan(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Cyan, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond gris.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundGray(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Gray, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond vert.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundGreen(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Green, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur noir magenta.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundMagenta(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Magenta, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond rouge.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundRed(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Red, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond blanc.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundWhite(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.White, message);
		}
		/// <summary>
		/// Afficher un texte noir sur fond jaune.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundYellow(string message)
		{
			ColorTextBackground(ConsoleColor.Black, ConsoleColor.Yellow, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond bleu sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkBlue(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkBlue, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond cyan sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkCyan(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkCyan, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond gris sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkGray(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkGray, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond vert sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkGreen(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkGreen, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond magenta sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkMagenta(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkMagenta, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond rouge sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkRed(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkRed, message);
		}
		/// <summary>
		/// Afficher un texte blanc sur fond jaune sombre.
		/// </summary>
		/// <param name="message">Le texte</param>
		public static void TextBackgroundDarkYellow(string message)
		{
			ColorTextBackground(ConsoleColor.White, ConsoleColor.DarkYellow, message);
		}

		/// <summary>
		/// Nombre par défaut de caractères par défaut pour une ligne.
		/// </summary>
		private static int dashLengthDefault = 100;

		/// <summary>
		/// Nombre de caractère pour une ligne.
		/// </summary>
		public static int dashLength = 100;

		/// <summary>
		/// Réinitialiser la longeur de caractères au nombre par défaut.
		/// </summary>
		public static void ResetLength() => dashLength = dashLengthDefault;

		/// <summary>
		/// Enum permettant de définir le type de caractère utilisé pour une ligne.
		/// </summary>
		public enum DashType
		{
			Dash,
			SuperDash,
			Star,
			Equals,
			SuperEquals
		}

		/// <summary>
		/// Enum du type de caractère utilisé pour une ligne.
		/// </summary>
		public static DashType dashType = DashType.Dash;

		/// <summary>
		/// Dictionnaire des paires clé-valeur :<br/>
		/// - clé : enum du type de caractère,<br/>
		/// - valeur : le char correspondant.
		/// </summary>
		private static Dictionary<DashType, char> _dashChars = new Dictionary<DashType, char>()
		{
			{ DashType.Dash, '-' },
			{ DashType.SuperDash, '─' },
			{ DashType.Star, '*' },
			{ DashType.Equals, '=' },
			{ DashType.SuperEquals, '═' },
		};

		/// <summary>
		/// Afficher une ligne du caractère en cours dans une certaine couleur.
		/// </summary>
		/// <param name="color">La couleur de la ligne</param>
		public static void Line(ConsoleColor color)
		{
			ColorText(color, new string(_dashChars[dashType], dashLength));
		}


		/// <summary>
		/// Afficher une ligne en noir.
		/// </summary>
		public static void LineBlack() => Line(ConsoleColor.Black);
		/// <summary>
		/// Afficher une ligne en bleu.
		/// </summary>
		public static void LineBlue() => Line(ConsoleColor.Blue);
		/// <summary>
		/// Afficher une ligne en cyan.
		/// </summary>
		public static void LineCyan() => Line(ConsoleColor.Cyan);
		/// <summary>
		/// Afficher une ligne en gris.
		/// </summary>
		public static void LineGray() => Line(ConsoleColor.Gray);
		/// <summary>
		/// Afficher une ligne en vert.
		/// </summary>
		public static void LineGreen() => Line(ConsoleColor.Green);
		/// <summary>
		/// Afficher une ligne en magenta.
		/// </summary>
		public static void LineMagenta() => Line(ConsoleColor.Magenta);
		/// <summary>
		/// Afficher une ligne en rouge.
		/// </summary>
		public static void LineRed() => Line(ConsoleColor.Red);
		/// <summary>
		/// Afficher une ligne en blanc.
		/// </summary>
		public static void LineWhite() => Line(ConsoleColor.White);
		/// <summary>
		/// Afficher une ligne en jaune.
		/// </summary>
		public static void LineYellow() => Line(ConsoleColor.Yellow);
		/// <summary>
		/// Afficher une ligne en bleu sombre.
		/// </summary>
		public static void LineDarkBlue() => Line(ConsoleColor.DarkBlue);
		/// <summary>
		/// Afficher une ligne en cyan sombre.
		/// </summary>
		public static void LineDarkCyan() => Line(ConsoleColor.DarkCyan);
		/// <summary>
		/// Afficher une ligne en gris sombre.
		/// </summary>
		public static void LineDarkGray() => Line(ConsoleColor.DarkGray);
		/// <summary>
		/// Afficher une ligne en vert sombre.
		/// </summary>
		public static void LineDarkGreen() => Line(ConsoleColor.DarkGreen);
		/// <summary>
		/// Afficher une ligne en magenta sombre.
		/// </summary>
		public static void LineDarkMagenta() => Line(ConsoleColor.DarkMagenta);
		/// <summary>
		/// Afficher une ligne en rouge sombre.
		/// </summary>
		public static void LineDarkRed() => Line(ConsoleColor.DarkRed);
		/// <summary>
		/// Afficher une ligne en jaune sombre.
		/// </summary>
		public static void LineDarkYellow() => Line(ConsoleColor.DarkYellow);

	}
}
