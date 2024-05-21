import { createRouter, createWebHistory } from 'vue-router'
import Register from '@/view/Register.vue'
import Login from '@/view/Login.vue'
import Customer from '../view/customerManagerView.vue'
import Search from '../view/CustomerManagerSerach.vue'

const routes = [
  { path: '/register', component: Register },
  { path: '/', component: Login },
  { path: '/customer', component: Customer },
  { path: '/customer/search', component: Search, props: true  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
