import { createStore } from 'vuex'


const AUTH_REQUEST = "AUTH_REQUEST";
const AUTH_SUCCESS = "AUTH_SUCCESS";
const AUTH_ERROR = "AUTH_ERROR";
const AUTH_LOGOUT = "AUTH_LOGOUT";
const USER_REQUEST = "USER_REQUEST";
// const USER_SUCCESS = "USER_SUCCESS";
// const USER_ERROR = "USER_ERROR";

const store = createStore({
    state: {
        token: localStorage.getItem('user-token') || '',
        status: '',
    },
    getters: {
        isAuthenticated: state => !!state.token,
        authStatus: state => state.status,
    },
    mutations: {},
    actions: {
        [AUTH_REQUEST]: ({commit, dispatch}, user) => {
            return new Promise((resolve, reject) => {
                commit(AUTH_REQUEST)
                this.axios.post({url: 'auth', data: user, method: 'POST' })
                .then(resp => {
                    const token = resp.data.token
                    localStorage.setItem('user-token', token)
                    // Add the following line:
                    this.axios.defaults.headers.common['Authorization'] = token
                    commit(AUTH_SUCCESS, resp)
                    dispatch(USER_REQUEST)
                    resolve(resp)
                })
                .catch(err => {
                    commit(AUTH_ERROR, err)
                    localStorage.removeItem('user-token')
                    reject(err)
                })
            })
        },
        [AUTH_LOGOUT]: ({commit}) => {
            return new Promise((resolve) => {
                commit(AUTH_LOGOUT)
                localStorage.removeItem('user-token')
                delete this.axios.defaults.headers.common['Authorization']
                resolve()
            })
        },
    },
    modules: {
        [AUTH_REQUEST]: (state) => {
            state.status = 'loading'
        },
        [AUTH_SUCCESS]: (state, token) => {
            state.status = 'success'
            state.token = token
        },
        [AUTH_ERROR]: (state) => {
            state.status = 'error'
        },
    }
})

export default store
  