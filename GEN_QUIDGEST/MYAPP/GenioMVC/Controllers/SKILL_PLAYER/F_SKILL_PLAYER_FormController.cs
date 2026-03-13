using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Skill_player;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PRJ INCLUDE_CONTROLLER SKILL_PLAYER]/

namespace GenioMVC.Controllers
{
	public partial class Skill_playerController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_CANCEL = new("SKILL_PLAYER00402", "F_skill_player_Cancel", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_SHOW = new("SKILL_PLAYER00402", "F_skill_player_Show", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_NEW = new("SKILL_PLAYER00402", "F_skill_player_New", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_EDIT = new("SKILL_PLAYER00402", "F_skill_player_Edit", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_DUPLICATE = new("SKILL_PLAYER00402", "F_skill_player_Duplicate", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_SKILL_PLAYER_DELETE = new("SKILL_PLAYER00402", "F_skill_player_Delete", "Skill_player") { vueRouteName = "form-F_SKILL_PLAYER", mode = "DELETE" };

		#endregion

		#region F_skill_player private

		private void FormHistoryLimits_F_skill_player()
		{

		}

		#endregion

		#region F_skill_player_Show

// USE /[MANUAL PRJ CONTROLLER_SHOW F_SKILL_PLAYER]/

		[HttpPost]
		public ActionResult F_skill_player_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_skill_player_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Show_GET",
				AreaName = "skill_player",
				Location = ACTION_F_SKILL_PLAYER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_skill_player();
// USE /[MANUAL PRJ BEFORE_LOAD_SHOW F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_SHOW F_SKILL_PLAYER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_skill_player_New

// USE /[MANUAL PRJ CONTROLLER_NEW_GET F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_skill_player_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_New_GET",
				AreaName = "skill_player",
				FormName = "F_SKILL_PLAYER",
				Location = ACTION_F_SKILL_PLAYER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_skill_player();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW F_SKILL_PLAYER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Skill_player/F_skill_player_New
// USE /[MANUAL PRJ CONTROLLER_NEW_POST F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_New([FromBody]F_skill_player_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_New",
				ViewName = "F_skill_player",
				AreaName = "skill_player",
				Location = ACTION_F_SKILL_PLAYER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_NEW F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_NEW F_SKILL_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW_EX F_SKILL_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW_EX F_SKILL_PLAYER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_skill_player_Edit

// USE /[MANUAL PRJ CONTROLLER_EDIT_GET F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_skill_player_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Edit_GET",
				AreaName = "skill_player",
				FormName = "F_SKILL_PLAYER",
				Location = ACTION_F_SKILL_PLAYER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_skill_player();
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT F_SKILL_PLAYER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Skill_player/F_skill_player_Edit
// USE /[MANUAL PRJ CONTROLLER_EDIT_POST F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_Edit([FromBody]F_skill_player_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Edit",
				ViewName = "F_skill_player",
				AreaName = "skill_player",
				Location = ACTION_F_SKILL_PLAYER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_EDIT F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_EDIT F_SKILL_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT_EX F_SKILL_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT_EX F_SKILL_PLAYER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_skill_player_Delete

// USE /[MANUAL PRJ CONTROLLER_DELETE_GET F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_skill_player_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Delete_GET",
				AreaName = "skill_player",
				FormName = "F_SKILL_PLAYER",
				Location = ACTION_F_SKILL_PLAYER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_skill_player();
// USE /[MANUAL PRJ BEFORE_LOAD_DELETE F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DELETE F_SKILL_PLAYER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Skill_player/F_skill_player_Delete
// USE /[MANUAL PRJ CONTROLLER_DELETE_POST F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_skill_player_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Delete",
				ViewName = "F_skill_player",
				AreaName = "skill_player",
				Location = ACTION_F_SKILL_PLAYER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_DESTROY_DELETE F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_DESTROY_DELETE F_SKILL_PLAYER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_skill_player_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_SKILL_PLAYER");
		}

		#endregion

		#region F_skill_player_Duplicate

// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_GET F_SKILL_PLAYER]/

		[HttpPost]
		public ActionResult F_skill_player_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_skill_player_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Duplicate_GET",
				AreaName = "skill_player",
				FormName = "F_SKILL_PLAYER",
				Location = ACTION_F_SKILL_PLAYER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE F_SKILL_PLAYER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Skill_player/F_skill_player_Duplicate
// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_POST F_SKILL_PLAYER]/
		[HttpPost]
		public ActionResult F_skill_player_Duplicate([FromBody]F_skill_player_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_Duplicate",
				ViewName = "F_skill_player",
				AreaName = "skill_player",
				Location = ACTION_F_SKILL_PLAYER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_DUPLICATE F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_DUPLICATE F_SKILL_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE_EX F_SKILL_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE_EX F_SKILL_PLAYER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_skill_player_Cancel

		//
		// GET: /Skill_player/F_skill_player_Cancel
// USE /[MANUAL PRJ CONTROLLER_CANCEL_GET F_SKILL_PLAYER]/
		public ActionResult F_skill_player_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Skill_player model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("skill_player");

// USE /[MANUAL PRJ BEFORE_CANCEL F_SKILL_PLAYER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PRJ AFTER_CANCEL F_SKILL_PLAYER]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_skill_player", "true", true);
			}

			Navigation.ClearValue("skill_player");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_skill_player_PlayerValNameModel : RequestLookupModel
		{
			public F_skill_player_ViewModel Model { get; set; }
		}

		//
		// GET: /Skill_player/F_skill_player_PlayerValName
		// POST: /Skill_player/F_skill_player_PlayerValName
		[ActionName("F_skill_player_PlayerValName")]
		public ActionResult F_skill_player_PlayerValName([FromBody] F_skill_player_PlayerValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_player")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_player");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Skill_player parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_skill_player_PlayerValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Skill_player/F_skill_player_SaveEdit
		[HttpPost]
		public ActionResult F_skill_player_SaveEdit([FromBody] F_skill_player_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_skill_player_SaveEdit",
				ViewName = "F_skill_player",
				AreaName = "skill_player",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_APPLY_EDIT F_SKILL_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_APPLY_EDIT F_SKILL_PLAYER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_skill_playerDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_skill_player_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_skill_player([FromBody] F_skill_playerDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
