<template>
    <div class="bg-dark" :title="vault">
        
    </div>
</template>


<script>
import { Vault } from "../models/Vault"


export default {
    props:{  
        vault: { type: Vault, required: true },
    },

setup() {


return {};
},
};
</script>



<style> 


</style>