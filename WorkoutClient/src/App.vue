<template>
  <div class="app">
    <div class="container">
      <Navbar></Navbar>
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'

  export default {
    name: 'App',
    components: {
      Navbar,
    },
  }
</script>

<style>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }
  body {
    margin: 0;
    padding: 0;
  }
  .app {
    width: 100%;
    min-height: 100vh;
  }
  .container {
    max-width: 1200px;
    margin: 0 auto;
    padding: 16px;
  }
</style>
