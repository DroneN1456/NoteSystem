import { createApp } from 'vue'
import App from './App.vue'
import Login from './LoginComponent.vue'
import Main from './MainComponent.vue'
import { createRouter, createWebHashHistory } from 'vue-router'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'



const routes = [
    { path: "/", redirect:'/login'},
    { path: "/main", component: Main},
    { path: "/login", component: Login}
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})





createApp(App).use(router).mount("#app")
