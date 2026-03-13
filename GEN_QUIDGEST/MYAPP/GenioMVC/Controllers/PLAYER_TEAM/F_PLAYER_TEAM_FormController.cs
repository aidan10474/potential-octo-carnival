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
using GenioMVC.ViewModels.Player_team;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PRJ INCLUDE_CONTROLLER PLAYER_TEAM]/

namespace GenioMVC.Controllers
{
	public partial class Player_teamController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_CANCEL = new("PLAYER_TEAM08295", "F_player_team_Cancel", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_SHOW = new("PLAYER_TEAM08295", "F_player_team_Show", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_NEW = new("PLAYER_TEAM08295", "F_player_team_New", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_EDIT = new("PLAYER_TEAM08295", "F_player_team_Edit", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_DUPLICATE = new("PLAYER_TEAM08295", "F_player_team_Duplicate", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PLAYER_TEAM_DELETE = new("PLAYER_TEAM08295", "F_player_team_Delete", "Player_team") { vueRouteName = "form-F_PLAYER_TEAM", mode = "DELETE" };

		#endregion

		#region F_player_team private

		private void FormHistoryLimits_F_player_team()
		{

		}

		#endregion

		#region F_player_team_Show

// USE /[MANUAL PRJ CONTROLLER_SHOW F_PLAYER_TEAM]/

		[HttpPost]
		public ActionResult F_player_team_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Show_GET",
				AreaName = "player_team",
				Location = ACTION_F_PLAYER_TEAM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_team();
// USE /[MANUAL PRJ BEFORE_LOAD_SHOW F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_SHOW F_PLAYER_TEAM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_player_team_New

// USE /[MANUAL PRJ CONTROLLER_NEW_GET F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_player_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_New_GET",
				AreaName = "player_team",
				FormName = "F_PLAYER_TEAM",
				Location = ACTION_F_PLAYER_TEAM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_player_team();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW F_PLAYER_TEAM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Player_team/F_player_team_New
// USE /[MANUAL PRJ CONTROLLER_NEW_POST F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_New([FromBody]F_player_team_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_New",
				ViewName = "F_player_team",
				AreaName = "player_team",
				Location = ACTION_F_PLAYER_TEAM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_NEW F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_NEW F_PLAYER_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW_EX F_PLAYER_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW_EX F_PLAYER_TEAM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_player_team_Edit

// USE /[MANUAL PRJ CONTROLLER_EDIT_GET F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Edit_GET",
				AreaName = "player_team",
				FormName = "F_PLAYER_TEAM",
				Location = ACTION_F_PLAYER_TEAM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_team();
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT F_PLAYER_TEAM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Player_team/F_player_team_Edit
// USE /[MANUAL PRJ CONTROLLER_EDIT_POST F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_Edit([FromBody]F_player_team_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Edit",
				ViewName = "F_player_team",
				AreaName = "player_team",
				Location = ACTION_F_PLAYER_TEAM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_EDIT F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_EDIT F_PLAYER_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT_EX F_PLAYER_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT_EX F_PLAYER_TEAM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_player_team_Delete

// USE /[MANUAL PRJ CONTROLLER_DELETE_GET F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Delete_GET",
				AreaName = "player_team",
				FormName = "F_PLAYER_TEAM",
				Location = ACTION_F_PLAYER_TEAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_team();
// USE /[MANUAL PRJ BEFORE_LOAD_DELETE F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DELETE F_PLAYER_TEAM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Player_team/F_player_team_Delete
// USE /[MANUAL PRJ CONTROLLER_DELETE_POST F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_team_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Delete",
				ViewName = "F_player_team",
				AreaName = "player_team",
				Location = ACTION_F_PLAYER_TEAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_DESTROY_DELETE F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_DESTROY_DELETE F_PLAYER_TEAM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_player_team_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PLAYER_TEAM");
		}

		#endregion

		#region F_player_team_Duplicate

// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_GET F_PLAYER_TEAM]/

		[HttpPost]
		public ActionResult F_player_team_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_player_team_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Duplicate_GET",
				AreaName = "player_team",
				FormName = "F_PLAYER_TEAM",
				Location = ACTION_F_PLAYER_TEAM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE F_PLAYER_TEAM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Player_team/F_player_team_Duplicate
// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_POST F_PLAYER_TEAM]/
		[HttpPost]
		public ActionResult F_player_team_Duplicate([FromBody]F_player_team_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_Duplicate",
				ViewName = "F_player_team",
				AreaName = "player_team",
				Location = ACTION_F_PLAYER_TEAM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_DUPLICATE F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_DUPLICATE F_PLAYER_TEAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE_EX F_PLAYER_TEAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE_EX F_PLAYER_TEAM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_player_team_Cancel

		//
		// GET: /Player_team/F_player_team_Cancel
// USE /[MANUAL PRJ CONTROLLER_CANCEL_GET F_PLAYER_TEAM]/
		public ActionResult F_player_team_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Player_team model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("player_team");

// USE /[MANUAL PRJ BEFORE_CANCEL F_PLAYER_TEAM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PRJ AFTER_CANCEL F_PLAYER_TEAM]/

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

				Navigation.SetValue("ForcePrimaryRead_player_team", "true", true);
			}

			Navigation.ClearValue("player_team");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_player_team_PlayerValNameModel : RequestLookupModel
		{
			public F_player_team_ViewModel Model { get; set; }
		}

		//
		// GET: /Player_team/F_player_team_PlayerValName
		// POST: /Player_team/F_player_team_PlayerValName
		[ActionName("F_player_team_PlayerValName")]
		public ActionResult F_player_team_PlayerValName([FromBody] F_player_team_PlayerValNameModel requestModel)
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

			Models.Player_team parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_player_team_PlayerValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Player_team/F_player_team_SaveEdit
		[HttpPost]
		public ActionResult F_player_team_SaveEdit([FromBody] F_player_team_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_team_SaveEdit",
				ViewName = "F_player_team",
				AreaName = "player_team",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_APPLY_EDIT F_PLAYER_TEAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_APPLY_EDIT F_PLAYER_TEAM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_player_teamDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_player_team_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_player_team([FromBody] F_player_teamDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
