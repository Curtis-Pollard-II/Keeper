<template>
        <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body ">
                    <div class="row">
                            <div class="col-6">
                                <img class="img-fluid" :src="keep?.img" alt="">
                            </div>
                            <div class="col-6">
                                <div class="text-center">
                                    <div class="pt-2">
                                        <h1 class="border-bottom ">{{keep?.name}}</h1>
                                    </div>
                                    <div class="pt-2">
                                        {{keep?.description}}
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
                <div class="modal-footer d-flex justify-content-between">
                  
                        <img class="rounded-circle selectable z-depth-2 img-size" :src="keep?.creator.picture"/>
                      
                    <div class="p-0">
                        <button class="bg-secondary btn btn-pill fs-4">Add to Vault</button>
                        <button v-if="keep?.creatorId == account?.id" @click="deleteKeep(keep)" class="bg-success btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>


<script>
import { computed } from '@vue/runtime-core';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import { router } from '../router';
import { logger } from '../utils/Logger';
export default {

setup() {

  return {
    account: computed(() => AppState.account),
    keep: computed(() => AppState.activeKeep),

    async deleteKeep(keep) {
        try {
          const yes = await Pop.confirm('Are you sure you want to delete this Keep?')
          if (!yes) {
            return;
          }
          await keepsService.deleteKeep(keep?.id)
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
.img-size{
    max-width: 50px;
    width: auto;
}
</style>