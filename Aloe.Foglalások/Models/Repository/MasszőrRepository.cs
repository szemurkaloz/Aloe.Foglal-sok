using MongoDB.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Aloe.Foglalások.Models.Repository
{
    public class MasszőrRepository : MongoRepository<Masszor, int>, IMongoRepository<Masszor, int>
    {
        public MasszőrRepository(string connectionName) : base(connectionName)
        {
        }

        public MasszőrRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override int EntityKey(Masszor entity)
        {
            return int.Parse(entity.Id);
        }

        protected override Expression<Func<Masszor, bool>> KeyExpression(int key)
        {
            return i => int.Parse(i.Id) == key;
        }
    }

    public class DolgozoRepository : MongoRepository<Dolgozo, string>
    {
        public DolgozoRepository(string connectionName) : base(connectionName)
        {
        }
        public DolgozoRepository(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }

        public override string EntityKey(Dolgozo entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<Dolgozo, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }

    public class BerletTipusRepository : MongoRepository<BerletTipus, string>//, IMongoRepository<Masszor, int> 
    {
        public BerletTipusRepository(string connectionName)
            : base(connectionName)
        {
        }

        public BerletTipusRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override string EntityKey(BerletTipus entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<BerletTipus, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }

    public class KezelesRepository : MongoRepository<Kezeles, string>//, IMongoRepository<Masszor, int> 
    {
        public KezelesRepository(string connectionName)
            : base(connectionName)
        {
        }

        public KezelesRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override string EntityKey(Kezeles entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<Kezeles, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }

    public class IdopontRepository : MongoRepository<Idopont, string>//, IMongoRepository<Masszor, int> 
    {
        public IdopontRepository(string connectionName)
            : base(connectionName)
        {
        }

        public IdopontRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override string EntityKey(Idopont entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<Idopont, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }

    public class SzolgaltatasTipusRepository : MongoRepository<SzolgaltatasTipus, string>//, IMongoRepository<Masszor, int> 
    {
        public SzolgaltatasTipusRepository(string connectionName)
            : base(connectionName)
        {
        }

        public SzolgaltatasTipusRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override string EntityKey(SzolgaltatasTipus entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<SzolgaltatasTipus, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }

    public class SzolgaltatasTartamRepository : MongoRepository<SzolgaltatasTartam, string>//, IMongoRepository<Masszor, int> 
    {
        public SzolgaltatasTartamRepository(string connectionName)
            : base(connectionName)
        {
        }

        public SzolgaltatasTartamRepository(MongoUrl mongoUrl)
            : base(mongoUrl)
        {
        }

        public override string EntityKey(SzolgaltatasTartam entity)
        {
            return entity.Id;
        }

        protected override Expression<Func<SzolgaltatasTartam, bool>> KeyExpression(string key)
        {
            return i => i.Id == key;
        }
    }
}
