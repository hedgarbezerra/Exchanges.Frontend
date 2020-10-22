var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        tickers: []

    },
    methods: {
        getCurrencyTickers(){
            fazerRequest(`${window.location.origin}/v1/api/currencies/list`, REQUESTMETHOD.GET)
            .then(({ data, message, success }) =>{
                this.tickers = data;
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
    },
    mounted(){
        this.getCurrencyTickers();
    }
})