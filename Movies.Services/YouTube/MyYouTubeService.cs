using System;
using System.Collections.Generic;
using System.Linq;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Movies.Contracts;
using Movies.Services.Common;

namespace Movies.Services.YouTube
{
    
    public class MyYouTubeService : IVideoService
    {
        private readonly IYouTubeConfiguration _configurationFactory;

        /// <summary>
        /// Init Configuration Object
        /// </summary>
        /// <param name="configurationFactory"></param>
        public MyYouTubeService(IConfigurationsFactory configurationFactory)
        {
            _configurationFactory = configurationFactory.CreateYouTubeConfiguration();
        }


        /// <summary>
        /// Search in YouTube WebService for trailer
        /// </summary>
        /// <param name="movieName">Movie name</param>
        /// <returns>return first matched trailer video</returns>
        public string Search(string movieName)
        {
            YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
                                                    {
                                                        ApiKey = _configurationFactory.ApiKey,
                                                        ApplicationName = this.GetType().ToString()
                                                    });

            var searchListRequest = youtubeService.Search.List(_configurationFactory.SearchPart);
            searchListRequest.Q = movieName;
            searchListRequest.MaxResults = _configurationFactory.MaxResult;
            searchListRequest.Type = _configurationFactory.SearchType;
            searchListRequest.VideoEmbeddable = SearchResource.ListRequest.VideoEmbeddableEnum.True__;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();



            SearchResult video = searchListResponse.Items.FirstOrDefault();
            return video != null ? video.Id.VideoId : "";
        }
    }
}
