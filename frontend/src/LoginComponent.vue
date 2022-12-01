<template>
    <div class="container-fluid h-100">
        <div class="row d-flex h-100 justify-content-center align-items-center m-0">
            <div class="col col-xl-5 col-lg-7 col-md-8">
                <div class="card boxShadow" style="border-radius: 1rem;">
                    <div class="row g-0">
                        <div class="col-12 d-flex align-items-center">
                            <div class="card-body">
                                <form>
                                    <div class="d-flex align-items-center justify-content-center">
                                        <span class="h3" style="font-family:'montserrat'">Entre com seu código único</span>
                                    </div>
                                    <div class="form-outline d-flex align-items-center justify-content-center">
                                        <input type="text" placeholder="xxxxxx" id="codeInput" class="form-control form-control-lg inputShadow" v-model="code"/>
                                        <button style="font-family:'montserrat'" class="btn btn-success bi-check inputShadow m-2" @click="checkCode
                                        "></button>
                                    </div>
                                </form>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </div>

    </div>
</template>
<script>
let codes = [
    {"name": "larissa", "code": "120b9jk9k", "used": false},
    {"name": "marcos", "code": "12556616", "used": false},
    {"name": "leandro", "code": "oaksfok1", "used": false}
]
export default {
   data(){
    return {
        codes: codes,
        code: ''
    }
   },
    methods:{
        checkCode(){
           codes.forEach(x => {
            if(this.code == x.code && !x.used){
                x.used = true;
                this.$router.push('/main')
            }
           })
        }
    }
}
</script>
<style>
.fullVh{
    height: 100vh;
}
.boxShadow{
    box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
}
.inputShadow{
    box-shadow: rgba(0, 0, 0, 0.3) 0px 15px 30px, rgba(0, 0, 0, 0.22) 0px 10px 8px;
    border-radius: 2px solid!important;
}
</style>