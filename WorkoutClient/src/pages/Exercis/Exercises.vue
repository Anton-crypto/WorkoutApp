<template>
    <div>
        <TransitionGroup name="ex-transition" tag="ul">
            <div v-for="(exercis) in exercises" :key="exercis.id" class="cards__item"  >
                <Card @deleteCard="deleteProduct" :card="exercis" />
            </div>
        </TransitionGroup>
        <div v-intersection="loadMoreExercises" class="loading"></div>
    </div>
</template>

<script>
    import Card from '@/components/Card';

    export default {
        name: 'list-exercis',
        data: () => ({
            products : [],
            isPreLoader: true,
            exercises: [],
        }),
        mounted() {
            this.getExercisesAsync();
        },
        methods: {
            loadMoreExercises() {
                this.products.push({
                    id: this.creationID(),
                    title: this.creationID()
                });
            },
            async getExercisesAsync () {
                await this.axios.get('https://localhost:7024/workouts')
                .then(({data}) => {
                    this.exercises = data
                })
                .catch(err => {
                    console.log(err)
                })
                .finally(() => (this.loading = false));
            }
        },
        components: {
            Card,
        }
    }
</script>

<style lang="scss" scoped>

    .line {
        display: flex;
    }
    .cards {
        background-color: transparent;
        display: flex;
        flex-wrap: wrap;
        justify-content: space-evenly;


        &__item {
            margin-right: 16px;
            margin-bottom: 16px;
        }
    }
    .search {
        display: flex;
    }
    @media (max-width: 750px) {
        .line {
            display: block;
        }
        .search {
            display: block;
            margin-top: 20px;
        }
    }

    .products-transition-move,
    .products-transition-enter-active,
    .products-transition-leave-active {
        transition: all 0.5s ease;
    }

    .products-transition-enter-from,
    .products-transition-leave-to {
        opacity: 0;
        transform: translateX(30px);
    }
    .products-transition-leave-active {
        position: absolute;
    }
</style>
