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
                                        <div class="card-title upperCard">{{ currentUser + 1 + "/" + users.length }}</div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col col-12">
                                        <div class="card-title upperCard">Nome: {{ currentName }}</div>
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
                                        <input type="number" id="notaInput" placeholder="0.0"
                                            class="form-control form-control-lg" min="1" max="10"
                                            v-model="currentNota" @keypress="enterHanlder"/>
                                    </div>
                                </div>
                                <div class="row d-flex justify-content-start align-items-center">
                                    <div class="col col-3">
                                        <div class="upperCard">Motivo: </div>
                                    </div>
                                    <div class="col col-9">
                                        <input type="text" id="motivoInput" placeholder="Porque ele..."
                                            class="form-control form-control-lg " @keypress="enterHanlder" />
                                    </div>

                                </div>
                                <div class="row d-flex justify-content-start align-items-center">
                                    <div class="col col-12">
                                        <button class="btn btn-success bi-check w-100 m-2 boxShadow"
                                            @click="nextPerson"></button>
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
import axios from 'axios'



export default {
    data() {
        return {
            users: [],
            currentUser: 0,
            currentName: "",
            currentNota: 0.0,
        }
    },
    methods: {
        enterHanlder(e){
            if(e.key == "Enter"){
                this.nextPerson()
            }
        },
        toLogin() {
            this.$router.push("/login")
        },
        setActualPerson() {
            this.currentName = this.users[this.currentUser].Name;
            this.currentNota = this.users[this.currentUser].Note;
            var userName = localStorage.getItem("username")
            if(userName == this.currentName){
                this.nextPerson();
            }
        },
        nextPerson() {
            var token = localStorage.getItem("token")
            var userName = localStorage.getItem("username")
            if(userName == this.currentName){
                this.currentUser++;
                this.setActualPerson();
                return;
            }
            if (this.currentUser+1 >= this.users.length) {
                axios.post("http//179.189.18.106:5034/results", {
                    users: this.users
                }, {
                    headers: {
                        "Authorization": `Bearer ${token}`
                    }
                }).catch(e => {
                    alert(e)
                    alert(token)
                    this.toLogin()
                }).then(x => {
                    console.log(x)
                    this.$router.push("/results")
                })
            }



            //call api setting current person
            this.users[this.currentUser].Note = this.currentNota;
            if(this.users[this.currentUser].Note > 10){
                this.users[this.currentUser].Note = 10
            }else if(this.users[this.currentUser].Note < 0){
                this.users[this.currentUser].Note = 0
            }


            //change to the next person in list
            this.currentUser++;
            this.setActualPerson();

        }
    },
    mounted() {
        var token = localStorage.getItem("token")

       setTimeout(() => {
        axios.get("http//179.189.18.106:5034/users", {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        }).then(x => x.data.forEach(xy => {
            this.users.push(xy)
        })).catch(e => {
            alert(e)
            setTimeout(() => {
                this.$router.push('/login')
            }, 2000);
        }).finally(x => {
            console.log(x)
            this.setActualPerson()
        })
        
       }, 1000);

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