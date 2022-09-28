<template>
    <div class="row">
        <div class="col-4">
            <!-- <h1>{{vault.name}}</h1> -->
        </div>
        <div class="col-2 offset-6">
            <button>Delete Vault</button>
        </div>

        <div class="container">
          <div class="row d-flex justify-content-center">
            <div class="col-md-3" v-for="k in keeps" :key="k.id">
                <KeepCard :keep="k"/>
            </div>
          </div>
        </div>
    </div>



</template>


<script>
import { vaultKeepsService } from '../services/VaultKeepsService';
import { computed, onMounted } from '@vue/runtime-core';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger';
import { AppState } from '../AppState';
export default {
    props: {
        vault: { type: Object, required: true },
  },


setup() {
const route = useRoute()

    async function getVaultKeeps(){
        try {
          await vaultKeepsService.getVaultKeeps(route.params.id)
        } catch (error) {
          logger.error(error)
        }
    }
    // async function getPrivateVaultKeeps(){
    //     try {
    //       await vaultKeepsService.getPrivateVaultKeeps(route.params.id)
    //     } catch (error) {
    //       logger.error(error)
    //     }
    // }

onMounted(()=> {
    getVaultKeeps();
    // getPrivateVaultKeeps();
  })


  return {

    keeps: computed(() => AppState.activeVaultKeeps),
  };
},
};
</script>


<style> 

</style>