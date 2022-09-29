<template>
      <div class="row bg-light">


        <div class="col-md-4 p-4">
          <img class="img-fluid profile-pic rounded-circle z-depth-2" :src="profile?.picture" alt="">
        </div>
        <div class="col-md-8 text-center py-3">
            <h1 class=" display-2 text-info font-pt-2">
              {{profile?.name}}
            </h1> 
            <p class="display-6">Vaults:  {{vaults?.length}}</p>
            <p class="display-6">Keeps:  {{keeps?.length}}</p>

        </div>

        <div class="container bg-success">
          <h1 class="p-3 display-2 text-light">Vaults
                <span type="button" class="selectable mdi mdi-plus" data-bs-target="#vault-form" data-bs-toggle="modal"></span>
          </h1>
          <div class="row">
            <div class="col-md-2" v-for="v in vaults" :key="v.id">
                <VaultCard :vault="v"/>
            </div>
          </div>
        </div>
<hr>
        <div class="container bg-info">
          <h1 class="p-3 display-2 text-light">Keeps 
            <span type="button" class="selectable mdi mdi-plus" data-bs-target="#keep-form" data-bs-toggle="modal"></span>
          </h1>
          <div class="row">
            <div class="col-md-3" v-for="k in keeps" :key="k.id">
                <KeepCard :keep="k"/>
            </div>
          </div>
        </div>


      </div>

      <AddVaultModal/>
      <AddKeepForm/>

</template>


<script>
import { computed, onMounted } from '@vue/runtime-core';
import {  useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { profilesService } from '../services/ProfilesService';
import { logger } from '../utils/Logger';
import AddVaultModal from '../components/AddVaultModal.vue';
import AddKeepForm from '../components/AddKeepForm.vue';

export default {
    setup() {
        const route = useRoute();
        async function getProfileById() {
            try {
                await profilesService.getProfileById(route.params.id);
            }
            catch (error) {
                logger.error(error);
            }
        }
        async function getVaultsByProfileId() {
            try {
                await profilesService.getVaultsByProfileId(route.params.id);
            }
            catch (error) {
                logger.error(error);
            }
        }
        async function getKeepsByProfileId() {
            try {
                await profilesService.getKeepsByProfileId(route.params.id);
            }
            catch (error) {
                logger.error(error);
            }
        }
        onMounted(() => {
            getProfileById();
            getVaultsByProfileId();
            getKeepsByProfileId();
        });
        return {
            profile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.activeProfileKeeps),
            vaults: computed(() => AppState.activeProfileVaults),

        };
    },
    components: { AddVaultModal, AddKeepForm }
    
};
</script>


<style> 
.profile-pic {
  max-width: 200px;
  width: auto;
  opacity: 0.9;
}
h1 {
  text-shadow: 2px 2px 3px #000000;
}
</style>