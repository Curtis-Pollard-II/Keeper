<template>
    <div class="modal fade" id="keep-form" role="dialog">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h4 class="modal-title">Create A Vault</h4>
          </div>
          <div class="modal-body">
              <div class="col-6">
                  <label class="form-label" for="name" > <h5>Name of Keep</h5> </label>
                  <input v-model="editable.name" class="form-control" type="text" minlength="50" id="name" name="name">
              </div>
              <div class="col-10">
                  <label class="form-label" for="img_url">Insert Image Url</label>
                  <input v-model="editable.img" class="form-control" type="text" id="img_url" name="img_url" >
              </div>
              <div class="col-12">
                  <label class="form-label" for="description">Description</label>
                  <input v-model="editable.description" class="form-control" type="text-area" id="description" name="description" >
              </div> 
          </div>
          <div class="modal-footer">
              <button type="submit" @click="handleSubmit()" class="btn btn-primary w-100 p-2 mt-3 text-light" data-bs-dismiss="modal">Submit</button>
          </div>
        </div>
        
      </div>
    </div>
      
  </template>
  
  
  <script>
  import { ref } from '@vue/reactivity';
  import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService';
  
  
  export default {
  setup() {
      const editable = ref({})
    return {
      editable,
      async handleSubmit() {
          try {
            logger.log('creating keep', editable.value);
            await keepsService.createKeep(editable.value);
          } catch (error) {
            logger.error(error)
          }
      }
    };
  },
  };
  </script>
  
  
  <style> 
  
  
  </style>
  