<template>
  <div class="header">
    <p class="customer-manager">{{ thumbProps }}</p>
    <img
      alt=""
      class="line-1"
      src="https://static.overlay-tech.com/assets/aa3bf31e-2a26-462a-b969-a9858e9f14f7.png"
    />
  </div>
</template>

<script>
export default {
  name: 'thumb',
  props: ['thumbProps']
}
</script>

<style>
.header {
  margin-bottom: 10px;
  margin-left: 57px;
  padding: 0 0 0.92px;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
.customer-manager {
  font-family: 'Inria Serif';
  font-size: 30px;
  font-weight: 400;
  line-height: normal;
  color: black;
  margin-bottom: 25px;
  margin-left: 1px;
}
.line-1 {
  width: 1160px;
}
</style>
