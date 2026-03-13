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
	public class Team : ModelBase
	{
		[JsonIgnore]
		public CSGenioAteam klass { get { return baseklass as CSGenioAteam; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Team.ValCodteam")]
		public string ValCodteam { get { return klass.ValCodteam; } set { klass.ValCodteam = value; } }

		[DisplayName("skill_name")]
		/// <summary>Field : "skill_name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Team.ValSkill_name")]
		public string ValSkill_name { get { return klass.ValSkill_name; } set { klass.ValSkill_name = value; } }

		[DisplayName("description")]
		/// <summary>Field : "description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Team.ValDescription")]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Team.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Team(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAteam(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Team(UserContext userContext, CSGenioAteam val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAteam csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Team Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAteam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Team(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Team> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAteam>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Team>((r) => new Team(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL TEAM]/
	}
}
