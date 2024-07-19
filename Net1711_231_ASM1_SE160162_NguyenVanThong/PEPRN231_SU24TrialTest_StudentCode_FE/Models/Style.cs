using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PEPRN231_SU24TrialTest_StudentCode_FE
{
    public class Style
    {
        [JsonPropertyName("styleId")]
        public string StyleId { get; set; } = null!;

        [JsonPropertyName("styleName")]
        public string StyleName { get; set; } = null!;

        [JsonPropertyName("styleDescription")]
        public string StyleDescription { get; set; } = null!;

        [JsonPropertyName("originalCountry")]
        public string? OriginalCountry { get; set; }
    }

}
