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
                    <img class="rounded-circle z-depth-2" :src="keep.creator.picture"/>
                    <div class="p-3">
                        <button class="bg-secondary btn btn-pill fs-4">Add to Vault</button>
                        <button class="bg-success btn btn-pill mdi mdi-trash-can-outline mdi-24px"></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>


<script>
import { computed } from '@vue/runtime-core';
import { AppState } from '../AppState';
export default {
setup() {
  return {
    keep: computed(()=> AppState.activeKeep)
  };
},
};
</script>


<style> 
</style>