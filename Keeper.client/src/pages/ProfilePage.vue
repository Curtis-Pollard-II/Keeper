<template>
      <div class="row">
        <div class="col-12 text-center py-3">
            <h1 class="text-danger pt-2">
              {{profile?.name}}
            </h1>
        </div>

        <div class="container">
          <div class="row d-flex justify-content-center">
            <div class="col-md-4" v-for="v in vaults" :key="v.id">
                <VaultCard :vaults="v"/>
            </div>
          </div>
        </div>

        <div class="bg-danger">{{vaults?.name}}</div>



        
      </div>

</template>


<script>
import { computed, onMounted } from '@vue/runtime-core';
import {  useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { profilesService } from '../services/ProfilesService';
import { logger } from '../utils/Logger';
export default {

  

setup() {

const route = useRoute()

  async function getProfileById(){
    try {
      await profilesService.getProfileById(route.params.id)
    } catch (error) {
      logger.error(error)
    }
  }
  
  async function getVaultsByProfileId(){
    try {
      await profilesService.getVaultsByProfileId(route.params.id)
    } catch (error) {
      logger.error(error)
    } 
  }

  async function getKeepsByProfileId(){
    try {
      await profilesService.getKeepsByProfileId(route.params.id)
    } catch (error) {
      logger.error(error)
    } 
  }

  onMounted(()=> {
    getProfileById();
    getVaultsByProfileId();
    getKeepsByProfileId();
  })
  return {
    profile: computed(() => AppState.activeProfile),
    keeps: computed(() => AppState.activeProfileKeeps),
    vaults: computed(() => AppState.activeProfileVaults),
  };
},
};
</script>


<style> 

</style>