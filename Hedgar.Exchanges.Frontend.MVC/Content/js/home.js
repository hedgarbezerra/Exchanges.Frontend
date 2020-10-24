var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        exchangeFrom: "",
        exchangeTo: "",
        exchangeValue: 0,
        exchangeConvertedValue: 0,
        exchangeToRate: 0,
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
            
        },
        validateExchangeform (){
            validarForm(this.$refs.formExchange, ()=>{
                this.isLoading = true;
                this.commitExchange();
            })
        },
        commitExchange(){
            var exchange = {
                TickerFrom : this.exchangeFrom.id,
                TickerTo: this.exchangeTo.id,
                Value: this.exchangeValue,

            };

            fazerRequest(`${window.location.origin}/v1/api/exchanges/save`, REQUESTMETHOD.POST, exchange)
                .then(({ data, message, success }) =>{
                    this.exchangeFrom = null;
                    this.exchangeTo = null;
                    this.exchangeValue = 0;

                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    this.isLoading = false;
                })            
                .catch(err => {
                    toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                    this.isLoading = false;
                })
        },
        updateExchangeRate(){ 
            fazerRequest(`${window.location.origin}/v1/api/currencies/specificrate?idFrom=${this.exchangeFrom.id}&idTo=${this.exchangeTo.id}`, REQUESTMETHOD.GET)
                .then(({ data, message, success }) =>{
             
                    this.exchangeToRate = data.rate;

                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    this.isLoading = false;
                })            
                .catch(err => {
                    toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                    this.isLoading = false;
                })
        },

    },
     computed:{
        formatedExchangeTo(){
            let time = (this.exchangeTo != null && this.exchangeTo.price_timestamp != undefined) ? this.exchangeTo.price_timestamp : moment().format('YYYY-MM-DD');
            
            return moment(time).fromNow();
            //return moment(time).format('MM/DD/YYYY [at] HH:MM')
        },
        formatedExchangeFrom(){
            let time = (this.exchangeFrom != null && this.exchangeFrom.price_timestamp != undefined) ? this.exchangeFrom.price_timestamp : moment().format('YYYY-MM-DD');

            return moment(time).fromNow();
            //return moment(time).format('MM/DD/YYYY [at] HH:MM')
        },        
        formFilled(){
            return this.exchangeFrom != null && this.exchangeTo != null && this.exchangeFrom != "" && this.exchangeTo != "" && this.exchangeFrom != this.exchangeTo;
        }
    },
    watch:{
        formFilled : function(val){
            if(val){
                 this.updateExchangeRate();
            }
        },
        exchangeValue: function(val){
            this.exchangeConvertedValue = val * this.exchangeToRate;
        }
    },
    created(){        
        Vue.use(Toasted, toastOptions);
        Vue.component('v-select', VueSelect.VueSelect);
        Vue.use(VMoney.Money, {prefix: "", suffix: "", thousands: ",", decimal: ".", precision: 4});
        customValidators();
    },
    mounted(){
        this.getCurrencyTickers();
    }
})