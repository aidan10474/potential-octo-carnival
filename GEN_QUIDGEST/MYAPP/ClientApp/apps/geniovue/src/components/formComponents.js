import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFPlayer', defineAsyncComponent(() => import('@/views/forms/FormFPlayer/QFormFPlayer.vue')))
		app.component('QFormFPlayerStats', defineAsyncComponent(() => import('@/views/forms/FormFPlayerStats/QFormFPlayerStats.vue')))
		app.component('QFormFPlayerTeam', defineAsyncComponent(() => import('@/views/forms/FormFPlayerTeam/QFormFPlayerTeam.vue')))
		app.component('QFormFSkillPlayer', defineAsyncComponent(() => import('@/views/forms/FormFSkillPlayer/QFormFSkillPlayer.vue')))
	}
}
