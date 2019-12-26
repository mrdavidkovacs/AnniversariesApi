<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <v-icon>fas fa-calendar-alt</v-icon>
        <span class="ml-2">Julibiläen</span>
      </div>
    </v-app-bar>

    <v-content>
      <v-container>
        <div class="w-80">
          <v-tabs class="elevation-2" dark centered="true">
            <v-tabs-slider></v-tabs-slider>

            <v-tab>
              <v-icon class="mr-2">$wedding</v-icon>
              Hochzeit
            </v-tab>

            <v-tab>
              <v-icon class="mr-2">fas fa-calendar-alt</v-icon>
              Information
            </v-tab>

            <v-tab-item>
              <WeddingAnniversaries />
            </v-tab-item>

            <v-tab-item></v-tab-item>
          </v-tabs>
        </div>
      </v-container>
    </v-content>

    <v-footer color="secondary">
      <v-card-text class="py-2 white--text text-right">
        <strong>{{ version }}</strong>
      </v-card-text>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import WeddingAnniversaries from "./components/WeddingAnniversaries.vue";
import Axios from "axios";

export default Vue.extend({
  name: "App",

  components: {
    WeddingAnniversaries
  },

  data: () => ({
    version: ""
  }),

  mounted() {
    Axios.create()
      .get<string>("about/version")
      .then(response => {
        this.version = response.data;
      });
  }
});
</script>
