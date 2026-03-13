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
			name: 'F_SKILL_PLAYER',
			area: 'SKILL_PLAYER',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_skill_player',
				updateFilesTickets: 'UpdateFilesTicketsF_skill_player',
				setFile: 'SetFileF_skill_player'
			}
		})

		/** The primary key. */
		this.ValCodskill_player = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodskill_player',
			originId: 'ValCodskill_player',
			area: 'SKILL_PLAYER',
			field: 'CODSKILL_PLAYER',
			description: '',
		}).cloneFrom(values?.ValCodskill_player))
		this.stopWatchers.push(watch(() => this.ValCodskill_player.value, (newValue, oldValue) => this.onUpdate('skill_player.codskill_player', this.ValCodskill_player, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValSkill_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValSkill_fk',
			originId: 'ValSkill_fk',
			area: 'SKILL_PLAYER',
			field: 'SKILL_FK',
			relatedArea: 'SKILL',
			isFixed: true,
			description: computed(() => this.Resources.SKILL_FK25820),
		}).cloneFrom(values?.ValSkill_fk))
		this.stopWatchers.push(watch(() => this.ValSkill_fk.value, (newValue, oldValue) => this.onUpdate('skill_player.skill_fk', this.ValSkill_fk, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValPlayer_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValPlayer_fk',
			originId: 'ValPlayer_fk',
			area: 'SKILL_PLAYER',
			field: 'PLAYER_FK',
			relatedArea: 'PLAYER',
			description: computed(() => this.Resources.PLAYER_FK43140),
		}).cloneFrom(values?.ValPlayer_fk))
		this.stopWatchers.push(watch(() => this.ValPlayer_fk.value, (newValue, oldValue) => this.onUpdate('skill_player.player_fk', this.ValPlayer_fk, newValue, oldValue)))

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

		this.ValRating = reactive(new modelFieldType.Number({
			id: 'ValRating',
			originId: 'ValRating',
			area: 'SKILL_PLAYER',
			field: 'RATING',
			maxDigits: 10,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayRating(vm.$getResource).elements),
			description: computed(() => this.Resources.RATING45804),
		}).cloneFrom(values?.ValRating))
		this.stopWatchers.push(watch(() => this.ValRating.value, (newValue, oldValue) => this.onUpdate('skill_player.rating', this.ValRating, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFSkillPlayerViewModel instance.
	 * @returns {QFormFSkillPlayerViewModel} A new instance of QFormFSkillPlayerViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodskill_player'

	get QPrimaryKey() { return this.ValCodskill_player.value }
	set QPrimaryKey(value) { this.ValCodskill_player.updateValue(value) }
}
