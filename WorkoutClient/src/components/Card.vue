<template>
  <div class="card">
    <!-- <img class="card__img" :src="card.imgUrl" alt="" srcset="" /> -->
    <div class="card__body">
        <div class="card__title">
            {{card.name}}
        </div>
        <div class="card__video">
            <video controls="controls">
                <source src="https://localhost:7024/Resources/Vidios/016e097d-43a4-410a-9ad4-74420ecc697e.mp4" type="video/webm">
            </video>
        </div>
    </div>
    <!-- <div class="card__btn-delete" @click="deleteCard(card.id)" >
        <svg xmlns="http://www.w3.org/2000/svg" aria-hidden="true" role="img" width="1em" height="1em" preserveAspectRatio="xMidYMid meet" viewBox="0 0 12 12"><path fill="currentColor" d="M5 3h2a1 1 0 0 0-2 0ZM4 3a2 2 0 1 1 4 0h2.5a.5.5 0 0 1 0 1h-.441l-.443 5.17A2 2 0 0 1 7.623 11H4.377a2 2 0 0 1-1.993-1.83L1.941 4H1.5a.5.5 0 0 1 0-1H4Zm3.5 3a.5.5 0 0 0-1 0v2a.5.5 0 0 0 1 0V6ZM5 5.5a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5ZM3.38 9.085a1 1 0 0 0 .997.915h3.246a1 1 0 0 0 .996-.915L9.055 4h-6.11l.436 5.085Z"/></svg>
    </div> -->
  </div>
</template>

<script>
    export default {
        name: 'app-card',
        data: () => ({
            
        }),
        props: {
            card: {
                id: String,
                required: true,
                name: {
                    type: String,
                    required: true,
                },
            }
        },
        methods: {
            deleteCard(id) {
                this.$emit("deleteCard", id);
            },
        },
    }
</script>

<style lang="scss" scoped>
    .card {
        max-width: 330px;
        height: 100%;
        background: #FFFEFB;
        box-shadow: 0px 20px 30px rgba(0, 0, 0, 0.04), 0px 6px 10px rgba(0, 0, 0, 0.02);
        border-radius: 4px;
        position: relative;

        &__img {
            width: 100%;
            border-radius: 4px 4px 0px 0px;
            transition: all 0.3s cubic-bezier(0.4, 0, 1, 1) 0s;
            height: 200px;
        }
        &__body {
            padding: 16px 16px 24px 16px;
            font-style: normal;
            text-align: left;
            color: #3F3F3F;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }
        &__video {
            video {
                width: 100%;
            }
        }
        &__title {      
            font-weight: 600;
            font-size: 20px;
            line-height: 25px;
        }
        &__description {
            margin-top: 16px;
            font-weight: 400;
            font-size: 16px;
            line-height: 20px;
        }
        &__price {
            margin-top: 16px;
            font-weight: 600;
            font-size: 24px;
            line-height: 30px;
        }
        &__btn {
            &-delete  {
                position: absolute;
                background-color: #FF8484;
                box-shadow: 0px 2px 4px rgb(0 0 0 / 10%);
                border-radius: 10px;
                top: -10px;
                font-size: 16px;
                right: -11px;

                width: 0;
                height: 0;
                padding: 0;

                transition: all 0.3s cubic-bezier(0.4, 0, 1, 1) 0s;
                svg {
                    width: 0;
                    height: 0;
                }
            }
        }
        &:hover {
            .card {
                &__btn {
                    &-delete  {
                        width: 16px;
                        height: 17px;
                        padding: 6px;
                        svg {
                            width: 100%;
                            height: 100%;
                        }
                        transition: all 0.3s cubic-bezier(0.4, 0, 1, 1) 0s;
                    }
                }
                &__img {
                    box-shadow: 0px 4px 4px rgb(0 0 0 / 20%);
                }
            }
        }
    }
</style>

