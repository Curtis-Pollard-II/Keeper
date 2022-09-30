<template>
  <div class="modal fade" id="vault-form" role="dialog">
    <form class="modal-dialog" id="form">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">Create A Vault</h4>
        </div>
        <div class="modal-body">
            <div class="col-6">
                <label class="form-label" for="name" > <h5>Name of Vault</h5> </label>
                <input v-model="editable.name" class="form-control" type="text"  id="name" name="name" required>
            </div>
            <div class="col-10">
                <label class="form-label" for="img_url">Insert Image Url</label>
                <input v-model="editable.img" class="form-control" type="text" id="img_url" name="img_url" required>
            </div>
            <div class="col-12">
                <label class="form-label" for="description">Description</label>
                <input v-model="editable.description" class="form-control" type="text-area" id="description" name="description" required>
            </div>
            <div>
                <label  for="isPrivate">Make this vault Private?</label><br>
                <input v-model="editable.isPrivate" type="checkbox" id="isPrivate" name="isPrivate" >
            </div>    
        </div>
        <div class="modal-footer">
            <button  id="button-submit-form" title="Add Vault" type="submit" @click="handleSubmit()" class="btn btn-primary w-100 p-2 mt-3 text-light" data-bs-dismiss="modal">Submit</button>
        </div>
      </div>
      
    </form>
  </div>
    
</template>


<script>
import { ref } from '@vue/reactivity';
import { vaultKeepsService } from '../services/VaultKeepsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';


export default {
setup() {
    const editable = ref({})
  return {
    editable,
    async handleSubmit() {
        try {
          logger.log('creating vault', editable.value);
          await vaultKeepsService.createVault(editable.value);
          editable.value = {};
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
