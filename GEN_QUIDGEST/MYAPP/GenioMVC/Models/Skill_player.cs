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
	public class Skill_player : ModelBase
	{
		[JsonIgnore]
		public CSGenioAskill_player klass { get { return baseklass as CSGenioAskill_player; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Skill_player.ValCodskill_player")]
		public string ValCodskill_player { get { return klass.ValCodskill_player; } set { klass.ValCodskill_player = value; } }

		[DisplayName("player_fk")]
		/// <summary>Field : "player_fk" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Skill_player.ValPlayer_fk")]
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

		[DisplayName("skill_fk")]
		/// <summary>Field : "skill_fk" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Skill_player.ValSkill_fk")]
		public string ValSkill_fk { get { return klass.ValSkill_fk; } set { klass.ValSkill_fk = value; } }

		private Skill _skill;
		[DisplayName("Skill")]
		[ShouldSerialize("Skill")]
		public virtual Skill Skill
		{
			get
			{
				if (!isEmptyModel && (_skill == null || (!string.IsNullOrEmpty(ValSkill_fk) && (_skill.isEmptyModel || _skill.klass.QPrimaryKey != ValSkill_fk))))
					_skill = Models.Skill.Find(ValSkill_fk, m_userContext, Identifier, _fieldsToSerialize);
				_skill ??= new Models.Skill(m_userContext, true, _fieldsToSerialize);
				return _skill;
			}
			set { _skill = value; }
		}

		[DisplayName("Rating")]
		/// <summary>Field : "Rating" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Skill_player.ValRating")]
		[DataArray("Rating", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValRating { get { return klass.ValRating; } set { klass.ValRating = value; } }
		[JsonIgnore]
		public SelectList ArrayValrating { get { return new SelectList(CSGenio.business.ArrayRating.GetDictionary(), "Key", "Value", ValRating); } set { ValRating = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Skill_player.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Skill_player(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAskill_player(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Skill_player(UserContext userContext, CSGenioAskill_player val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAskill_player csgenioa)
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
					case "skill":
						_skill ??= new Skill(m_userContext, true, _fieldsToSerialize);
						_skill.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Skill_player Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAskill_player>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Skill_player(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Skill_player> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAskill_player>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Skill_player>((r) => new Skill_player(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL SKILL_PLAYER]/
	}
}
