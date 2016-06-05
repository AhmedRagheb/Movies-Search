using System;
using System.Configuration;

namespace Movies.Helpers
{
    public static class ConfigurationHelper
    {
        internal static T Get<T>(string appSettingsKey, T defaultValue)
        {
            string text = ConfigurationManager.AppSettings[appSettingsKey];
            if (string.IsNullOrWhiteSpace(text))
                return defaultValue;

            try
            {
                var value = Convert.ChangeType(text, typeof(T));
                return (T)value;
            }
            catch
            {
                return defaultValue;
            }
        }

        static string _moviesDbProvider;
        public static string MoviesDbProvider
        {
            get
            {
                if (_moviesDbProvider == null)
                {
                    _moviesDbProvider = Get("MoviesDbProvider", "TheMovieDb");
                }
                return _moviesDbProvider;
            }
        }

        static int _cacheExpiresHours = 0;
        public static int CacheExpiresHours
        {
            get
            {
                if (_cacheExpiresHours == 0)
                {
                    _cacheExpiresHours = Get("CacheExpiresHours", 2);
                }
                return _cacheExpiresHours;
            }
        }
    }
}
