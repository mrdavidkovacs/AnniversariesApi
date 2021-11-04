import Vue from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import Vuetify from "vuetify";
import de from "vuetify/src/locale/de";
import WeddingIcon from "@/icons/WeddingIcon.vue";

Vue.config.productionTip = false;
Vue.use(Vuetify);
import "vuetify/dist/vuetify.min.css";

new Vue({
    vuetify: new Vuetify({
      lang: {
        locales: { de },
        current: "de",
      },
      icons: {
        iconfont: "fa",
        values: {
          wedding: {
            component: WeddingIcon,
          },
        },
      },
    }),
    render: (h) => h(App),
}).$mount("#app");
