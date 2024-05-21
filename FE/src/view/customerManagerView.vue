<template>
  <div class="wrap">
    <SliceBar />
    <div>
      <thumb :thumbProps="thumb" />
      <SearchEngine @search-results="updateUsers" @clear-search="getAllUser" />
      <Table :userProp="users" />
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import SliceBar from '../components/SlideBar.vue';
import thumb from '../components/thumb.vue';
import SearchEngine from '../components/SearchEngine.vue';
import Table from '../components/Table.vue';

export default {
  name: 'Customer',
  components: {
    thumb,
    SliceBar,
    SearchEngine,
    Table
  },
  setup() {
    const thumb = ref('Customer Manager');
    const users = ref([]);

    const getAllUser = async () => {
      try {
        const res = await axios.get('https://localhost:7056/api/GetUser');
        users.value = res.data.data;
      } catch (err) {
        console.error(err);
      }
    };

    const updateUsers = (newUsers) => {
      users.value = newUsers;
    };

    onMounted(() => {
      getAllUser();
    });

    return {
      thumb,
      users,
      updateUsers,
      getAllUser
    };
  }
};
</script>

<style lang="scss" scoped>
.wrap {
  display: flex;
  align-items: flex-start;
}
</style>
