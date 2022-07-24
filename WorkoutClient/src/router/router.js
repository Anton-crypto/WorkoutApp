import { createWebHashHistory, createRouter } from "vue-router";

import Main from '@/pages/Main'
import Login from '@/pages/Login'
import Exercises from '@/pages/Exercis/Exercises'

const routes = [
    {
        path: '',
        component: Main
    },
    {
        path: '/exercis',
        component: Exercises
    },
    {
        path: '/login',
        component: Login
    },
]

const router = createRouter({
    history: createWebHashHistory(),
    routes,
})

export default router;