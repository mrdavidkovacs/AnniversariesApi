<template>
  <div class="special-anniversaries">
    <div>
      <v-expansion-panels v-model="expandedPanel">
        <v-expansion-panel>
          <v-expansion-panel-header
            >Verfügbare Jubiläen
            <span v-if="loadingAnniversaries" class="ml-2">
              <v-progress-circular
                indeterminate
                color="primary"
                size="16"
                width="2"
              ></v-progress-circular>
            </span>
          </v-expansion-panel-header>

          <v-expansion-panel-content>
            <v-list
              disabled
              dense
              v-if="anniversaries && anniversaries.length > 0"
            >
              <v-list-item-group v-model="anniversaries" color="primary">
                <v-list-item v-for="(item, i) in anniversaries" :key="i">
                  <v-list-item-icon>
                    <v-icon>fas fa-calendar-alt</v-icon>
                  </v-list-item-icon>
                  <v-list-item-content>
                    <v-list-item-title>{{ item.name }}</v-list-item-title>
                    <span class="body-2 font-weight-light">{{
                      item.description
                    }}</span>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </v-list>
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel>
          <v-expansion-panel-header
            >Persönliche Jubiläen</v-expansion-panel-header
          >

          <v-expansion-panel-content>
            <v-menu
              v-model="menu"
              :close-on-content-click="false"
              transition="scale-transition"
              offset-y
              max-width="290px"
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="computedDateFormatted"
                  :label="type.dateHint"
                  persistent-hint
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="date"
                no-title
                @input="menu = false"
                :first-day-of-week="1"
              ></v-date-picker>
            </v-menu>

            <v-text-field
              label="Name (optional)"
              :placeholder="'z.B.: ' + this.type.optionalNameHint"
              v-model="optionalName"
            ></v-text-field>

            <v-btn
              class="ma-2"
              :loading="loadingAppointments"
              tile
              dark
              :color="calculateButtonColor"
              @click="calculateAppointments"
              ><v-icon class="mr-2">fas fa-cog</v-icon>Berechnen
            </v-btn>

            <v-btn class="ma-2" tile dark :href="downloadLink" color="primary"
              ><v-icon class="mr-2">fas fa-calendar-plus</v-icon>ICAL</v-btn
            >

            <v-btn
              v-if="this.appointments && this.appointments.length > 0"
              class="ma-2"
              tile
              dark
              color="red"
              @click="clearAppointments"
              ><v-icon>fas fa-times</v-icon>
            </v-btn>

            <v-list disabled>
              <v-list-item-group v-model="appointments" color="primary">
                <v-list-item v-for="(item, i) in appointments" :key="i">
                  <v-list-item-icon>
                    <v-icon>fas fa-calendar-alt</v-icon>
                  </v-list-item-icon>
                  <v-list-item-content>
                    <v-list-item-title>
                      {{ formatAppointmentDate(item) }}
                    </v-list-item-title>
                    <v-list-item-subtitle>
                      {{ item.name }}
                    </v-list-item-subtitle>
                    <span class="body-2 font-weight-light">{{
                      item.description
                    }}</span>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </v-list>
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios, { AxiosInstance } from "axios";
import IAnniversary from "../models/Anniversary";
import IAppointment from "../models/Appointment";
import IAnniversaryType from "../models/AnniversaryType";

@Component
export default class SpecialAnniversaries extends Vue {
  @Prop({ required: true })
  type!: IAnniversaryType;

  private anniversaries: IAnniversary[] = [];
  private loadingAnniversaries: boolean = false;

  private axios: AxiosInstance;
  private menu: boolean = false;
  private date: string;
  private optionalName: string = "";
  private generatedAppointmentsDate: string = "";
  private generatedAppointmentsName: string = "";

  private loadingAppointments: boolean = false;
  private appointments: IAppointment[] = [];

  private expandedPanel: number = 1;

  constructor() {
    super();
    this.axios = Axios.create();
    const today = new Date();
    this.date = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}`;
  }

  async mounted(): Promise<void> {
    const d = new Date(this.type.defaultDate);
    this.date = `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
    await this.loadAnniversaries();
  }

  async loadAnniversaries(): Promise<void> {
    this.loadingAnniversaries = true;
    this.axios.get<IAnniversary[]>(this.baseUri).then((response) => {
      this.loadingAnniversaries = false;
      this.anniversaries = response.data;
    });
  }

  async calculateAppointments(): Promise<void> {
    this.loadingAppointments = true;
    this.axios
      .get<IAppointment[]>(`${this.baseUri}/${this.date}${this.nameParameter}`)
      .then((response) => {
        this.loadingAppointments = false;
        this.appointments = response.data;
        this.generatedAppointmentsDate = this.date;
        this.generatedAppointmentsName = this.optionalName;
      });
  }

  get baseUri(): string {
    return `/anniversaries/${this.type.internalName}`;
  }

  get nameParameter(): string {
    return this.optionalName ? `?name=${this.optionalName}` : "";
  }

  get downloadLink(): string {
    return `${this.baseUri}/${this.date}.ics${this.nameParameter}`;
  }

  get calculateButtonColor(): string {
    const dateIsSame = this.date == this.generatedAppointmentsDate;
    const nameIsSame = this.optionalName == this.generatedAppointmentsName;
    return dateIsSame && nameIsSame ? "primary" : "orange";
  }

  get computedDateFormatted(): string {
    return this.formatDate(this.date);
  }

  formatAppointmentDate(app: IAppointment): string {
    return this.formatDate(app.dateTime);
  }

  formatDate(date: Date | string): string {
    return new Date(date).toLocaleDateString();
  }

  clearAppointments(): void {
    this.appointments = [];
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
