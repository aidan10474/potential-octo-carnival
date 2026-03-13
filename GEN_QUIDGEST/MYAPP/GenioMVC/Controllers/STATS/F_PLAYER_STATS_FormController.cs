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
using GenioMVC.ViewModels.Stats;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL PRJ INCLUDE_CONTROLLER STATS]/

namespace GenioMVC.Controllers
{
	public partial class StatsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_CANCEL = new("STATS33120", "F_player_stats_Cancel", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_SHOW = new("STATS33120", "F_player_stats_Show", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_NEW = new("STATS33120", "F_player_stats_New", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_EDIT = new("STATS33120", "F_player_stats_Edit", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_DUPLICATE = new("STATS33120", "F_player_stats_Duplicate", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PLAYER_STATS_DELETE = new("STATS33120", "F_player_stats_Delete", "Stats") { vueRouteName = "form-F_PLAYER_STATS", mode = "DELETE" };

		#endregion

		#region F_player_stats private

		private void FormHistoryLimits_F_player_stats()
		{

		}

		#endregion

		#region F_player_stats_Show

// USE /[MANUAL PRJ CONTROLLER_SHOW F_PLAYER_STATS]/

		[HttpPost]
		public ActionResult F_player_stats_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_stats_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Show_GET",
				AreaName = "stats",
				Location = ACTION_F_PLAYER_STATS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_stats();
// USE /[MANUAL PRJ BEFORE_LOAD_SHOW F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_SHOW F_PLAYER_STATS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_player_stats_New

// USE /[MANUAL PRJ CONTROLLER_NEW_GET F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_player_stats_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_New_GET",
				AreaName = "stats",
				FormName = "F_PLAYER_STATS",
				Location = ACTION_F_PLAYER_STATS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_player_stats();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW F_PLAYER_STATS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Stats/F_player_stats_New
// USE /[MANUAL PRJ CONTROLLER_NEW_POST F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_New([FromBody]F_player_stats_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_New",
				ViewName = "F_player_stats",
				AreaName = "stats",
				Location = ACTION_F_PLAYER_STATS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_NEW F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_NEW F_PLAYER_STATS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_NEW_EX F_PLAYER_STATS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_NEW_EX F_PLAYER_STATS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_player_stats_Edit

// USE /[MANUAL PRJ CONTROLLER_EDIT_GET F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_stats_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Edit_GET",
				AreaName = "stats",
				FormName = "F_PLAYER_STATS",
				Location = ACTION_F_PLAYER_STATS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_stats();
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT F_PLAYER_STATS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Stats/F_player_stats_Edit
// USE /[MANUAL PRJ CONTROLLER_EDIT_POST F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_Edit([FromBody]F_player_stats_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Edit",
				ViewName = "F_player_stats",
				AreaName = "stats",
				Location = ACTION_F_PLAYER_STATS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_EDIT F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_EDIT F_PLAYER_STATS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_EDIT_EX F_PLAYER_STATS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_EDIT_EX F_PLAYER_STATS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_player_stats_Delete

// USE /[MANUAL PRJ CONTROLLER_DELETE_GET F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_stats_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Delete_GET",
				AreaName = "stats",
				FormName = "F_PLAYER_STATS",
				Location = ACTION_F_PLAYER_STATS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player_stats();
// USE /[MANUAL PRJ BEFORE_LOAD_DELETE F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DELETE F_PLAYER_STATS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Stats/F_player_stats_Delete
// USE /[MANUAL PRJ CONTROLLER_DELETE_POST F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_player_stats_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Delete",
				ViewName = "F_player_stats",
				AreaName = "stats",
				Location = ACTION_F_PLAYER_STATS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_DESTROY_DELETE F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_DESTROY_DELETE F_PLAYER_STATS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_player_stats_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PLAYER_STATS");
		}

		#endregion

		#region F_player_stats_Duplicate

// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_GET F_PLAYER_STATS]/

		[HttpPost]
		public ActionResult F_player_stats_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_player_stats_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Duplicate_GET",
				AreaName = "stats",
				FormName = "F_PLAYER_STATS",
				Location = ACTION_F_PLAYER_STATS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE F_PLAYER_STATS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Stats/F_player_stats_Duplicate
// USE /[MANUAL PRJ CONTROLLER_DUPLICATE_POST F_PLAYER_STATS]/
		[HttpPost]
		public ActionResult F_player_stats_Duplicate([FromBody]F_player_stats_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_Duplicate",
				ViewName = "F_player_stats",
				AreaName = "stats",
				Location = ACTION_F_PLAYER_STATS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_SAVE_DUPLICATE F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_SAVE_DUPLICATE F_PLAYER_STATS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_LOAD_DUPLICATE_EX F_PLAYER_STATS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_LOAD_DUPLICATE_EX F_PLAYER_STATS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_player_stats_Cancel

		//
		// GET: /Stats/F_player_stats_Cancel
// USE /[MANUAL PRJ CONTROLLER_CANCEL_GET F_PLAYER_STATS]/
		public ActionResult F_player_stats_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Stats model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("stats");

// USE /[MANUAL PRJ BEFORE_CANCEL F_PLAYER_STATS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL PRJ AFTER_CANCEL F_PLAYER_STATS]/

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

				Navigation.SetValue("ForcePrimaryRead_stats", "true", true);
			}

			Navigation.ClearValue("stats");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_player_stats_PlayerValNameModel : RequestLookupModel
		{
			public F_player_stats_ViewModel Model { get; set; }
		}

		//
		// GET: /Stats/F_player_stats_PlayerValName
		// POST: /Stats/F_player_stats_PlayerValName
		[ActionName("F_player_stats_PlayerValName")]
		public ActionResult F_player_stats_PlayerValName([FromBody] F_player_stats_PlayerValNameModel requestModel)
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

			Models.Stats parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_player_stats_PlayerValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Stats/F_player_stats_SaveEdit
		[HttpPost]
		public ActionResult F_player_stats_SaveEdit([FromBody] F_player_stats_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_player_stats_SaveEdit",
				ViewName = "F_player_stats",
				AreaName = "stats",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ BEFORE_APPLY_EDIT F_PLAYER_STATS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL PRJ AFTER_APPLY_EDIT F_PLAYER_STATS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_player_statsDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_player_stats_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_player_stats([FromBody] F_player_statsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
