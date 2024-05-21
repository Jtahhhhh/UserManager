<template>
  <div class="login-three">
    <div class="container">
      <!-- Hàng Bên Ngoài -->
      <div class="row justify-content-center">
        <div class="col-lg-8 col-md-10">
          <div class="card o-hidden border-0 mx-auto shadow-lg my-5 pt-4 pb-5 card-custom">
            <div class="card-body mx-auto" style="background-color: white">
              <!-- Hàng Lồng Bên Trong Thân Thẻ -->
              <div class="mb-4">
                <div class="thumb text-center">
                  <div class="relative-wrapper-one">
                    <img
                      alt=""
                      class="vector"
                      src="https://static.overlay-tech.com/assets/acfbeedf-8b0a-4674-a109-ae2f42de7957.svg"
                    />
                    <p class="login">Login</p>
                  </div>
                  <p class="welcome-to-our-website">Welcome to our Website</p>
                </div>
                <form class="user" @submit.prevent="login">
                  <div class="form-group mb-3">
                    <input
                      type="text"
                      v-model="email"
                      class="form-control form-control-user"
                      id="InputEmail"
                      aria-describedby="emailHelp"
                      placeholder="Email..."
                    />
                  </div>
                  <div class="form-group mb-3">
                    <input
                      type="password"
                      v-model="password"
                      class="form-control form-control-user"
                      id="InputPassword"
                      placeholder="Password...."
                    />
                  </div>
                  <div class="form-group mb-3">
                    <div class="custom-control custom-checkbox small">
                      <input type="checkbox" class="custom-control-input" id="customCheck" />
                      <label class="custom-control-label text-muted" for="customCheck"
                        >Remember me</label
                      >
                    </div>
                  </div>
                  <button id="btnLogin" class="btn btn-primary btn-user btn-block">Log in</button>
                </form>
                <div class="text-center mb-4">
                  <p class="text-muted">
                    New on our platform? <RouterLink to="/register">Create an account</RouterLink>
                  </p>
                </div>
                <div class="v d-flex justify-content-center align-items-center mb-4">
                  <img
                    alt=""
                    class="line-2"
                    src="https://static.overlay-tech.com/assets/afcbf7dc-d48e-48fc-ba48-c413ad8ecfb4.png"
                  />
                  <p class="or mx-3">or</p>
                  <img
                    alt=""
                    class="line-2"
                    src="https://static.overlay-tech.com/assets/64cfa109-1f57-4075-86be-6033b64e263a.png"
                  />
                </div>
                <div class="log-in-option d-flex justify-content-center align-items-center">
                  <img
                    alt=""
                    class="vector-three mx-2"
                    src="https://static.overlay-tech.com/assets/1ecaabe8-b199-4549-8c0b-8216c57d567e.svg"
                  />
                  <img
                    alt=""
                    class="vector-four mx-2"
                    src="https://static.overlay-tech.com/assets/1b7057e5-c4f3-4dde-b703-7197b82af1d1.svg"
                  />
                  <img
                    alt=""
                    class="vector-four mx-2"
                    src="https://static.overlay-tech.com/assets/a6e00039-5f4b-4070-9e1d-0e3253844c05.svg"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { useToast } from 'vue-toastification'

const toast = useToast()
export default {
  name: 'Login',
  data() {
    return {
      email: '',
      password: ''
    }
  },
  methods: {
    async login() {
      if(this.email=='' && this.password=='')
          toast.error("Enter your mail and password")
      else if( this.password=='')
          toast.error("Enter your password")
      else if(this.email=='')
          toast.error("Enter your mail")
      else{
      axios
        .post('https://localhost:7056/api/Login', {
          UserName: this.email,
          Password: this.password
        })
        .then((res) => {
          if (res.data.status == '200') {
            localStorage.setItem('username', this.email)
            window.location.href = '/customer'
          } else toast.error(res.data.massenge)
          console.log(res)
        })
        .catch((err) => toast.error('Internet interruption'))
    }}
  }
}
</script>

<style lang="scss" scoped>
.card-custom {
  max-width: 500px;
}

.thumb {
  margin-bottom: 20px;
  text-align: center;
}

.relative-wrapper-one {
  margin-bottom: 12px;
  position: relative;
}

.vector {
  width: 43px;
  height: 43px;
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
}

.login {
  font-family: 'Irish Grover';
  font-size: 36px;
  font-weight: 400;
  line-height: normal;
  color: black;
}

.welcome-to-our-website {
  font-family: 'Inter';
  font-size: 18px;
  font-weight: 400;
  line-height: normal;
  color: black;
}

.user .form-group {
  margin-bottom: 1rem; /* Khoảng cách giữa các trường nhập */
}

.user .btn-user {
  display: block;
  width: 100%;
  margin-top: 1rem; /* Khoảng cách trên nút */
}

.login-three {
  background-color: lavender;
  padding: 80px 0;
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
}

.v {
  display: flex;
  align-items: center;
}

.line-2 {
  width: 50px;
}

.or {
  font-family: 'Inter';
  font-size: 18px;
  font-weight: 400;
  line-height: normal;
  color: black;
}

.log-in-option {
  display: flex;
  justify-content: center;
  align-items: center;
}

.vector-three,
.vector-four {
  width: 40px;
  height: 40px;
}

.vector-four:last-of-type {
  margin-right: 0;
}
</style>
