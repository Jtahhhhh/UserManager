<template>
  <div class="frame-4">
    <div class="sidebar">
      <div class="logo-section">
        <img
          alt="Company Logo"
          class="logo-image"
          src="https://static.overlay-tech.com/assets/258bbc90-22cf-4c68-9a66-cc6dc14df202.svg"
        />
        <p class="website">Website</p>
      </div>
      <nav class="nav-menu">
        <div class="nav-item">
          <p class="nav-text">Dashboard</p>
        </div>
        <div class="nav-item">
          <p class="nav-text">Product</p>
        </div>
        <div class="nav-item">
          <p class="nav-text">Statistical</p>
        </div>
        <div class="nav-item active">
          <p class="nav-text">Customer</p>
        </div>
        <div class="nav-item">
          <p class="nav-text">Staff</p>
        </div>
      </nav>
      <div class="account-section">
        <img
          alt="User Avatar"
          class="avatar"
          src="https://static.overlay-tech.com/assets/420ec70b-ec46-418d-a93c-4dbafe838201.svg"
        />
        <div class="account-info">
          <p class="username">{{ username }}</p>
          <p class="email">{{ username }}@gmail.com</p>
        </div>
        <div class="dropdown">
          <button class="more-options" data-bs-toggle="dropdown" aria-expanded="false">
            <img
              alt="More options"
              class="more-options-icon"
              src="https://static.overlay-tech.com/assets/d70c2875-ba6a-4934-8b61-bb433f5b216f.svg"
            />
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Information</a></li>
            <li><a class="dropdown-item" href="/"><button class="dropdown-item" type="button" @click="logout">Logout</button></a></li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'sidebar',
  data() {
    return {
      username: ''
    }
  },
  methods: {
    async logout() {
      try {
        await axios.put('https://localhost:7056/api/LogOut', {
          user: this.username
        })
        localStorage.removeItem('username')
      } catch (error) {
        console.error('Error logging out:', error)
      }
    }
  },
  mounted() {
    this.username = localStorage.getItem('username') || 'Guest'
  }
}
</script>

<style lang="scss" scoped>
.sidebar {
  background-color: #C9D5FF;
  padding: 20px;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  width: 250px;
  height: 100vh;
  box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
}

.logo-section {
  display: flex;
  align-items: center;
  margin-bottom: 40px;
}

.logo-image {
  width: 40px;
  height: auto;
  margin-right: 10px;
}

.website {
  font-family: 'Irish Grover', cursive;
  font-size: 24px;
  color: rgba(66, 64, 60, 1);
}

.nav-menu {
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  width: 100%;
}

.nav-item {
  padding: 15px 20px;
  width: 100%;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.nav-item:hover {
  background-color: rgba(141, 164, 236, 0.3);
}

.nav-item.active {
  background-color: rgba(158, 180, 255, 1);
}

.nav-text {
  font-family: 'Inria Sans', sans-serif;
  font-size: 18px;
  color: #333;
}

.account-section {
  display: flex;
  align-items: center;
  width: 100%;
  margin-top: 20px;
}

.avatar {
  width: 50px;
  height: 50px;
  margin-right: 10px;
}

.account-info {
  flex-grow: 1;
}

.username,
.email {
  font-family: 'Jaldi', sans-serif;
  font-size: 16px;
  color: #333;
}

.more-options {
  background: none;
  border: none;
  padding: 5px;
  cursor: pointer;
}

.more-options-icon {
  width: 20px;
  height: 20px;
}
</style>
