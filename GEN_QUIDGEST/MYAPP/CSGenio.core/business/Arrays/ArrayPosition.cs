using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Position (Position)
	/// </summary>
	public class ArrayPosition : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPosition _instance = new ArrayPosition();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPosition Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Point Guard
		/// </summary>
		public const string E_PG_1 = "PG";
		/// <summary>
		/// Shooting Guard
		/// </summary>
		public const string E_SG_2 = "SG";
		/// <summary>
		/// Small Forward
		/// </summary>
		public const string E_SF_3 = "SF";
		/// <summary>
		/// Power Forward
		/// </summary>
		public const string E_PF_4 = "PF";
		/// <summary>
		/// Center
		/// </summary>
		public const string E_C_5 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPosition"/> class from being created.
		/// </summary>
		private ArrayPosition() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_PG_1, new ArrayElement() { ResourceId = "POINT_GUARD16925", HelpId = "", Group = "" } },
				{ E_SG_2, new ArrayElement() { ResourceId = "SHOOTING_GUARD14552", HelpId = "", Group = "" } },
				{ E_SF_3, new ArrayElement() { ResourceId = "SMALL_FORWARD09705", HelpId = "", Group = "" } },
				{ E_PF_4, new ArrayElement() { ResourceId = "POWER_FORWARD00086", HelpId = "", Group = "" } },
				{ E_C_5, new ArrayElement() { ResourceId = "CENTER62779", HelpId = "", Group = "" } },
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
