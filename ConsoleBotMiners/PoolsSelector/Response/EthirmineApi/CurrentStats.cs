using Newtonsoft.Json;

namespace PoolsSelector.Response.EthirmineApi
{
    public class CurrentStats
    {
        [JsonProperty("time")]
        public uint? Time { get; set; }

        [JsonProperty("lastSeen")]
        public uint? LastSeen { get; set; }


        [JsonProperty("reportedHashrate")]
        public float? reportedHashrate { get; set; }

        [JsonProperty("currentHashrate")]
        public float? currentHashrate { get; set; }

        [JsonProperty("validShares")]
        public float? validShares { get; set; }

        [JsonProperty("invalidShares")]
        public float? invalidShares { get; set; }

        [JsonProperty("staleShares")]
        public float? staleShares { get; set; }

        [JsonProperty("averageHashrate")]
        public float? averageHashrate { get; set; }

        [JsonProperty("activeWorkers")]
        public string activeWorkers { get; set; }

        [JsonProperty("unpaid")]
        public uint? unpaid { get; set; }
        [JsonProperty("unconfirmed")]
        public float? unconfirmed { get; set; }

        [JsonProperty("coinsPerMin")]
        public float? coinsPerMin { get; set; }

        [JsonProperty("usdPerMin")]
        public float? usdPerMin { get; set; }

        [JsonProperty("btcPerMin")]
        public float? btcPerMin { get; set; }
        //"lastSeen": null,
        //"reportedHashrate": null,
        // "currentHashrate": null,
        // "validShares": null,
        // "invalidShares": null,
        // "staleShares": null,
        // "averageHashrate": 4444444.444444444,
        // "activeWorkers": null,
        // "unpaid": 7329162072959998,
        // "unconfirmed": null,
        // "coinsPerMin": 1.582517104302062e-7,
        // "usdPerMin": 0.00023352888404764668,
        // "btcPerMin": 4.96593867329987e-9
    }
}
