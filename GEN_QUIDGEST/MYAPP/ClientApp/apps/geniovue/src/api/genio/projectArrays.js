/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, readonly } from 'vue'
import _merge from 'lodash-es/merge'

import netAPI from '@quidgest/clientapp/network'

/**
 * Represents a single option with a key, resourceId and reactive value.
 * Uses a WeakRef to hold the translation function so that the component
 * may be garbage-collected once it is no longer referenced elsewhere.
 */
export class Option {
	/**
	* @param {number} key - Unique identifier for this option.
	* @param {string} resourceId - Key used to look up the translated text.
	* @param {Function} fnResources - Function (resourceId -> string) from the Vue component.
	*/
	constructor({ key, resourceId, fnResources, helpResourceId, helpResourceVerboseId, group, icon } = {}) {
		this.key = key
		this.resourceId = resourceId
		this.helpResourceId = helpResourceId
		this.helpResourceVerboseId = helpResourceVerboseId
		this.group = group
		this.icon = icon

		// Store a weak reference to the translation function.
		// .deref() will return undefined if the original function has been
		// garbage-collected, avoiding retention of the component proxy.
		Object.defineProperty(this, '_weakFn', {
			value: typeof fnResources === 'function' ? new WeakRef(fnResources) : null,
			enumerable: false,
			configurable: true
		})

		// Create a computed property for the translated value. The computed
		// only depends on the weak reference, so when the component unmounts
		// and the function is reclaimed, this will fall back to resourceId.
		Object.defineProperty(this, 'value', {
			value: computed(() => {
				const fn = this._weakFn?.deref()
				return typeof fn === 'function'
					? fn(this.resourceId)
					: this.resourceId
			}),
			enumerable: true,
			configurable: true
		})

		if(typeof this.helpResourceId === 'string') {
			Object.defineProperty(this, 'description', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.helpResourceId)
						: this.helpResourceId
				}),
				enumerable: false,
				configurable: true
			})
		}

		if(typeof this.helpResourceVerboseId === 'string') {
			Object.defineProperty(this, 'descriptionVerbose', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.helpResourceVerboseId)
						: this.helpResourceVerboseId
				}),
				enumerable: false,
				configurable: true
			})
		}
	}
}

export class GroupOption {
	constructor({ id, resourceId, fnResources } = {}) {
		this.id = id
		this.resourceId = resourceId

		// Store a weak reference to the translation function.
		// .deref() will return undefined if the original function has been
		// garbage-collected, avoiding retention of the component proxy.
		Object.defineProperty(this, '_weakFn', {
			value: typeof fnResources === 'function' ? new WeakRef(fnResources) : null,
			enumerable: false,
			configurable: true
		})

		// Create a computed property for the translated value. The computed
		// only depends on the weak reference, so when the component unmounts
		// and the function is reclaimed, this will fall back to resourceId.
		if(typeof this.resourceId === 'string') {
			Object.defineProperty(this, 'title', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.resourceId)
						: this.resourceId
				}),
				enumerable: true,
				configurable: true
			})
		}
	}
}

/* eslint-enable @typescript-eslint/no-unused-vars */
/**
 * The Gender array.
 */
export class QArrayGender
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'GENDERS24703'
		this.singularName = 'GENDER44172'

		this.elements = [
			new Option({
				num: 1,
				key: 'Female',
				resourceId: 'FEMALE46107',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'Male',
				resourceId: 'MALE32397',
				fnResources,
			}),
		]

	}
}

/**
 * The Position array.
 */
export class QArrayPosition
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'POSITIONS36644'
		this.singularName = 'POSITION54869'

		this.elements = [
			new Option({
				num: 1,
				key: 'PG',
				resourceId: 'POINT_GUARD16925',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'SG',
				resourceId: 'SHOOTING_GUARD14552',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'SF',
				resourceId: 'SMALL_FORWARD09705',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'PF',
				resourceId: 'POWER_FORWARD00086',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'C',
				resourceId: 'CENTER62779',
				fnResources,
			}),
		]

	}
}

/**
 * The Rating array.
 */
export class QArrayRating
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'RATING45804'
		this.singularName = 'RATING45804'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: '_137648',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: '_240153',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: '_340014',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 4,
				resourceId: '_437743',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 5,
				resourceId: '_537084',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 6,
				resourceId: '_638533',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 7,
				resourceId: '_737370',
				fnResources,
			}),
			new Option({
				num: 8,
				key: 8,
				resourceId: '_834891',
				fnResources,
			}),
			new Option({
				num: 9,
				key: 9,
				resourceId: '_936792',
				fnResources,
			}),
			new Option({
				num: 10,
				key: 10,
				resourceId: '_1012719',
				fnResources,
			}),
		]

	}
}

