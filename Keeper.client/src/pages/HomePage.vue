<template>
 <div class="masonry bg-info">
    <div v-for="k in keeps" :key="k.id">
      <KeepCard :keep="k" />
    </div>
</div>
  
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { AppState } from '../AppState';
import KeepCard from '../components/KeepCard.vue';
import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop';
export default {
  name: 'Home',
  setup() {
    async function getKeeps(){
      try {
        await keepsService.getKeeps();
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    }



    
    onMounted(() => {
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
.masonry {
  columns: 325px;
  column-gap: .5em;

  div {
    display:inline-block;
    margin-bottom: .5em;
  }
}
</style>
