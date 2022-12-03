<template>
  <RouterView></RouterView>
</template>
<script>
import 'vue-router'





export default {
  name: 'App',
}
</script>

<style>
*{
  margin:0;
}
body{
  background: rgb(53,129,249);
  background: radial-gradient(circle, rgba(53,129,249,1) 0%, rgba(69,73,255,1) 100%);
  background-repeat: no-repeat;
  background-size: 100%;
  height: 100%;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;
}
</style>
