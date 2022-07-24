<template>
    <div class="navbar">
        <div class="navbar-item">
            <router-link to="/exercis" >List of exercises</router-link>
        </div>
        <div class="navbar-item">
            <router-link to="/login" >login</router-link>
        </div>
    </div>
</template>
<script>
    export default {
        name: "router-navbar",
        methods: {
            rout() {
                this.$router.push("/sdsd")
            }
        }
    }
</script>
<style lang="scss">
    .navbar {
        display: flex;
        align-items: center;
        width: 1000px;
        height: 50px;
        padding: 5px; 
        box-sizing: border-box;
        background-color: #FFFEFB;
        &-item {
            padding: 5px;      
            box-sizing: border-box;
        }
    }
</style>