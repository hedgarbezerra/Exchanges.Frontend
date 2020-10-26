var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        userExchanges: []
    },
    methods: {
        getExchanges(){
            this.isLoading = true;

            fazerRequest(`${window.location.origin}/v1/api/exchanges/list`, REQUESTMETHOD.GET)
            .then(({ data, message, success }) =>{
                this.userExchanges = data;

                toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                this.isLoading = false;
            })            
            .catch(err => {
                toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                this.isLoading = false;
            })
        }    
    },
    computed:{

    },
    watch:{

    },
    created(){        
        Vue.use(Toasted, toastOptions);
        customFilters();
    },
    mounted(){
       this.getExchanges();
    }
})