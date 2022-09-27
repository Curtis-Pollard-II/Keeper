<template>
<!-- add router link here -->
    <div class=" container-fluid p-3">
        <div class="bg-light border p-1 elevation-2 rounded">
            <img class="img-fluid" :src="keep.img" alt="image goes here" style="width:100%;">
            <div>
                <h3 class="text-white  content with-eight">{{keep.name}}
                    <div class="righty">
                        <img :src="keep.creator.picture"/>
                    </div>
                </h3>
            </div>    
        </div>

    </div>



</template>


<script>
export default {
    props: { keep: {type: Object, required: true }},
setup() {
  return {};
},
};
</script>


<style> 
.container-fluid {
    position: relative;
    font-family: "Courier Bold"; 
    font-size: 24px; 
    font-style: normal; 
    font-variant: normal; 
    font-weight: 700; 
    line-height: 26.4px; }


.container-fluid .content {
    
    position: absolute; /* Position the background text */
    bottom: 0; /* At the bottom. Use top:0 to append it to the top */
    left: 10px;
    width: 100%; /* Full width */
    padding: 20px; /* Some padding */
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


</style>