<template>
    <select class="select" @change="changeOption">
        <option 
            v-for="(option) in options" 
            :key="option.value" 
            :value="option.value"
        >
            {{option.name}}
        </option>
    </select>
</template>

<script>
    export default {
        name: "CustomSelect",
        props: {
            modelValue: {
                type: String,
            },
            options: {
                type: Array,
                default: () => [],
            }
        },
        methods: {
            changeOption(event) {
                this.$emit('update:modelValue', event.target.value)
            }
        }
    }
</script>

<style lang="scss" scoped>
    .select {
        width: 200px;
        background-color: #EEEEEE;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
        border-radius: 10px;
        padding: 10px 16px 10px 16px;
        box-sizing: border-box;
        display: block;
        border: none;
        outline: none;
    }
</style>