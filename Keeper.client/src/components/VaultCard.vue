<template>
   
    <router-link :to="{ name: 'Vault', params: { id: vault?.id } }">
        <div class="bg-light border p-1 elevation-2 rounded selectable position-relative w-100">
                    <img class=" image-adjust home " :src="vault?.img" alt="image goes here">
                    
                    <h3 class="text-white  content with-eight">{{vault?.name}}</h3>
                    
                </div>
            </router-link>

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

// .home{
//   display: grid;
//   max-height: 28vh;
//   place-content: center;
// }

.content {
    
    position: absolute; 
    bottom: 0; 
    left: 3px;
    width: 100%; 
    padding: 10px; 
    overflow-wrap: break-word;
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

.image-adjust{
    filter: contrast(75%);
    width: 100%;
}







</style>