/**
 * The s_modpro array.
 */
export class QArrayS_modpro
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'MODOS_DE_PROCESSAMEN07602'
		this.singularName = 'MODO_DE_PROCESSAMENT14469'

		this.elements = [
			new Option({
				num: 1,
				key: 'INDIV',
				resourceId: 'INDIVIDUAL42893',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'global',
				resourceId: 'GLOBAL58588',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'unidade',
				resourceId: 'UNIDADE_ORGANICA38383',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'horario',
				resourceId: 'HORARIO56549',
				fnResources,
			}),
		]

	}
}

/**
 * The s_module array.
 */
export class QArrayS_module
{
	/**
	 * Static cache to store reactive arrays by language code.
	 * Prevents multiple network requests and ensures reactive consistency.
	 * @type {Map<string, Ref[]>}
	 */
	static _langCache = new Map()

	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'MODULES33542'
		this.singularName = 'MODULE42049'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null

		// Initialise cache if missing
		if (!QArrayS_module._langCache.has(this.currentLang)) {
			const array = reactive([])
			QArrayS_module._langCache.set(this.currentLang, array)

			// Fetch only once per language
			netAPI.fetchDynamicArray('S_module', this.currentLang, (res) => {
				_merge(array, res)
			})
		}

	}

	get elements()
	{
		return readonly(QArrayS_module._langCache.get(this.currentLang) || [])
	}
}

/**
 * The s_prstat array.
 */
export class QArrayS_prstat
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ESTADOS_DO_PROCESSO59118'
		this.singularName = 'ESTADO_DO_PROCESSO07540'

		this.elements = [
			new Option({
				num: 1,
				key: 'EE',
				resourceId: 'EM_EXECUCAO53706',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'FE',
				resourceId: 'EM_FILA_DE_ESPERA21822',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'AG',
				resourceId: 'AGENDADO_PARA_EXECUC11223',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'T',
				resourceId: 'TERMINADO46276',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'C',
				resourceId: 'CANCELADO05982',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'NR',
				resourceId: 'NAO_RESPONDE33275',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 'AB',
				resourceId: 'ABORTADO52378',
				fnResources,
			}),
			new Option({
				num: 8,
				key: 'AC',
				resourceId: 'A_CANCELAR43988',
				fnResources,
			}),
		]

	}
}

/**
 * The s_resul array.
 */
export class QArrayS_resul
{
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'RESULTADOS20000'
		this.singularName = 'RESULTADO50955'

		this.elements = [
			new Option({
				num: 1,
				key: 'ok',
				resourceId: 'SUCESSO65230',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'er',
				resourceId: 'ERRO38355',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'wa',
				resourceId: 'AVISO03237',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'c',
				resourceId: 'CANCELADO05982',
				fnResources,
			}),
		]

	}
}

/**
 * The s_roles array.
 */
export class QArrayS_roles
{
	/**
	 * Static cache to store reactive arrays by language code.
	 * Prevents multiple network requests and ensures reactive consistency.
	 * @type {Map<string, Ref[]>}
	 */
	static _langCache = new Map()

	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'ROLE60946'
		this.singularName = 'ROLES61449'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null

		// Initialise cache if missing
		if (!QArrayS_roles._langCache.has(this.currentLang)) {
			const array = reactive([])
			QArrayS_roles._langCache.set(this.currentLang, array)

			// Fetch only once per language
			netAPI.fetchDynamicArray('S_roles', this.currentLang, (res) => {
				_merge(array, res)
			})
		}

	}

	get elements()
	{
		return readonly(QArrayS_roles._langCache.get(this.currentLang) || [])
	}
}

/**
 * The s_tpproc array.
 */
export class QArrayS_tpproc
{
	/**
	 * Static cache to store reactive arrays by language code.
	 * Prevents multiple network requests and ensures reactive consistency.
	 * @type {Map<string, Ref[]>}
	 */
	static _langCache = new Map()

	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'PROCESS_TYPES19050'
		this.singularName = 'PROCESS_TYPE50593'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null

		// Initialise cache if missing
		if (!QArrayS_tpproc._langCache.has(this.currentLang)) {
			const array = reactive([])
			QArrayS_tpproc._langCache.set(this.currentLang, array)

			// Fetch only once per language
			netAPI.fetchDynamicArray('S_tpproc', this.currentLang, (res) => {
				_merge(array, res)
			})
		}

	}

	get elements()
	{
		return readonly(QArrayS_tpproc._langCache.get(this.currentLang) || [])
	}
}


export default {
	QArrayGender,
	QArrayPosition,
	QArrayRating,
	QArrayS_modpro,
	QArrayS_module,
	QArrayS_prstat,
	QArrayS_resul,
	QArrayS_roles,
	QArrayS_tpproc,
}
