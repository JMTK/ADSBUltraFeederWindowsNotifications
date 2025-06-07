using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ADSBNotification
{
    public class Aircraft
    {
        [JsonProperty("hex", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("flight", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("flight")]
        public string Flight { get; set; }

        [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("r")]
        public string R { get; set; }

        [JsonProperty("t", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("t")]
        public string T { get; set; }

        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonProperty("ownOp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ownOp")]
        public string OwnOp { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonProperty("alt_baro", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alt_baro")]
        public int AltBaro { get; set; }

        [JsonProperty("alt_geom", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alt_geom")]
        public int AltGeom { get; set; }

        [JsonProperty("gs", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gs")]
        public double Gs { get; set; }

        [JsonProperty("track", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("track")]
        public double Track { get; set; }

        [JsonProperty("baro_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("baro_rate")]
        public int BaroRate { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonProperty("nic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nic")]
        public int Nic { get; set; }

        [JsonProperty("rc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rc")]
        public int Rc { get; set; }

        [JsonProperty("seen_pos", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("seen_pos")]
        public double SeenPos { get; set; }

        [JsonProperty("r_dst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("r_dst")]
        public double RDst { get; set; }

        [JsonProperty("r_dir", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("r_dir")]
        public double RDir { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonProperty("nac_p", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nac_p")]
        public int NacP { get; set; }

        [JsonProperty("nac_v", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nac_v")]
        public int NacV { get; set; }

        [JsonProperty("sil", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sil")]
        public int Sil { get; set; }

        [JsonProperty("sil_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sil_type")]
        public string SilType { get; set; }

        [JsonProperty("alert", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alert")]
        public int Alert { get; set; }

        [JsonProperty("spi", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("spi")]
        public int Spi { get; set; }

        [JsonProperty("mlat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mlat")]
        public List<string> Mlat { get; set; }

        [JsonProperty("tisb", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tisb")]
        public List<object> Tisb { get; set; }

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messages")]
        public int Messages { get; set; }

        [JsonProperty("seen", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("seen")]
        public double Seen { get; set; }

        [JsonProperty("rssi", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rssi")]
        public double Rssi { get; set; }

        [JsonProperty("emergency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("emergency")]
        public string Emergency { get; set; }

        [JsonProperty("nav_qnh", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nav_qnh")]
        public double? NavQnh { get; set; }

        [JsonProperty("nav_altitude_mcp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nav_altitude_mcp")]
        public int? NavAltitudeMcp { get; set; }

        [JsonProperty("nav_heading", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nav_heading")]
        public double? NavHeading { get; set; }

        [JsonProperty("nic_baro", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nic_baro")]
        public int? NicBaro { get; set; }

        [JsonProperty("gva", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gva")]
        public int? Gva { get; set; }

        [JsonProperty("sda", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sda")]
        public int? Sda { get; set; }

        [JsonProperty("geom_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("geom_rate")]
        public int? GeomRate { get; set; }

        [JsonProperty("squawk", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("squawk")]
        public string Squawk { get; set; }

        [JsonProperty("lastPosition", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lastPosition")]
        public LastPosition LastPosition { get; set; }
    }

    public class LastPosition
    {
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonProperty("nic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nic")]
        public int Nic { get; set; }

        [JsonProperty("rc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rc")]
        public int Rc { get; set; }

        [JsonProperty("seen_pos", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("seen_pos")]
        public double SeenPos { get; set; }
    }

    public class AircraftResponse
    {
        [JsonProperty("now", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("now")]
        public double Now { get; set; }

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messages")]
        public int Messages { get; set; }

        [JsonProperty("aircraft", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("aircraft")]
        public List<Aircraft> Aircraft { get; set; }
    }
}
