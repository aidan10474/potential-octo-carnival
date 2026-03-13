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
			name: 'F_PLAYER',
			area: 'PLAYER',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_player',
				updateFilesTickets: 'UpdateFilesTicketsF_player',
				setFile: 'SetFileF_player'
			}
		})

		/** The primary key. */
		this.ValCodplayers = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodplayers',
			originId: 'ValCodplayers',
			area: 'PLAYER',
			field: 'CODPLAYERS',
			description: '',
		}).cloneFrom(values?.ValCodplayers))
		this.stopWatchers.push(watch(() => this.ValCodplayers.value, (newValue, oldValue) => this.onUpdate('player.codplayers', this.ValCodplayers, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PLAYER',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('player.name', this.ValName, newValue, oldValue)))

		this.ValBirthdate = reactive(new modelFieldType.Date({
			id: 'ValBirthdate',
			originId: 'ValBirthdate',
			area: 'PLAYER',
			field: 'BIRTHDATE',
			description: computed(() => this.Resources.BIRTHDATE22743),
		}).cloneFrom(values?.ValBirthdate))
		this.stopWatchers.push(watch(() => this.ValBirthdate.value, (newValue, oldValue) => this.onUpdate('player.birthdate', this.ValBirthdate, newValue, oldValue)))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PLAYER',
			field: 'GENDER',
			maxLength: 6,
			arrayOptions: computed(() => new qProjArrays.QArrayGender(vm.$getResource).elements),
			description: computed(() => this.Resources.GENDER44172),
		}).cloneFrom(values?.ValGender))
		this.stopWatchers.push(watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('player.gender', this.ValGender, newValue, oldValue)))

		this.ValHeight_cm = reactive(new modelFieldType.Number({
			id: 'ValHeight_cm',
			originId: 'ValHeight_cm',
			area: 'PLAYER',
			field: 'HEIGHT_CM',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.HEIGHT11955),
		}).cloneFrom(values?.ValHeight_cm))
		this.stopWatchers.push(watch(() => this.ValHeight_cm.value, (newValue, oldValue) => this.onUpdate('player.height_cm', this.ValHeight_cm, newValue, oldValue)))

		this.ValPosition = reactive(new modelFieldType.String({
			id: 'ValPosition',
			originId: 'ValPosition',
			area: 'PLAYER',
			field: 'POSITION',
			maxLength: 2,
			arrayOptions: computed(() => new qProjArrays.QArrayPosition(vm.$getResource).elements),
			description: computed(() => this.Resources.POSITION54869),
		}).cloneFrom(values?.ValPosition))
		this.stopWatchers.push(watch(() => this.ValPosition.value, (newValue, oldValue) => this.onUpdate('player.position', this.ValPosition, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFPlayerViewModel instance.
	 * @returns {QFormFPlayerViewModel} A new instance of QFormFPlayerViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplayers'

	get QPrimaryKey() { return this.ValCodplayers.value }
	set QPrimaryKey(value) { this.ValCodplayers.updateValue(value) }
}
