using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoArchive.App.Model
{
    public partial class SearchVideoResponse
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("regionCode")]
        public string RegionCode { get; set; }
    }

    public partial class PageInfo
    {
        [JsonProperty("resultsPerPage")]
        public long ResultsPerPage { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }

    public partial class Snippet
    {
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Thumbnails
    {
        [JsonProperty("default")]
        public Default Default { get; set; }

        [JsonProperty("high")]
        public Default High { get; set; }

        [JsonProperty("medium")]
        public Default Medium { get; set; }
    }

    public partial class Default
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Id
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }




}
