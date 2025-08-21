﻿using MongoDB.Driver;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Factories
{
    public class MongoSessionFactory(IMongoClient client) : IMongoSessionFactory
    {
        private readonly IMongoClient _client = client;
        private readonly AsyncLocal<IClientSessionHandle?> _scopedSession = new();

        public IClientSessionHandle GetSession()
        {
            if (_scopedSession.Value != null)
                return _scopedSession.Value;

            var session = _client.StartSession();
            _scopedSession.Value = session;
            return session;
        }
    }
}
