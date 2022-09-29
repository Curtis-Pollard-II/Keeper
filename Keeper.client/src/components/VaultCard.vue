<template>
    <div class=" container-fluid p-3">
        <div class="bg-light border p-1 elevation-2 rounded selectable">
                <router-link :to="{ name: 'Vault', params: { id: vault?.id } }">
                    <img class="adjust-size home home-card" :src="vault?.img" alt="image goes here" style="width:100%;">
                </router-link>
            <div>
                <h3 class="text-white  content with-eight">{{vault?.name}}</h3>
            </div>    
        </div>
    </div>
</template>


<script>



export default {
    props:{  
        vault: { type: Object, required: true },
    },

setup() {


return {

};
},
};
</script>



<style scoped lang="scss"> 

.home{
  display: grid;
  height: 28vh;
  place-content: center;
}

.content {
    
    position: absolute; 
    bottom: 0; 
    left: 3px;
    width: 100%; 
    padding: 10px; 
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







</style>