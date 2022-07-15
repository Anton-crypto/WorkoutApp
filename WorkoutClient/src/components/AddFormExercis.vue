<template>
    <div class="add-form">
        <div class="title">
            <h1>Добавление</h1>
        </div>
        <div class="name">
            <input type="text" placeholder="Название упражнения">
        </div>
        <div class="vidio-loader" :class="getClassDragon()">
            <input 
                type="file" 
                @dragenter="drag = true" 
                @dragleave="drag = false" 
                @change="uploadFile"
            />
            <div class="vidio-loader__body">
                <div class="vidio-loader__img">
                    
                </div>
                <div class="vidio-loader__text">
                    <div>
                        Загрузить файлы
                    </div>
                    <div>
                        Переташить сюда или выбрать 
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'add-form-exercis',
        data: () => ({
            drag: false,
        }),
        mounted() { },
        methods: { 
            uploadFile(event) {
                console.log(event)
            },
            getClassDragon() {
                if(this.drag) {
                    return 'drag'
                }
                return ''
            }
        },
        components: { }
    }
</script>

<style lang="scss" scoped>
    .add-form {
        background-color: #EEEEEE;
        padding: 10px 10px 10px 10px;
        border-radius: 5px;
        max-width: 330px;
        width: 100%;

        .title {
            h1 {
                margin-top: 0px;
            }
        }
        .vidio-loader {

            width: 100%;
            height: 100px;
            border: 1px dashed rgba(0, 0, 0, 0.5) ;
            border-radius: 5px;
            margin-top: 15px;
            position: relative;

            input {
                width: 100%;
                height: 100%;
                opacity: 0;
                position: absolute;
                top: 0;
                left: 0;
                cursor: pointer;
            }

            &__body {
                height: 100%;
            }
            &__text {
                height: 100%;
                display: flex;
                flex-direction: column;
                justify-content: center;
            }
        }
        .name {
            input {
                width: 100%;
                box-sizing: border-box;
                border: none;
                outline: none;
                border-radius: 5px;
                box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1); 
                padding: 10px;
            }
        }
        .drag {
            border: 1px dashed rgb(0, 0, 0);
            background-color: rgb(221, 221, 221);
        }
    }
</style>