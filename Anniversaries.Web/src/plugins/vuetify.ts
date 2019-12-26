import Vue from "vue";
import Vuetify from "vuetify/lib";
import de from "vuetify/src/locale/de";
import WeddingIcon from "@/icons/Wedding.vue";

Vue.use(Vuetify);

export default new Vuetify({
  lang: {
    locales: { de },
    current: "de"
  },
  icons: {
    iconfont: "fa",
    values: {
      wedding: {
        component: WeddingIcon
      }
    }
  }
});
