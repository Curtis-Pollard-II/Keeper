<template>
    <div class="row">
        <div class="col-4">
            <h1>{{vault?.name}}</h1>
            <p class="p-3 fs-5">Total Keeps:  {{keeps.length}}</p>

        </div>
        <div class=" col-2 offset-6">
            <button v-if="vault?.creatorId == account.id" @click="deleteVault()" class="bg-success btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
  
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
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { router } from '../router';
export default {
//     props: {
//         vault: { type: Object, required: true },
//   },


setup() {
const route = useRoute()
const router = useRouter();
    async function GetVault(){
        try {
          await vaultKeepsService.GetVault(route.params.id)
        } catch (error) {
          logger.error(error)

        }
    }

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
    GetVault();
    // getPrivateVaultKeeps();
  })


  return {
    account: computed(() => AppState.account),
    keeps: computed(() => AppState.activeVaultKeeps),
    vault: computed(() => AppState.activeVault),

    async deleteVault() {
      try {
        const yes = await Pop.confirm('Are you sure you want to delete this vault?')
        if (!yes) {
          return;
        }
        await vaultKeepsService.deleteVault(route.params.id)
        router.push({name: 'Home'})
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    }

  };
},
};
</script>


<style> 

</style>