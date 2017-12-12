using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoArchive.App.Model.YouTubeModel
{
    public partial class SearchVideoResponse
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }
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
        [JsonProperty("contentDetails")]
        public ContentDetails ContentDetails { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }
    }

    public partial class Statistics
    {
        [JsonProperty("commentCount")]
        public string CommentCount { get; set; }

        [JsonProperty("dislikeCount")]
        public string DislikeCount { get; set; }

        [JsonProperty("favoriteCount")]
        public string FavoriteCount { get; set; }

        [JsonProperty("likeCount")]
        public string LikeCount { get; set; }

        [JsonProperty("viewCount")]
        public string ViewCount { get; set; }
    }

    public partial class Snippet
    {
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("defaultAudioLanguage")]
        public string DefaultAudioLanguage { get; set; }

        [JsonProperty("defaultLanguage")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }

        [JsonProperty("localized")]
        public Localized Localized { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

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

        [JsonProperty("maxres")]
        public Default Maxres { get; set; }

        [JsonProperty("medium")]
        public Default Medium { get; set; }

        [JsonProperty("standard")]
        public Default Standard { get; set; }
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

    public partial class Localized
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class ContentDetails
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("licensedContent")]
        public bool LicensedContent { get; set; }

        [JsonProperty("projection")]
        public string Projection { get; set; }
    }



}
