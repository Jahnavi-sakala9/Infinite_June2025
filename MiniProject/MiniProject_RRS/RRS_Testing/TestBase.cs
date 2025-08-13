using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MiniProject_RRS;
using System.Transactions;

namespace RRS_Testing
{
    public abstract class TestBase
    {
        private TransactionScope _scope;   

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var cs = "Data Source=ICS-LT-1YX9J84\\SQLEXPRESS;Initial Catalog=RRSdatabase;" +
                                "user id=sa;password=Sakalajahnavi@123;";
            Db.Init(cs);
        }

        [SetUp]
        public void SetUp()
        {
            _scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        [TearDown]
        public void TearDown()
        {
            if (_scope != null) _scope.Dispose(); // rollback
        }
    }
}
