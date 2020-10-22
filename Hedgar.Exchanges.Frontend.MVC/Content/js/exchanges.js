var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        userExchanges: []
    },
    methods: {

    },
    computed:{

    },
    watch:{

    },
    created(){        
        Vue.use(Toasted, toastOptions);
    },
    mounted(){
       
    }
})