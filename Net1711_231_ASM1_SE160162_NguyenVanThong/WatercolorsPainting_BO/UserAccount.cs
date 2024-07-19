using System;
using System.Collections.Generic;

namespace WatercolorsPainting_BO
{
    public partial class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserPassword { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public int? Role { get; set; }
    }
}
