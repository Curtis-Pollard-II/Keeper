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
                                <div class="pt-2 text-center d-flex justify-content-around">
                                       <p>Views: {{keep?.views}}</p> 
                                       <p>Kept: {{keep?.kept}}</p> 
                                    </div>
                                <div>
                                    <div class="pt-2 text-center">
                                        <h2 class="border-bottom ">{{keep?.name}}</h2>
                                    </div>
                                    <div class="pt-2">
                                        <p class="fs-5">{{keep?.description}}</p>
                                    </div>
                                 
                                </div>
                            </div>
                    </div>
                </div>
                <div class="modal-footer d-flex justify-content-between">
                    <div>
                        <img class="rounded-circle selectable z-depth-2 img-size" :src="keep?.creator.picture"/>
                    </div>
                        

                    <div class="dropdown">
                        <button  title="Open Vault Form" class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Add to Vault
                            <ul class="dropdown-menu">
                                <li><a  v-for="v in vaults" :key="v.name" class="dropdown-item" @click="createVaultKeep(v.id)">{{v.name}}</a></li>
                            </ul>
                        </button>
                    </div>
                    <div v-if="keep?.vaultKeepId && keep?.creatorId == account.id">
                        <button  title="Remove From this Vault"  @click="removeFromVault(keep.vaultKeepId)" class="bg-primary btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
                    </div>
                    <div v-else-if="keep?.creatorId == account?.id ">
                        <button title="Delete Keep"  @click="deleteKeep(keep)" class="bg-success btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
    <!-- v-if="vaultKeep?.creatorId" -->

</template>


<script>
import { computed } from '@vue/runtime-core';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import { router } from '../router';
import { logger } from '../utils/Logger';
import { AppState } from '../AppState';
import { vaultKeepsService } from '../services/VaultKeepsService';
import { Modal } from 'bootstrap';
export default {

setup() {

    return {
    account: computed(() => AppState.account),
    keep: computed(() => AppState.activeKeep),
    vaults: computed(() => AppState.activeProfileVaults),
    // vaultKeep: computed(() => AppState.activeVaultKeep),

    async deleteKeep(keep) {
        try {
        const yes = await Pop.confirm('Are you sure you want to delete this Keep?')
        if (!yes) {
            return;
    }
    Modal.getOrCreateInstance(document.getElementById("keepModal")).hide();
        await keepsService.deleteKeep(keep?.id)
        // router.push({name: 'Home'})
        } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
        }
    },

    async createVaultKeep(vaultId){
        try {
            let vaultKeep = {vaultId: vaultId, keepId: AppState.activeKeep.id}
          await vaultKeepsService.createVaultKeep(vaultKeep)
          this.keep.kept++
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
    },
    async removeFromVault(id){
                try {
                const yes = await Pop.confirm('Do you want to remove this keep from your Vault?')
                if (!yes){
                    return;
                }
                Modal.getOrCreateInstance(document.getElementById("keepModal")).hide();
                await vaultKeepsService.removeFromVault(id)
                } catch (error) {
                logger.error(error)
                Pop.toast(error.message, 'error')
                logger.log(props.keep.vaultKeepId)
                }
            },
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