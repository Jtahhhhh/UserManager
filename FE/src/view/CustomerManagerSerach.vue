<template>
    <div class="wrap">
      <SliceBar />
      <div>
        <thumb :thumbProps="thumb" />
        <SearchEngine />
        <Table :userProp="users" />
      </div>
    </div>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue'
  import axios from 'axios'
  import SliceBar from '../components/SlideBar.vue'
  import thumb from '../components/thumb.vue'
  import SearchEngine from '../components/SearchEngine.vue'
  import Table from '../components/Table.vue'
  
  export default {
    name: ' Search',
    components: {
      thumb,
      SliceBar,
      SearchEngine,
      Table
    },
    props: {
    User: {
      type: Object,
      required: true
    }
  },
    setup() {
      const thumb = ref('Customer Manager')
      const users = ref([])
      
  
      
  
      onMounted(() => {
        
      })
  
      return {
        thumb,
        users
      }
    }
  }
  </script>
  
  <style lang="scss" scoped>
  .wrap {
    display: flex;
    align-items: top;
  }
  </style>
  