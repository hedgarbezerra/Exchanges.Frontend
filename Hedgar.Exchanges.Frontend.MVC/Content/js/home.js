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
             
                    this.exchangeToRate = data;

                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    this.isLoading = false;
                })            
                .catch(err => {
                    toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline');
                    this.isLoading = false;
                })
        },
        loadChart(){
            var ctx = document.getElementById('ratesChart');

            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }
    },
     computed:{
        formatedExchangeRateDate(){            
            return  moment(this.exchangeToRate.time).fromNow();
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