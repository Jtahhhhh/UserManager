<template>
  <div class="search-field">
    <form @submit.prevent="search">
      <div class="row">
        <!-- First Column -->
        <div class="col-md-6">
          <div class="mb-3">
            <label for="InputName" class="form-label">Name</label>
            <input type="text" v-model="name" class="form-control" id="InputName" />
          </div>
          <div class="mb-3">
            <label for="InputEmail" class="form-label">Email</label>
            <input type="email" v-model="email" class="form-control" id="InputEmail" />
          </div>
        </div>
        <!-- Second Column -->
        <div class="col-md-6">
          <div class="mb-3">
            <label for="InputPhone" class="form-label">Phone</label>
            <input type="tel" v-model="phone" class="form-control" id="InputPhone" />
          </div>
          <div class="mb-3">
            <label for="InputAddress" class="form-label">Address</label>
            <input type="text" v-model="address" class="form-control" id="InputAddress" />
          </div>
        </div>
      </div>
      <div class="btn-frame mt-4">
        <div class="btn-group-left">
          <div class="del-btn">
            <button type="button" class="btn btn-danger">
              <div class="flex-wrapper-two">
                <img
                  alt=""
                  class="vector"
                  src="https://static.overlay-tech.com/assets/5cfe61cb-0cb8-427b-80f8-1adc26b23166.svg"
                />
                <p class="delete">Delete</p>
              </div>
            </button>
          </div>
          <div class="create-btn">
            <button type="button" class="btn btn-success">
              <div class="flex-wrapper-two">
                <img
                  alt=""
                  class="vector-two"
                  src="https://static.overlay-tech.com/assets/6a35f264-f249-4466-9fc2-5297d5ff1ac8.svg"
                />
                <p class="delete">Create</p>
              </div>
            </button>
          </div>
        </div>
        <div class="btn-search">
          <button type="submit" class="btn btn-primary">
            <img
              alt=""
              class="vector-three"
              src="https://static.overlay-tech.com/assets/8c8c86b2-3c7d-46eb-8159-0fa637b52b86.svg"
            />
            <p class="search">Search</p>
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';

export default {
  name: 'SearchEngine',
  data() {
    return {
      email: '',
      name: '',
      phone: '',
      address: ''
    };
  },
  setup() {
    const user = ref([]);
    return {
      user
    };
  },
  methods: {
    async search() {
      if (!this.email && !this.name && !this.phone && !this.address) {
        this.$emit('search-results', []);
        this.$emit('clear-search');
        return;
      }

      try {
        const res = await axios.post('https://localhost:7056/api/Search', {
          name: this.name,
          userName: this.email,
          phone: this.phone,
          address: this.address
        });
        this.$emit('search-results', res.data.data);
      } catch (error) {
        console.error('Error:', error);
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.search-field {
  margin-left: 10rem;
  margin-right: 10rem;
}
.btn-frame {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 15px;
  margin-bottom: 15px;
}
.btn-group-left {
  display: flex;
  gap: 20px;
}
.btn-search {
  margin-top: 5px;
}
.del-btn,
.create-btn,
.btn-search button {
  border-radius: 5px;
  padding: 10px 20px;
  display: flex;
  align-items: center;
}
.delete,
.create,
.search {
  font-family: 'Jaldi';
  font-size: 20px;
  font-weight: 400;
  color: white;
  margin: 0;
}
.vector,
.vector-two,
.vector-three {
  margin-right: 10px;
  width: 20px;
  height: 20px;
}
.flex-wrapper-two,
.vector-two,
.vector-three {
  display: flex;
  align-items: center;
}
</style>
