var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        showPassword: false,
        user:{
            email: '',
            password: ''
        }
    },
    methods: {
        validateLoginForm(){
            validarForm(this.$refs.formLogin, ()=>{
                this.isLoading = true;
                this.authenticate();
            })
        },
        authenticate(){
            fazerRequest(`${window.location.origin}/v1/api/authentication/login`, REQUESTMETHOD.POST, this.user).then(({ data, success, message})  => {
                if(success){
                    toastMessage(message, TOASTMETHOD.SUCCESS, 'check_circle_outline');
                    setTimeout(() => window.location.replace('Login'), 2000)
                }
                else
                    toastMessage(message, TOASTMETHOD.ERROR, 'error_outline');
                    
                this.isLoading = false;
            }).catch(err => {
                this.isLoading = false;
                toastMessage(err.response.data.ExceptionMessage == undefined ? 'Oops, something went wrong.' : err.response.data.ExceptionMessage, TOASTMETHOD.ERROR, 'error_outline')
            });
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
       
    }
})