<template>

</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { AppState } from '../AppState';
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
    }
  }
}
</script>

<style scoped lang="scss">


</style>
