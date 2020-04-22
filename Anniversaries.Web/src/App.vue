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

            <v-tab
              v-for="type in anniversaryTypes"
              v-bind:key="type.internalName"
            >
              <v-icon class="mr-2">{{ type.iconName }}</v-icon>
              {{ type.name }}
            </v-tab>

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
          <a :href="repositoryUrl" target="_blank">
            <v-icon class="fab fa-github" color="#fff"></v-icon>
          </a>
        </span>
        <strong>{{ versionString }}</strong>
      </v-card-text>
    </v-footer>

    <v-overlay :value="loading">
      <v-progress-circular indeterminate size="64"></v-progress-circular>
    </v-overlay>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import SpecialAnniversaries from "./components/SpecialAnniversaries.vue";
import IAnniversaryType from "./models/AnniversaryType";
import IBuildInformation from "./models/BuildInformation";
import Axios from "axios";

export default Vue.extend({
  name: "App",

  components: {
    SpecialAnniversaries
  },

  data: () => ({
    loading: true,
    versionString: "" as string,
    repositoryUrl: "" as string,
    anniversaryTypes: [] as IAnniversaryType[]
  }),

  async mounted() {
    const axios = Axios.create();

    let [buildInformationRequest, typesRequest] = await Promise.all([
      axios.get<IBuildInformation>("about/information"),
      axios.get<IAnniversaryType[]>("anniversary-types")
    ]);

    const buildInformation: IBuildInformation = buildInformationRequest.data;
    this.anniversaryTypes = typesRequest.data;

    this.repositoryUrl = buildInformation.repositoryUrl;

    if (buildInformation.commitShortHash != null) {
      this.versionString =
        "v" +
        buildInformation.version +
        " @ " +
        buildInformation.commitShortHash;
    } else {
      this.versionString = "v" + buildInformation.version;
    }

    this.loading = false;
  }
});
</script>
