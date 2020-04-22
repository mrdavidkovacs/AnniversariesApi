using System;
using JetBrains.Annotations;

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

        [PublicAPI]
        public string Name { get; }

        [PublicAPI]
        public string DateHint { get; }

        [PublicAPI]
        public string OptionalNameHint { get; }

        [PublicAPI]
        public AnniversaryTypes InternalName { get; }

        [PublicAPI]
        public string IconName { get; }

        [PublicAPI]
        public DateTime DefaultDate { get; }
    }
}