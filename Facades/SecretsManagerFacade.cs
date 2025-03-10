﻿using MPM.DataAccessAwsPostGresql.Interface;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;

namespace MPM.DataAccessAwsPostGresql.Facades
{
    public class SecretsManagerFacade : ISecretCache
    {
        private readonly SecretsManagerCache _secretsManagerCache;
        public SecretsManagerFacade(IAmazonSecretsManager amazonSecretsManager)
        {
            _secretsManagerCache = new SecretsManagerCache(amazonSecretsManager, new SecretCacheConfiguration { CacheItemTTL = 900 });
        }

        public async Task<string> GetSecretValueAsync(string secretKey)
         => await _secretsManagerCache.GetSecretString(secretKey);
    }
}
