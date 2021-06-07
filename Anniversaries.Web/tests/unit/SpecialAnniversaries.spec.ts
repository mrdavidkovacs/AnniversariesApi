import IAnniversaryType from "@/models/AnniversaryType";
import { shallowMount } from "@vue/test-utils";
import SpecialAnniversaries from "@/components/SpecialAnniversaries.vue"

describe("SpecialAnniversaries.vue", () => {
  it("can be created", () => {
    const type = {
      name: "foo",
      dateHint: "bar",
      optionalNameHint: "xyz",
      internalName: "abc",
      defaultDate: new Date(),
      iconName: "icon",
    } as IAnniversaryType;
    const wrapper = shallowMount(SpecialAnniversaries, {
      propsData: { type },
    });
    expect(wrapper.exists());
  });
});
