using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Stats : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstats klass { get { return baseklass as CSGenioAstats; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValCodstats")]
		public string ValCodstats { get { return klass.ValCodstats; } set { klass.ValCodstats = value; } }

		[DisplayName("player_fk")]
		/// <summary>Field : "player_fk" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValPlayer_fk")]
		public string ValPlayer_fk { get { return klass.ValPlayer_fk; } set { klass.ValPlayer_fk = value; } }

		private Player _player;
		[DisplayName("Player")]
		[ShouldSerialize("Player")]
		public virtual Player Player
		{
			get
			{
				if (!isEmptyModel && (_player == null || (!string.IsNullOrEmpty(ValPlayer_fk) && (_player.isEmptyModel || _player.klass.QPrimaryKey != ValPlayer_fk))))
					_player = Models.Player.Find(ValPlayer_fk, m_userContext, Identifier, _fieldsToSerialize);
				_player ??= new Models.Player(m_userContext, true, _fieldsToSerialize);
				return _player;
			}
			set { _player = value; }
		}

		[DisplayName("points")]
		/// <summary>Field : "points" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValPoints")]
		[NumericAttribute(0)]
		public decimal? ValPoints { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPoints, 0)); } set { klass.ValPoints = Convert.ToDecimal(value); } }

		[DisplayName("assists")]
		/// <summary>Field : "assists" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValAssists")]
		[NumericAttribute(0)]
		public decimal? ValAssists { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAssists, 0)); } set { klass.ValAssists = Convert.ToDecimal(value); } }

		[DisplayName("rebounds")]
		/// <summary>Field : "rebounds" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValRebounds")]
		[NumericAttribute(0)]
		public decimal? ValRebounds { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValRebounds, 0)); } set { klass.ValRebounds = Convert.ToDecimal(value); } }

		[DisplayName("games_played")]
		/// <summary>Field : "games_played" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stats.ValGames_played")]
		[NumericAttribute(0)]
		public decimal? ValGames_played { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValGames_played, 0)); } set { klass.ValGames_played = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Stats.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Stats(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAstats(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stats(UserContext userContext, CSGenioAstats val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAstats csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "player":
						_player ??= new Player(m_userContext, true, _fieldsToSerialize);
						_player.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Stats Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstats>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Stats(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Stats> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstats>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Stats>((r) => new Stats(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL STATS]/
	}
}
