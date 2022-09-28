<template>
      <div class="row">


        <div class="col-md-4 p-4">
          <img class="img-fluid profile-pic rounded-circle z-depth-2" :src="profile?.picture" alt="">
        </div>
        <div class="col-md-8 text-center py-3">
            <h1 class="text-danger pt-2">
              {{profile?.name}}
              {{keeps?.kept}}
            </h1> 
        </div>
<hr>
        <div class="container">
          <div class="row d-flex justify-content-center">
            <div class="col-md-3" v-for="v in vaults" :key="v.id">
                <VaultCard :vault="v"/>
            </div>
          </div>
        </div>
<hr>
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
.profile-pic {
  max-width: 200px;
  width: auto;
  opacity: 0.9;
}

</style>