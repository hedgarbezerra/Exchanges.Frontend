var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        exchangeFrom: "",
        exchangeTo: "",
        exchangeValue: 0,
        exchangeConvertedValue: 0,
        exchangeRates: [],
        graphData: [],
        tickers: []

    },
    methods: {
        getCurrencyTickers(){
            this.isLoading = true;

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

            this.isLoading = true;

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
        getExchangeRates(){ 
            if(this.exchangeFrom == null)
                return false;
                
            this.isLoading = true;
            
            fazerRequest(`${window.location.origin}/v1/api/currencies/rates?id=${this.exchangeFrom.id}`, REQUESTMETHOD.GET)
                .then(({ data, message, success }) =>{
             
                    this.exchangeRates = data;

                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    this.isLoading = false;
                })            
                .catch(err => {
                    toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                    this.isLoading = false;
                })
        },
        loadChart(){

            fazerRequest(`${window.location.origin}/v1/api/currencies/graph?ids=${this.exchangeFrom.id},${this.exchangeTo.id}`, REQUESTMETHOD.GET)
                .then(({ data, message, success }) =>{             
                    this.graphData = data;

                    var ctx = document.getElementById('ratesChart');

                    var dataExchangeFrom = data.find(x => x.currency == this.exchangeFrom.id);                      
                    var dataExchangeTo = data.find(x => x.currency == this.exchangeTo.id);

                    var fixedExchangeFromData = dataExchangeFrom.prices.map(function(item, i){ return { y: currency(item, currencyOptions).value, x : new Date(this[i]) } }, dataExchangeFrom.timestamps);
                    var fixedExchangeToData = dataExchangeTo.prices.map(function(item, i){ return { y: currency(item, currencyOptions).value, x : new Date(this[i]) } }, dataExchangeTo.timestamps);

                    var myChart = new Chart(ctx,  {
                        type: 'bar',
                        data: {
                            datasets: [{
                                label: `Rates variation for ${dataExchangeFrom.currency}`,
                                backgroundColor: '#2c53a9',
                                borderColor: '#2c53a9',
                                fill: false,
                                data: fixedExchangeFromData,
                            }, {
                                label: `Rates variation for ${dataExchangeTo.currency}`,
                                backgroundColor: '#FF0000',
                                borderColor: '#FF0000',
                                fill: false,
                                data: fixedExchangeToData
                            }]
                        },
                        options: {
                            responsive: true,
                            title: {
                                display: true,
                                text: `Last month's currency variations(in USD)`
                            },
                            scales: {
                                xAxes: [{
                                    type: 'time',
                                    display: true,
                                    scaleLabel: {
                                        display: true,
                                        labelString: 'Date'
                                    },
                                    ticks: {
                                        major: {
                                            fontStyle: 'bold',
                                            fontColor: '#FF0000'
                                        }
                                    }
                                }],
                                yAxes: [{
                                    display: true,
                                    scaleLabel: {
                                        display: true,
                                        labelString: 'USD'
                                    }
                                }]
                            }
                        }
                    });

                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    this.isLoading = false;
                })            
                .catch(err => {
                    toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                    this.isLoading = false;
                });           
        }
    },
     computed:{
        formatedExchangeRateDate(){            
            return  moment(this.exchangeToRate.time).fromNow();
        },        
        formFilled(){
            return this.exchangeFrom != null && this.exchangeTo != null && this.exchangeFrom != "" && this.exchangeTo != "" && this.exchangeFrom != this.exchangeTo;
        },
        bestExchangeRate(){
            var existingCurrencies = this.exchangeRates.rates.filter((curr) => this.tickers.some(y => y.id == curr.asset_id_quote));
            
            return existingCurrencies.reduce((acc, curr) => acc.rate > curr.rate ? acc : curr);
        },
        exchangeToRate(){
            return this.exchangeRates.rates.find(x => x.asset_id_quote == this.exchangeTo.id);
        }
    },
    watch:{
        exchangeFrom: function(val, oldVal){
            if(val != oldVal){
                this.getExchangeRates();
            }

            if(val != oldVal && this.formFilled){
                this.loadChart();
            }
        },  
        exchangeTo: function(val, oldVal){
            if(val != oldVal && this.formFilled){
                this.loadChart();
            }
        },
        exchangeValue: function(val){
            this.exchangeConvertedValue = val * this.exchangeToRate.rate;
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