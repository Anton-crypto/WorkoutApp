import { createStore } from 'vuex'

const store = createStore({
    state: {
        localStorageName: 'products',
    },
    getters: {
        products: state => {
            if (localStorage.getItem(state.localStorageName)) {
                try {
                    return JSON.parse(localStorage.getItem(state.localStorageName))
                } catch(e) {
                    localStorage.removeItem(state.localStorageName);
                }
            }
            return null;
        },
    },
    mutations: {
        deleteProduct(state, products) {
            localStorage.setItem(state.localStorageName, JSON.stringify(products));
        },
        addProduct(state, product) {
            localStorage.setItem(state.localStorageName, JSON.stringify(product));
        }
    },
    actions: {},
    modules: {}
})

export default store
  