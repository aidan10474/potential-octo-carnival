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
	public class Player : ModelBase
	{
		[JsonIgnore]
		public CSGenioAplayer klass { get { return baseklass as CSGenioAplayer; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Player.ValCodplayers")]
		public string ValCodplayers { get { return klass.ValCodplayers; } set { klass.ValCodplayers = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Player.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birthdate")]
		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Player.ValBirthdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthdate { get { return klass.ValBirthdate; } set { klass.ValBirthdate = value ?? DateTime.MinValue; } }

		[DisplayName("Gender")]
		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Player.ValGender")]
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("Height")]
		/// <summary>Field : "Height" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Player.ValHeight_cm")]
		[NumericAttribute(0)]
		public decimal? ValHeight_cm { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValHeight_cm, 0)); } set { klass.ValHeight_cm = Convert.ToDecimal(value); } }

		[DisplayName("Position")]
		/// <summary>Field : "Position" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Player.ValPosition")]
		[DataArray("Position", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPosition { get { return klass.ValPosition; } set { klass.ValPosition = value; } }
		[JsonIgnore]
		public SelectList ArrayValposition { get { return new SelectList(CSGenio.business.ArrayPosition.GetDictionary(), "Key", "Value", ValPosition); } set { ValPosition = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Player.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Player(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAplayer(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Player(UserContext userContext, CSGenioAplayer val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAplayer csgenioa)
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
		public static Player Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAplayer>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Player(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Player> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAplayer>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Player>((r) => new Player(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL PLAYER]/
	}
}
