using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Rating (Rating)
	/// </summary>
	public class ArrayRating : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayRating _instance = new ArrayRating();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayRating Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// 1
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// 2
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// 3
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// 4
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// 5
		/// </summary>
		public const decimal E_5_5 = 5M;
		/// <summary>
		/// 6
		/// </summary>
		public const decimal E_6_6 = 6M;
		/// <summary>
		/// 7
		/// </summary>
		public const decimal E_7_7 = 7M;
		/// <summary>
		/// 8
		/// </summary>
		public const decimal E_8_8 = 8M;
		/// <summary>
		/// 9
		/// </summary>
		public const decimal E_9_9 = 9M;
		/// <summary>
		/// 10
		/// </summary>
		public const decimal E_10_10 = 10M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayRating"/> class from being created.
		/// </summary>
		private ArrayRating() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "_137648", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "_240153", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "_340014", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "_437743", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "_537084", HelpId = "", Group = "" } },
				{ E_6_6, new ArrayElement() { ResourceId = "_638533", HelpId = "", Group = "" } },
				{ E_7_7, new ArrayElement() { ResourceId = "_737370", HelpId = "", Group = "" } },
				{ E_8_8, new ArrayElement() { ResourceId = "_834891", HelpId = "", Group = "" } },
				{ E_9_9, new ArrayElement() { ResourceId = "_936792", HelpId = "", Group = "" } },
				{ E_10_10, new ArrayElement() { ResourceId = "_1012719", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
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
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
