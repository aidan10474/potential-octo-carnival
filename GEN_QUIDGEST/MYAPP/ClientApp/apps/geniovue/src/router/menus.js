// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/PRJ/menu/PRJ_31',
			name: 'menu-PRJ_31',
			component: () => import('@/views/menus/ModulePRJ/MenuPRJ_31/QMenuPrj31.vue'),
			meta: {
				routeType: 'menu',
				module: 'PRJ',
				order: '31',
				baseArea: 'SKILL_PLAYER',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PRJ/menu/PRJ_11',
			name: 'menu-PRJ_11',
			component: () => import('@/views/menus/ModulePRJ/MenuPRJ_11/QMenuPrj11.vue'),
			meta: {
				routeType: 'menu',
				module: 'PRJ',
				order: '11',
				baseArea: 'PLAYER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PRJ/menu/PRJ_21',
			name: 'menu-PRJ_21',
			component: () => import('@/views/menus/ModulePRJ/MenuPRJ_21/QMenuPrj21.vue'),
			meta: {
				routeType: 'menu',
				module: 'PRJ',
				order: '21',
				baseArea: 'PLAYER_TEAM',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/PRJ/menu/PRJ_41',
			name: 'menu-PRJ_41',
			component: () => import('@/views/menus/ModulePRJ/MenuPRJ_41/QMenuPrj41.vue'),
			meta: {
				routeType: 'menu',
				module: 'PRJ',
				order: '41',
				baseArea: 'STATS',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
