using System;

namespace Anniversaries.Core
{
    public class AnniversaryType
    {
        public AnniversaryType(string name, string dateHint, string optionalNameHint, AnniversaryTypes internalName, string iconName, DateTime defaultDate)
        {
            this.Name = name;
            this.DateHint = dateHint;
            this.OptionalNameHint = optionalNameHint;
            this.InternalName = internalName;
            this.IconName = iconName;
            this.DefaultDate = defaultDate;
        }

        public string Name { get; }

        public string DateHint { get; }

        public string OptionalNameHint { get; }

        public AnniversaryTypes InternalName { get; }

        public string IconName { get; }

        public DateTime DefaultDate { get; }
    }
}