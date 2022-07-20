using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TP_AnnuaireContacts.Helpers
{
	internal class MyRegEx
	{
		/*
		 * Pattern Regex
		 *      ^       = commence
		 *      $       = fin
		 *      
		 *      \d      = nombre
		 *      \w      = Letter, Digit, Underscrore
		 *      \s      = White-Space(tabs, spaces)
		 *      \D      = Tout sauf les \d
		 *      \W      = Tout sauf des \w
		 *      \S      = Tout sauf les \s
		 *      |       = OU
		 *      *       = 0 ou plus
		 *      +       = au moins une fois
		 *      ?       = 0 ou 1 fois
		 *      {1}     = nb répétition
		 *      {2,4}   = 2 à 4 fois
		 *      .       = tout sauf Return
		 */

		public static bool IsName(string str)
		{
			// ^ : début de chaîne
			// [A-Z] : commence par une majuscule
			// {1} : Une seule majuscule acceptée
			// [a-zA-Z\s] : lettres, minuscules ou majuscules, espace, caractères spéciaux
			// * : 0 ou plus : peut ne pas avoir de lettre après la majuscule initiale
			string pattern = @"^[A-Z]{1}[a-zA-Z\séèêç'àâï-]*$";

			return Regex.IsMatch(str, pattern);
		}

		public static bool IsPhone(string str)
		{
			// 33 6 14 85 96 32
			// 33.6.14.85.96.32
			// 33-6-14-85-96-32
			// +33 6 14 85 96 32
			// +33.6.14.85.96.32
			// +33-6-14-85-96-32
			// 06 14 85 96 32
			// 0614859632

			// (((\+*33)(\s|-|.){0,1})|0){1}    ((+33 ou 33), suivi d'un caractère ou pas) ou bien un 0
			// (1|2|3|4|5|6|9){1}(\s|-|.){0,1}  un indicatif de région, suivi d'un caractère ou pas
			// (([0-9]{2}(\s|-|.){0,1})){3}     2 nombres, suivi d'un caractère ou pas, et tout cela 3 fois
			// ([0-9]{2}){1}                    2 nombres une seule fois

			string pattern = @"^(((\+*33)(\s|-|.)?)|0){1}[1-9]{1}((\s|-|.)?[0-9]{2}){4}$";
			return Regex.IsMatch(str, pattern);
		}

		public static bool IsEmail(string str)
		{
			// x@x.xx
			// x@x.xxx
			// x.01@23.x.photography
			string pattern = @"^([a-zA-Z0-9]+)([._-]?[a-zA-Z0-9]*)@([a-zA-Z0-9]+)([._-]?[a-zA-Z0-9]*)\.([a-zA-Z]{2,13})$";
			return Regex.IsMatch(str, pattern);
		}

		// supprimer des espaces en trop
		public static string ClearSpaces(string str)
		{
			//return str.Replace(" ", ""); // supprimer TOUT espace

			string pattern = @"\s+";
			return Regex.Replace(str, pattern, " ");
		}

		// utiliser les regex pour modifier, formater des chaînes

		public static string FormatPhone(string str)
		{
			// 33 6 14 85 96 32
			// 33.6.14.85.96.32
			// 33-6-14-85-96-32
			// +33 6 14 85 96 32
			// +33.6.14.85.96.32
			// +33-6-14-85-96-32
			// 06 14 85 96 32
			// 0614859632

			string tmp = str;

			// 0123456789 doit devenir : 01 23 45 67 89
			if (tmp.Length == 10)
			{
				tmp = string.Empty;
				for (int i = 0; i < str.Length; i++)
				{
					if (i % 2 == 0)
					{
						tmp += " ";
					}

					tmp += str[i];

				}
			}

			string pattern = @"[.-]+";
			string strFormater = Regex.Replace(tmp, pattern, " ");

			pattern = @"^(0|33)";
			strFormater = Regex.Replace(strFormater, pattern, "+33 ");

			return ClearSpaces(strFormater);
		}

		// Dates

		public static bool IsDateDay(string str)
		{
			string pattern = @"^(0{1}[1-9]{1})|(((1|2){1}[0-9]{1}))|(3[0-1])$";
			return Regex.IsMatch(str, pattern);
		}

		public static bool IsDateMonth(string str)
		{
			string pattern = @"^(0{1}[1-9]{1})|(1[1-2]{1})$";
			return Regex.IsMatch(str, pattern);
		}

		public static bool IsDateYear(string str)
		{
			string pattern = @"^((19[0-9]{2})|([2-9]{1}[0-9]{3}))$";
			return Regex.IsMatch(str, pattern);
		}

		public static bool IsDateOnly(string str)
		{
			// jour
			if (!IsDateDay(str.Substring(0, 2))) return false;

			// premier slash
			if (str[2] != '/') return false;

			// mois
			if (!IsDateMonth(str.Substring(3, 2))) return false;

			// second slash
			if (str[5] != '/') return false;

			// année
			if (!IsDateYear(str.Substring(6, 4))) return false;

			// tout est ok
			return true;
		}

		// Adresse

		public static bool IsLieu(string str)
		{
			string pattern = @"^[a-zA-Zèçéàïôêîû-]{1}[a-zA-Zèçéàïôêîû\s-]+$";
			return Regex.IsMatch(str, pattern);
		}

		public static bool IsCodePostal(string str)
		{
			string pattern = @"^([0-9]{2})([0-9]{3})$";
			return Regex.IsMatch(str, pattern);
		}
	}
}
