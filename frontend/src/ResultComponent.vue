<template>
    <div class="container h-100">
        <div class="row d-flex h-100 justify-content-center align-items-center">
            <div class="col col-12">
                <div class="card p-3 w-100">
                    <div class="row d-flex justify-content-center align-items-center overflow">
                        <table class="table">
                            <thead class="row d-flex justify-content-center">
                                <tr class="row">
                                    <th class="col col-4" style="border-bottom-width: 0px">
                                        Nome
                                    </th>
                                    <th class="col col-4" style="border-bottom-width: 0px">
                                        Nota
                                    </th>
                                    <th class="col col-4" style="border-bottom-width: 0px">
                                        R$
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="row" v-for="item in results" :key="item">
                                    <td class="col col-4" style="border-bottom-width: 0px">
                                        {{item.Name}}
                                    </td>
                                    <td class="col col-4" style="border-bottom-width: 0px">
                                        {{item.mNote.toFixed(2)}}
                                    </td >
                                    <td class="col col-4" style="border-bottom-width: 0px">
                                        {{item.Value.toFixed(2)}}
                                    </td>
                                </tr>
                            </tbody>

                        </table>
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
            results: [{
                name:"marcos",
                mNote:12.2,
                Value: 200.2
            }]
        }

    },
    mounted() {
        axios.get("http//179.189.18.106:5034/results").then(x => {
            console.log(x.data)
            this.results = x.data
        }).catch(e => {
            console.log(e)
        })
    }

}
</script>
<style>
.overflow{
    height: 450px!important;
    overflow-y: scroll!important;
    overflow-x: hidden!important;
}
</style>