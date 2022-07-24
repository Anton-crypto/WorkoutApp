import { createApp } from 'vue'
import App from './App.vue'

import store from './store/index.js'
import router from './router/router.js'


import components from '@/components/UI'
import directives from '@/directives'

import axios from 'axios'
import VueAxios from 'vue-axios'

import VIntersection from './directives/VIntersection'

const app = createApp(App)

if(components != undefined) {
    components.forEach(component => {
        app.component(component.name, component)
    });
}
if(directives != undefined) {
    directives.forEach(directive => {
        app.component(directive.name, directive)
    });
}

const token = localStorage.getItem('user-token')

if (token) {
  axios.defaults.headers.common['Authorization'] = token
}

app.use(store)
app.use(router)
app.use(VueAxios, axios)


app.directive('intersection', VIntersection)

app.mount('#app')   