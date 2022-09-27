<template>

</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
export default {
  name: 'Home',
  setup() {
    async function getKeeps(){
      try {
        await keeps.getKeeps();
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
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
