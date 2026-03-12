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
	public class Contact : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcontact klass { get { return baseklass as CSGenioAcontact; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValCodcontact")]
		public string ValCodcontact { get { return klass.ValCodcontact; } set { klass.ValCodcontact = value; } }

		[DisplayName("gdgdg")]
		/// <summary>Field : "gdgdg" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValGdgdg")]
		public string ValGdgdg { get { return klass.ValGdgdg; } set { klass.ValGdgdg = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Contact.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Contact(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcontact(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Contact(UserContext userContext, CSGenioAcontact val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcontact csgenioa)
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
		public static Contact Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcontact>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Contact(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Contact> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcontact>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Contact>((r) => new Contact(userCtx, r));
		}

// USE /[MANUAL PRJ MODEL CONTACT]/
	}
}
