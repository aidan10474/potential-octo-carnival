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
	public class Player_team : ModelBase
	{
		[JsonIgnore]
		public CSGenioAplayer_team klass { get { return baseklass as CSGenioAplayer_team; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Player_team.ValCodplayer_team")]
		public string ValCodplayer_team { get { return klass.ValCodplayer_team; } set { klass.ValCodplayer_team = value; } }

		[DisplayName("player_fk")]
		/// <summary>Field : "player_fk" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Player_team.ValPlayer_fk")]
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

		[DisplayName("team_fk")]
		/// <summary>Field : "team_fk" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Player_team.ValTeam_fk")]
		public string ValTeam_fk { get { return klass.ValTeam_fk; } set { klass.ValTeam_fk = value; } }

		private Team _team;
		[DisplayName("Team")]
		[ShouldSerialize("Team")]
		public virtual Team Team
		{
			get
			{
				if (!isEmptyModel && (_team == null || (!string.IsNullOrEmpty(ValTeam_fk) && (_team.isEmptyModel || _team.klass.QPrimaryKey != ValTeam_fk))))
					_team = Models.Team.Find(ValTeam_fk, m_userContext, Identifier, _fieldsToSerialize);
				_team ??= new Models.Team(m_userContext, true, _fieldsToSerialize);
				return _team;
			}
			set { _team = value; }
		}

		[DisplayName("date_started")]
		/// <summary>Field : "date_started" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Player_team.ValDate_started")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate_started { get { return klass.ValDate_started; } set { klass.ValDate_started = value ?? DateTime.MinValue; } }

		[DisplayName("date_ended")]
		/// <summary>Field : "date_ended" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Player_team.ValDate_ended")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate_ended { get { return klass.ValDate_ended; } set { klass.ValDate_ended = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Player_team.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Player_team(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAplayer_team(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Player_team(UserContext userContext, CSGenioAplayer_team val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAplayer_team csgenioa)
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
					case "team":
						_team ??= new Team(m_userContext, true, _fieldsToSerialize);
						_team.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Player_team Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAplayer_team>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Player_team(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Player_team> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAplayer_team>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Player_team>((r) => new Player_team(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL PLAYER_TEAM]/
	}
}
