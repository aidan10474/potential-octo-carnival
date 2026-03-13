using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Gender (Gender)
	/// </summary>
	public class ArrayGender : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayGender _instance = new ArrayGender();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayGender Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Female
		/// </summary>
		public const string E_FEMALE_1 = "Female";
		/// <summary>
		/// Male
		/// </summary>
		public const string E_MALE_2 = "Male";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayGender"/> class from being created.
		/// </summary>
		private ArrayGender() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_FEMALE_1, new ArrayElement() { ResourceId = "FEMALE46107", HelpId = "", Group = "" } },
				{ E_MALE_2, new ArrayElement() { ResourceId = "MALE32397", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
