<template>
  <nav class="navbar navbar-expand-lg text-black navbar-dark bg-dark px-3">
    <router-link title="Home Page" class="navbar-brand  d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center mdi mdi-safe">
        <h1 class="text-black">  KEEPER</h1> 
      </div>
    </router-link>
    <button
      class="navbar-toggler text-black"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon text-black" />
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>

        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
