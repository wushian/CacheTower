﻿using CacheTower.Providers.Database.MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoFramework.Infrastructure.Commands;
using MongoFramework.Infrastructure.Mapping;

namespace CacheTower.Providers.Database.MongoDB.Commands
{
	public class EvictCommand : IWriteCommand<DbCachedEntry>
	{
		private string CacheKey { get; }

		public EvictCommand(string cacheKey)
		{
			CacheKey = cacheKey;
		}

		public IEnumerable<WriteModel<DbCachedEntry>> GetModel()
		{
			var filter = Builders<DbCachedEntry>.Filter.Eq(e => e.CacheKey, CacheKey);
			yield return new DeleteManyModel<DbCachedEntry>(filter);
		}
	}
}
