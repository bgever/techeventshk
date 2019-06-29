using System;
using Newtonsoft.Json;
using Tehk.Sourcers.Meetup.Svc.Utilities;

namespace Tehk.Sourcers.Meetup.Svc.Models
{
    public class MeetupEventModel
    {
        public string Id { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(MsUnixDateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("duration")]
        public int DurationInMs { get; set; }

        public string Name { get; set; }

        [JsonProperty("date_in_series_pattern")]
        public bool IsDateInSeriesPattern { get; set; }

        public string Status { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(MsUnixDateTimeOffsetConverter))]
        public DateTimeOffset StartTimestamp { get; set; }

        [JsonProperty("local_date")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("local_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("updated")]
        [JsonConverter(typeof(MsUnixDateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonProperty("waitlist_count")]
        public int WaitlistCount { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public int RsvpYesCount { get; set; }

        //TODO: Venue

        public Uri Link { get; set; }

        public string Description { get; set; }

        [JsonProperty("how_to_find_us")]
        public string HowToFindUs { get; set; }

        public string Visibility { get; set; }

        //"created":1534141275000,"duration":5400000,"id":"vvrncqyzhblc","name":"How Appysport Went Live FAST on KintoHub!",
        //"date_in_series_pattern":false,"status":"past","time":1559041200000,"local_date":"2019-05-28","local_time":"19:00",
        //"updated":1559048319000,"utc_offset":28800000,"waitlist_count":0,"yes_rsvp_count":40,
        //"venue":{"id":26394061,"name":"535 Jaffe Rd","lat":22.281391143798828,"lon":114.18392944335938,"repinned":true,"address_1":"535 Jaffe Rd","city":"Causeway Bay","country":"hk","localized_country_name":"Hong Kong"},"group":{"created":1533889980000,"name":"HK Microservices, Serverless & APIs - powered by KintoHub","id":29487067,"join_mode":"open","lat":22.270000457763672,"lon":114.13999938964844,"urlname":"HK-Microservices-Serverless-APIs-powered-by-KintoHub","who":"Members","localized_location":"Hong Kong, Hong Kong","state":"","country":"hk","region":"en_US","timezone":"Asia/Shanghai"},
        //"link":"https://www.meetup.com/HK-Microservices-Serverless-APIs-powered-by-KintoHub/events/vvrncqyzhblc/","description":"<p>KintoHub is stoked to present Appysport! Running in style on KintoHub for a little over 2 months. We're going to get down into the dirty details of what that entailed with a quick meet n greet and presentation from Appysports CTO, Sebastien McMurrich, who led the tech from idea to reality.</p> <p>For those who are new, KintoHub provides a platform to easily develop cloud-native apps using microservices and APIs.</p> <p>Not to mention, all members who come will get a $100 HKD voucher on your first booking on Appysport!</p> <p>The agenda is as follows:</p> <p>Intro to Appysport<br/>- How do we manage our Architecture with Kintohub<br/>- What's our product development flow with Kintohub<br/>- Bug in production? How Kintohub makes the hotfix process smooth<br/>- What we love about Kintohub's roadmap</p> <p>Please keep your RSVP updated as we have limited space!</p> ",
        //"how_to_find_us":"WeWork, 20/F Tower, 535 Jaffe Rd, Causeway Bay, Hong Kong","visibility":"public"}
    }
}