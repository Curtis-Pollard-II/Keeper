<template>
<!-- add router link here -->
    <div class=" container-fluid p-3">
        <div class="bg-light border p-1 elevation-2 rounded selectable" >
            <img @click="setActiveKeep()" class="img-fluid overlay" :src="keep?.img" alt="image goes here" style="width:100%;">
            <div>
                <h3 class="text-white  content with-eight">{{keep?.name}}
                    <div class="righty">
                        <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
                            <img class="rounded-circle z-depth-2 img-size selectable" :src="keep?.creator.picture"/>
                        </router-link>
                    </div>
                </h3>
            </div>    
        </div>
        <KeepModal />

    </div>
</template>


<script>
import { Modal } from 'bootstrap';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger';
import KeepModal from './KeepModal.vue';
import Pop from '../utils/Pop';
export default {
    props:{  
        keep: { type: Object, required: true },
    },

    setup(props) {
        return {
            async setActiveKeep() {
                try {
                    Modal.getOrCreateInstance(document.getElementById("keepModal")).toggle();
                    await keepsService.getOne(props.keep.id);
                }
                catch (error) {
                logger.error(error);
                Pop.toast(error.message, 'error')
                }
            },
        };
    },
    components: { KeepModal }
};
</script>


<style> 

.img-size{
    max-width: 50px;
    width: auto;
    opacity: 0.8;
    
}

.container-fluid {
    position: relative;
    font-family: Garamond, serif; 
    font-size: 24px; 
    font-style: normal; 
    font-variant: normal; 
    font-weight: 700; 
    line-height: 26.4px; 
    
}


.container-fluid .content {/* this is for the name in bottom */
    
    position: absolute; 
    bottom: 0; 
    left: 10px;
    width: 100%; 
    padding: 20px; 

}

.with-eight {
    text-shadow:
        0.05em 0 black,
        0 0.05em black,
        -0.05em 0 black,
        0 -0.05em black,
        -0.05em -0.05em black,
        -0.05em 0.05em black,
        0.05em -0.05em black,
        0.05em 0.05em black;
}


.righty{
    position: absolute;
    bottom: 13px;
    right: 36px;
}

.overlay{
    position: absolute;
    content: "";
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: black;
    opacity: 0.3;
}


</style>