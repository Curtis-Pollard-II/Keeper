<template>
    

        <div class="container-fluid p-4">
          <div class="row">
            <div class="col-2">
              <img class="img-fluid profile-pic rounded-circle" :src="profile?.picture" alt="">
            </div>
            <div class="col-md-10 text-center py-3">
            <h1 class=" display-2 text-black font-pt-2">
              {{profile?.name}}
            </h1> 
            <p class="display-6">Vaults:  {{vaults?.length}}</p>
            <p class="display-6">Keeps:  {{keeps?.length}}</p>
        </div>
          </div>
        </div>
       

        <div class="container-fluid bg-success py-3">
          <div class="row">
            <div class="col-12">
              <h1 class="p-3 display-2">Vaults
                <span v-if="profile?.id == account?.id" title="Open Vault Form" type="button" class="text-light selectable mdi mdi-plus" data-bs-target="#vault-form" data-bs-toggle="modal"></span>
          </h1>
            </div>
          </div>
          <div class="row">
            <div class="col-md-2" v-for="v in vaults" :key="v.id">
                <VaultCard :vault="v"/>
            </div>
          </div>
        </div>

        <div class="container-fluid bg-info">
          <div class="row">
            <div class="col-12">
              <h1 class="p-3 display-2 text-black">Keeps 
            <span v-if="profile?.id == account?.id" title="Open Keep Form" type="button" class=" text-light selectable mdi mdi-plus" data-bs-target="#keep-form" data-bs-toggle="modal"></span>
          </h1>
            </div>
          </div>
          <div class="row">
            <div class="col-md-3" v-for="k in keeps" :key="k.id">
                <KeepCard :keep="k"/>
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
import Pop from '../utils/Pop';

export default {
    setup() {
        const route = useRoute();
        async function getProfileById() {
            try {
                await profilesService.getProfileById(route.params.id);
            }
            catch (error) {
                logger.error(error);
                Pop.toast(error.message, 'error')
            }
        }
        async function getVaultsByProfileId() {
            try {
                await profilesService.getVaultsByProfileId(route.params.id);
            }
            catch (error) {
                logger.error(error);
                Pop.toast(error.message, 'error')
            }
        }
        async function getKeepsByProfileId() {
            try {
                await profilesService.getKeepsByProfileId(route.params.id);
            }
            catch (error) {
                logger.error(error);
                Pop.toast(error.message, 'error')
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
            account: computed(() => AppState.account),

        };
    },
    components: { AddVaultModal, AddKeepForm }
    
};
</script>


<style> 
.profile-pic {
  max-width: 200px;
  opacity: 0.9;
}
h1 {
  text-shadow: 2px 2px 3px #000000;
  font-family: DejaVu Sans Mono, monospace;
  color: #000000;

}
</style>