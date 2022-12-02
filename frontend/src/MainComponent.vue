<template>
    <div class="container h-100">
        <div class="row d-flex h-100 justify-content-center align-items-center">
            <div class="col col-12">
                <div class="card p-1">
                    <div class="row d-flex align-items-center justify-content-center">
                        <div class="row">
                            <div class="card boxShadow">
                                <div class="row d-flex justify-content-start">
                                    <div class="col col-12">
                                        <div class="card-title upperCard">23/30</div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col col-12">
                                        <div class="card-title upperCard">Nome: Jonas</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="card boxShadow">
                                <div class="row d-flex justify-content-start align-items-center">
                                    <div class="col col-3">
                                        <div class="upperCard">Nota: </div>
                                    </div>
                                    <div class="col col-9">
                                        <input type="number" id="notaInput" placeholder="0.0" class="form-control form-control-lg" />
                                    </div>
                                </div>
                                <div class="row d-flex justify-content-start align-items-center">
                                    <div class="col col-3">
                                        <div class="upperCard">Motivo: </div>
                                    </div>
                                    <div class="col col-9">
                                        <input type="text" id="motivoInput" placeholder="Porque ele..." class="form-control form-control-lg" />
                                    </div>
                                    
                                </div>
                                <div class="row d-flex justify-content-start align-items-center">
                                    <div class="col col-12">
                                        <button class="btn btn-success bi-check w-100 m-2 boxShadow" @click="nextPerson"></button>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</template>
<script>
//import axios from 'axios'



export default {
    methods: {
        toLogin() {
            this.$router.push("/login")
        },
        nextPerson(){
            //call api setting current person

            //change to the next person in list
            
        }
    },
}
</script>
<style>
.upperCard {
    font-size: 1rem;
    font-family: 'montserrat';
    font-weight: bolder;
}

.boxShadow {
    box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px inset;
}

</style>