import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/F_PLAYER/:mode/:id?',
			name: 'form-F_PLAYER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPlayer/QFormFPlayer.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLAYER',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PLAYER_STATS/:mode/:id?',
			name: 'form-F_PLAYER_STATS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPlayerStats/QFormFPlayerStats.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'STATS',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PLAYER_TEAM/:mode/:id?',
			name: 'form-F_PLAYER_TEAM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPlayerTeam/QFormFPlayerTeam.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLAYER_TEAM',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_SKILL_PLAYER/:mode/:id?',
			name: 'form-F_SKILL_PLAYER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFSkillPlayer/QFormFSkillPlayer.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SKILL_PLAYER',
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
