using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Skill_player
{
	public class F_skill_player_ViewModel : FormViewModel<Models.Skill_player>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValPlayer_fk { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValSkill_fk { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Player> TablePlayerName { get; set; }
		/// <summary>
		/// Title: "Rating" | Type: "AN"
		/// </summary>
		public decimal ValRating { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodskill_player { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_skill_player_ViewModel() : base(null!) { }

		public F_skill_player_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_SKILL_PLAYER", nestedForm) { }

		public F_skill_player_ViewModel(UserContext userContext, Models.Skill_player row, bool nestedForm = false) : base(userContext, "FF_SKILL_PLAYER", row, nestedForm) { }

		public F_skill_player_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("skill_player", id);
			Model = Models.Skill_player.Find(id, userContext, "FF_SKILL_PLAYER", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Skill_player model = new Models.Skill_player(userContext) { Identifier = "FF_SKILL_PLAYER" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_SKILL_PLAYER");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Skill_player m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Skill_player) to ViewModel (F_skill_player) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValPlayer_fk = ViewModelConversion.ToString(m.ValPlayer_fk);
				ValSkill_fk = ViewModelConversion.ToString(m.ValSkill_fk);
				ValRating = ViewModelConversion.ToNumeric(m.ValRating);
				ValCodskill_player = ViewModelConversion.ToString(m.ValCodskill_player);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Skill_player) to ViewModel (F_skill_player) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Skill_player m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_skill_player) to Model (Skill_player) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValPlayer_fk = ViewModelConversion.ToString(ValPlayer_fk);
				m.ValRating = ViewModelConversion.ToNumeric(ValRating);
				m.ValCodskill_player = ViewModelConversion.ToString(ValCodskill_player);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValSkill_fk = ViewModelConversion.ToString(ValSkill_fk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_skill_player) to Model (Skill_player) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "skill_player.player_fk":
						this.ValPlayer_fk = ViewModelConversion.ToString(_value);
						break;
					case "skill_player.rating":
						this.ValRating = ViewModelConversion.ToNumeric(_value);
						break;
					case "skill_player.codskill_player":
						this.ValCodskill_player = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_skill_player) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_skill_player)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Skill_player.Find(id ?? Navigation.GetStrValue("skill_player"), m_userContext, "FF_SKILL_PLAYER"); }
			finally { Model ??= new Models.Skill_player(m_userContext) { Identifier = "FF_SKILL_PLAYER" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Skill_player.Find(Navigation.GetStrValue("skill_player"), m_userContext, "FF_SKILL_PLAYER");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FF_SKILL_PLAYER";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Skill_player row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Skill_player.Find(Navigation.GetStrValue("skill_player"), m_userContext, "FF_SKILL_PLAYER");
				if (Model == null)
				{
					Model = new Models.Skill_player(m_userContext) { Identifier = "FF_SKILL_PLAYER" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("skill_player");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_skill_player__player__name(qs, lazyLoad);

// USE /[MANUAL PRJ VIEWMODEL_LOADPARTIAL F_SKILL_PLAYER]/
		}

// USE /[MANUAL PRJ VIEWMODEL_NEW F_SKILL_PLAYER]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValRating", Resources.Resources.RATING45804, ViewModelConversion.ToNumeric(ValRating), FieldType.ARRAY_NUMERIC.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL PRJ VIEWMODEL_SAVE F_SKILL_PLAYER]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL PRJ VIEWMODEL_APPLY F_SKILL_PLAYER]/

// USE /[MANUAL PRJ VIEWMODEL_DUPLICATE F_SKILL_PLAYER]/

// USE /[MANUAL PRJ VIEWMODEL_DESTROY F_SKILL_PLAYER]/
		public override void Destroy(string id)
		{
			Model = Models.Skill_player.Find(id, m_userContext, "FF_SKILL_PLAYER");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TablePlayerName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_skill_player__player__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_skill_player__player__nameDoLoad = true;
			CriteriaSet f_skill_player__player__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("player", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_skill_player__player__nameConds.Equal(CSGenioAplayer.FldCodplayers, hValue);
					this.ValPlayer_fk = DBConversion.ToString(hValue);
				}
			}

			TablePlayerName = new TableDBEdit<Models.Player>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_player") != null)
				{
					this.ValPlayer_fk = Navigation.GetStrValue("RETURN_player");
					Navigation.CurrentLevel.SetEntry("RETURN_player", null);
				}
				FillDependant_F_skill_playerTablePlayerName(lazyLoad);
				return;
			}

			if (f_skill_player__player__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePlayerName, "sTablePlayerName", "dTablePlayerName", qs, "player");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAplayer.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePlayerName_tableFilters"]))
					TablePlayerName.TableFilters = bool.Parse(qs["TablePlayerName_tableFilters"]);
				else
					TablePlayerName.TableFilters = false;

				query = qs["qTablePlayerName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAplayer.FldName, query + "%");
				}
				f_skill_player__player__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePlayerName"] != null ? qs["pTablePlayerName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAplayer.FldCodplayers, CSGenioAplayer.FldName, CSGenioAplayer.FldZzstate];

// USE /[MANUAL PRJ OVERRQ F_SKILL_PLAYER_PLAYERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("player", FormMode.New) || Navigation.checkFormMode("player", FormMode.Duplicate))
					f_skill_player__player__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAplayer.FldZzstate, 0)
						.Equal(CSGenioAplayer.FldCodplayers, Navigation.GetStrValue("player")));
				else
					f_skill_player__player__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAplayer.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("player", "name");
				ListingMVC<CSGenioAplayer> listing = Models.ModelBase.Where<CSGenioAplayer>(m_userContext, false, f_skill_player__player__nameConds, fields, offset, numberItems, sorts, "LED_F_SKILL_PLAYER__PLAYER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePlayerName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePlayerName.Query = query;
				TablePlayerName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Player(m_userContext, r, true, _fieldsToSerialize_F_SKILL_PLAYER__PLAYER__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_player") != null)
				{
					this.ValPlayer_fk = Navigation.GetStrValue("RETURN_player");
					Navigation.CurrentLevel.SetEntry("RETURN_player", null);
				}

				TablePlayerName.List = new SelectList(TablePlayerName.Elements.ToSelectList(x => x.ValName, x => x.ValCodplayers,  x => x.ValCodplayers == this.ValPlayer_fk), "Value", "Text", this.ValPlayer_fk);
				FillDependant_F_skill_playerTablePlayerName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePlayerName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Player</param>
		public ConcurrentDictionary<string, object> GetDependant_F_skill_playerTablePlayerName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAplayer.FldCodplayers, CSGenioAplayer.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAplayer tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAplayer.FldCodplayers, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePlayerName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_skill_playerTablePlayerName(bool lazyLoad = false)
		{
			var row = GetDependant_F_skill_playerTablePlayerName(this.ValPlayer_fk);
			try
			{

				// Fill List fields
				this.ValPlayer_fk = ViewModelConversion.ToString(row["player.codplayers"]);
				TablePlayerName.Value = (string)row["player.name"];
				if (GenFunctions.emptyG(this.ValPlayer_fk) == 1)
				{
					this.ValPlayer_fk = "";
					TablePlayerName.Value = "";
					Navigation.ClearValue("player");
				}
				else if (lazyLoad)
				{
					TablePlayerName.SetPagination(1, 0, false, false, 1);
					TablePlayerName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValPlayer_fk),
							Text = Convert.ToString(TablePlayerName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValPlayer_fk);
				}

				TablePlayerName.Selected = this.ValPlayer_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePlayerName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_SKILL_PLAYER__PLAYER__NAME = ["Player", "Player.ValCodplayers", "Player.ValZzstate", "Player.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"skill_player.player_fk" => ViewModelConversion.ToString(modelValue),
				"skill_player.skill_fk" => ViewModelConversion.ToString(modelValue),
				"skill_player.rating" => ViewModelConversion.ToNumeric(modelValue),
				"skill_player.codskill_player" => ViewModelConversion.ToString(modelValue),
				"player.codplayers" => ViewModelConversion.ToString(modelValue),
				"player.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL PRJ VIEWMODEL_CUSTOM F_SKILL_PLAYER]/

		#endregion
	}
}
