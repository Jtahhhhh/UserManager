<template>
  <tr>
    <td>
      <div class="form-check">
        <input class="form-check-input" type="checkbox" :value="userProp.userId" id="flexCheck" />
      </div>
    </td>
    <th>{{ userProp.userId }}</th>
    <td>{{ userProp.userName }}</td>
    <td>{{ userProp.userName }}@gmail.com</td>
    <td>{{ userProp.userPhoneNum }}</td>
    <td>{{ userProp.userAddress }}</td>
    <td>
      <a
        :href="`/courses/${userProp.userId}/edit`"
        class="btn btn-secondary"
        tabindex="-1"
        role="button"
      >
        Sửa
      </a>
    </td>
   
  </tr>
</template>

<script>
export default {
  name: 'TableItem',
  props: {
    userProp: {
      type: Object,
      required: true
    }
  }
}
</script>

<style></style>
