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
			name: 'F_PLAYER_STATS',
			area: 'STATS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_player_stats',
				updateFilesTickets: 'UpdateFilesTicketsF_player_stats',
				setFile: 'SetFileF_player_stats'
			}
		})

		/** The primary key. */
		this.ValCodstats = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodstats',
			originId: 'ValCodstats',
			area: 'STATS',
			field: 'CODSTATS',
			description: '',
		}).cloneFrom(values?.ValCodstats))
		this.stopWatchers.push(watch(() => this.ValCodstats.value, (newValue, oldValue) => this.onUpdate('stats.codstats', this.ValCodstats, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValPlayer_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValPlayer_fk',
			originId: 'ValPlayer_fk',
			area: 'STATS',
			field: 'PLAYER_FK',
			relatedArea: 'PLAYER',
			description: computed(() => this.Resources.PLAYER_FK43140),
		}).cloneFrom(values?.ValPlayer_fk))
		this.stopWatchers.push(watch(() => this.ValPlayer_fk.value, (newValue, oldValue) => this.onUpdate('stats.player_fk', this.ValPlayer_fk, newValue, oldValue)))

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

		this.ValPoints = reactive(new modelFieldType.Number({
			id: 'ValPoints',
			originId: 'ValPoints',
			area: 'STATS',
			field: 'POINTS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.POINTS56147),
		}).cloneFrom(values?.ValPoints))
		this.stopWatchers.push(watch(() => this.ValPoints.value, (newValue, oldValue) => this.onUpdate('stats.points', this.ValPoints, newValue, oldValue)))

		this.ValAssists = reactive(new modelFieldType.Number({
			id: 'ValAssists',
			originId: 'ValAssists',
			area: 'STATS',
			field: 'ASSISTS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ASSISTS50987),
		}).cloneFrom(values?.ValAssists))
		this.stopWatchers.push(watch(() => this.ValAssists.value, (newValue, oldValue) => this.onUpdate('stats.assists', this.ValAssists, newValue, oldValue)))

		this.ValRebounds = reactive(new modelFieldType.Number({
			id: 'ValRebounds',
			originId: 'ValRebounds',
			area: 'STATS',
			field: 'REBOUNDS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.REBOUNDS32845),
		}).cloneFrom(values?.ValRebounds))
		this.stopWatchers.push(watch(() => this.ValRebounds.value, (newValue, oldValue) => this.onUpdate('stats.rebounds', this.ValRebounds, newValue, oldValue)))

		this.ValGames_played = reactive(new modelFieldType.Number({
			id: 'ValGames_played',
			originId: 'ValGames_played',
			area: 'STATS',
			field: 'GAMES_PLAYED',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.GAMES_PLAYED27662),
		}).cloneFrom(values?.ValGames_played))
		this.stopWatchers.push(watch(() => this.ValGames_played.value, (newValue, oldValue) => this.onUpdate('stats.games_played', this.ValGames_played, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFPlayerStatsViewModel instance.
	 * @returns {QFormFPlayerStatsViewModel} A new instance of QFormFPlayerStatsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodstats'

	get QPrimaryKey() { return this.ValCodstats.value }
	set QPrimaryKey(value) { this.ValCodstats.updateValue(value) }
}
