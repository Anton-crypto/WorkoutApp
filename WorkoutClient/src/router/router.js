import { createWebHashHistory, createRouter } from "vue-router";

import Main from '@/pages/Main'
import Exercises from '@/pages/Exercis/Exercises'

const routes = [
    {
        path: '',
        component: Main
    },
    {
        path: '/exercis',
        component: Exercises
    }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes,
})

export default router;