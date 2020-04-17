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
          <v-tabs class="elevation-2" dark v-bind:centered="true">
            <v-tabs-slider></v-tabs-slider>

            <v-tab>
              <v-icon class="mr-2">fas fa-calendar-alt</v-icon>
              Home
            </v-tab>

            <v-tab
              v-for="type in anniversaryTypes"
              v-bind:key="type.internalName"
            >
              <v-icon class="mr-2">{{ type.iconName }}</v-icon>
              {{ type.name }}
            </v-tab>

            <v-tab-item></v-tab-item>

            <v-tab-item
              v-for="type in anniversaryTypes"
              v-bind:key="type.internalName"
            >
              <SpecialAnniversaries v-bind:type="type" />
            </v-tab-item>
          </v-tabs>
        </div>
      </v-container>
    </v-content>

    <v-footer color="secondary">
      <v-card-text class="py-2 white--text text-right">
        <span class="mr-2">
          <a
            href="https://github.com/mrdavidkovacs/AnniversariesApi"
            target="_blank"
          >
            <v-icon class="fab fa-github" color="#fff"></v-icon>
          </a>
        </span>
        <strong>v{{ version }}</strong>
      </v-card-text>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import SpecialAnniversaries from "./components/SpecialAnniversaries.vue";
import IAnniversaryType from "./models/AnniversaryType";
import Axios from "axios";

export default Vue.extend({
  name: "App",

  components: {
    SpecialAnniversaries
  },

  data: () => ({
    version: "" as String,
    anniversaryTypes: [] as IAnniversaryType[]
  }),

  mounted() {
    Axios.create()
      .get<string>("about/version")
      .then(response => {
        this.version = response.data;
      });

    this.anniversaryTypes = [
      {
        name: "Hochzeit",
        dateHint: "Hochzeitsdatum",
        optionalNameHint: "Standesamt",
        internalName: "wedding",
        defaultDate: new Date("2016-07-16"),
        iconName: "$wedding"
      } as IAnniversaryType
    ];
  }
});
</script>
