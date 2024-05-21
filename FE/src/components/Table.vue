<template>
  <div class="table-field">
    <table class="table" v-if="paginatedUsers.length > 0">
      <thead>
        <tr>
          <th scope="col">
            <div class="form-check">
              <input
                class="form-check-input"
                type="checkbox"
                id="check-all"
                @change="toggleSelectAll"
              />
              <label class="form-check-label" for="check-all">Check All</label>
            </div>
          </th>
          <th scope="col">User ID</th>
          <th scope="col">User Name</th>
          <th scope="col">Phone</th>
          <th scope="col">Address</th>
          <th scope="col"></th>
          <th scope="col"></th><th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <TableItem v-for="user in paginatedUsers" :key="user.userId" :userProp="user" />
      </tbody>
    </table>
    <p v-else class="not-found-message">Not found</p>
    <div v-if="paginatedUsers.length > 0" class="pagination">
      <button @click="prevPage" :disabled="currentPage === 1" class="pagination-info">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512" class="icon-left">
          <path
            d="M9.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l192 192c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L77.3 256 246.6 86.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-192 192z"
          />
        </svg>
        Prev
      </button>
      <span
        v-for="page in totalPages"
        :key="page"
        @click="goToPage(page)"
        :class="{ active: currentPage === page }"
        >{{ page }}</span
      >
      <button @click="nextPage" :disabled="currentPage === totalPages" class="pagination-info">
        Next
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512" class="icon-right">
          <path
            d="M310.6 233.4c12.5 12.5 12.5 32.8 0 45.3l-192 192c-12.5 12.5-32.8 12.5-45.3 0s-12.5-32.8 0-45.3L242.7 256 73.4 86.6c-12.5-12.5-12.5-32.8 0-45.3s32.8-12.5 45.3 0l192 192z"
          />
        </svg>
      </button>
    </div>
  </div>
</template>

<script>
import { ref, computed } from 'vue';
import TableItem from './TableItem.vue';

export default {
  name: 'Table',
  components: {
    TableItem
  },
  props: {
    userProp: {
      type: Array,
      required: true
    }
  },
  setup(props) {
    const currentPage = ref(1);
    const itemsPerPage = ref(4);
    const totalPages = computed(() => Math.ceil(props.userProp.length / itemsPerPage.value));

    const paginatedUsers = computed(() => {
      const start = (currentPage.value - 1) * itemsPerPage.value;
      const end = start + itemsPerPage.value;
      return props.userProp.slice(start, end);
    });

    const prevPage = () => {
      if (currentPage.value > 1) currentPage.value--;
    };

    const nextPage = () => {
      if (currentPage.value < totalPages.value) currentPage.value++;
    };

    const goToPage = (page) => {
      currentPage.value = page;
    };

    const toggleSelectAll = (event) => {
      const checkboxes = document.querySelectorAll('.form-check-input[type="checkbox"]');
      checkboxes.forEach((checkbox) => (checkbox.checked = event.target.checked));
    };

    return {
      currentPage,
      totalPages,
      paginatedUsers,
      prevPage,
      nextPage,
      goToPage,
      toggleSelectAll
    };
  }
};
</script>

<style scoped>
.table {
  width: 100%;
  margin-bottom: 1rem;
  color: #212529;
  border-collapse: collapse;
}
.table-field {
  margin-left: 20px;
}
th,
td {
  padding: 0.75rem;
  vertical-align: top;
  border-top: 1px solid #dee2e6;
}
thead th {
  vertical-align: bottom;
  border-bottom: 2px solid #dee2e6;
}
.form-check {
  display: flex;
  align-items: center;
}
.form-check-input {
  margin-right: 0.5rem;
}
.pagination {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 1rem;
}
.pagination-info {
  border: none;
  background: none;
  cursor: pointer;
  padding: 0.5rem 1rem;
  display: flex;
  align-items: center;
}
.icon-left,
.icon-right {
  width: 1rem;
  height: 1rem;
}
span {
  cursor: pointer;
  padding: 0.5rem 1rem;
}
span.active {
  font-weight: bold;
}
.not-found-message  {
  font-family: "Inria Serif";
  font-size: 45px;
  font-weight: 400;
  margin-top: 150px;
  margin-left: 450px;
  line-height: normal;
  color: #808385;
}
</style>
