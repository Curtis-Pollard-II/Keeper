<template>
    <div class="row">
        <div class="col-4">
            <h1>{{vault?.name}}</h1>
            <p class="p-3 fs-5">Total Keeps:  {{keeps.length}}</p>

        </div>
        <div class="p-4 col-2 offset-6">
            <button title="Delete Vault" v-if="vault?.creatorId == account.id" @click="deleteVault()" class="bg-info btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
  
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
export default {



setup() {
const route = useRoute()
const router = useRouter();
    async function GetVault(){
        try {
          await vaultKeepsService.GetVault(route.params.id)
        } catch (error) {
          logger.error(error)
          Pop.error(error.message)
          router.push({name: 'Home'})
        }
    }


    async function getVaultKeeps(){
        try {
          await vaultKeepsService.getVaultKeeps(route.params.id)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
    }


onMounted(()=> {
    getVaultKeeps();
    GetVault();

  })


  return {
    account: computed(() => AppState.account),
    keeps: computed(() => AppState.vaultKeeps),
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