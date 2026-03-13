/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_PLAYER_TEAM',
			area: 'PLAYER_TEAM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_player_team',
				updateFilesTickets: 'UpdateFilesTicketsF_player_team',
				setFile: 'SetFileF_player_team'
			}
		})

		/** The primary key. */
		this.ValCodplayer_team = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodplayer_team',
			originId: 'ValCodplayer_team',
			area: 'PLAYER_TEAM',
			field: 'CODPLAYER_TEAM',
			description: '',
		}).cloneFrom(values?.ValCodplayer_team))
		this.stopWatchers.push(watch(() => this.ValCodplayer_team.value, (newValue, oldValue) => this.onUpdate('player_team.codplayer_team', this.ValCodplayer_team, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValTeam_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValTeam_fk',
			originId: 'ValTeam_fk',
			area: 'PLAYER_TEAM',
			field: 'TEAM_FK',
			relatedArea: 'TEAM',
			isFixed: true,
			description: computed(() => this.Resources.TEAM_FK32854),
		}).cloneFrom(values?.ValTeam_fk))
		this.stopWatchers.push(watch(() => this.ValTeam_fk.value, (newValue, oldValue) => this.onUpdate('player_team.team_fk', this.ValTeam_fk, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValPlayer_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValPlayer_fk',
			originId: 'ValPlayer_fk',
			area: 'PLAYER_TEAM',
			field: 'PLAYER_FK',
			relatedArea: 'PLAYER',
			description: computed(() => this.Resources.PLAYER_FK43140),
		}).cloneFrom(values?.ValPlayer_fk))
		this.stopWatchers.push(watch(() => this.ValPlayer_fk.value, (newValue, oldValue) => this.onUpdate('player_team.player_fk', this.ValPlayer_fk, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePlayerName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePlayerName',
			originId: 'ValName',
			area: 'PLAYER',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePlayerName))
		this.stopWatchers.push(watch(() => this.TablePlayerName.value, (newValue, oldValue) => this.onUpdate('player.name', this.TablePlayerName, newValue, oldValue)))

		this.ValDate_started = reactive(new modelFieldType.Date({
			id: 'ValDate_started',
			originId: 'ValDate_started',
			area: 'PLAYER_TEAM',
			field: 'DATE_STARTED',
			description: computed(() => this.Resources.DATE_STARTED24788),
		}).cloneFrom(values?.ValDate_started))
		this.stopWatchers.push(watch(() => this.ValDate_started.value, (newValue, oldValue) => this.onUpdate('player_team.date_started', this.ValDate_started, newValue, oldValue)))

		this.ValDate_ended = reactive(new modelFieldType.Date({
			id: 'ValDate_ended',
			originId: 'ValDate_ended',
			area: 'PLAYER_TEAM',
			field: 'DATE_ENDED',
			description: computed(() => this.Resources.DATE_ENDED27868),
		}).cloneFrom(values?.ValDate_ended))
		this.stopWatchers.push(watch(() => this.ValDate_ended.value, (newValue, oldValue) => this.onUpdate('player_team.date_ended', this.ValDate_ended, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFPlayerTeamViewModel instance.
	 * @returns {QFormFPlayerTeamViewModel} A new instance of QFormFPlayerTeamViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplayer_team'

	get QPrimaryKey() { return this.ValCodplayer_team.value }
	set QPrimaryKey(value) { this.ValCodplayer_team.updateValue(value) }
}
