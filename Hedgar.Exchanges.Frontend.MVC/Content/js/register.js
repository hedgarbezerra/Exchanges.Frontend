var app = new Vue({
    el: '#vueApp',
    data: {
        isLoading: false,
        showPassword: false,
        showConfirmation: false,
        user:{
            name:'',
            dtBirth: '',
            email: '',
            password: '',
            passwordConfirmation: ''
        }
    },
    methods: {
        validateSignupForm(){
            validarForm(this.$refs.formSignup, ()=>{
                this.isLoading = true;
                this.finishSignup();
            })
        },
        finishSignup(){
            fazerRequest(`${window.location.origin}/v1/api/authentication/signup`, REQUESTMETHOD.POST, this.user).then(({ data, success, message})  => {
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
    created(){        
        Vue.use(Toasted, toastOptions);
        customValidators();
    }
})