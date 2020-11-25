﻿using System.Diagnostics;
using System.Linq;
using Bodoconsult.Core.Database.MetaData;
using Bodoconsult.Core.Database.Sqlite.MetaData;
using Bodoconsult.Core.Database.Sqlite.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Core.Database.Sqlite.Test
{
    /// <summary>
    /// Install postgres version of Chinook database before testing.
    /// See https://github.com/lerocha/chinook-database/tree/master/ChinookDatabase/DataSources for details.
    ///
    /// Pay attention field names and table names are normally lower case words in PostgreSQL.
    /// If you want to use upper case or a mixture of upper and lower case, please set the names in
    /// quotation marks.
    /// </summary>
    [TestFixture]
    public class UnitTestSqliteMetaDataService
    {

        private IMetaDataService _service;

        private string _conn;


        const string Sql = "SELECT * FROM \"Customer\";";

        const string EntityName = "Customer";

        const string PrimaryKeyField = "CustomerId";

        const string TargetPath = @"D:\temp";


        [SetUp]
        public void Setup()
        {
            _conn = TestHelper.SqliteConnectionString;

            _service = new SqliteMetaDataService();
        }

        [Test]
        public void TestGetMetaData()
        {
            // Assert


            Assert.IsNull(_service.Table);

            // Act
            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            // Assert
            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());
        }


        //[Test]
        //public void TestGetMetaDataMoreTypes()
        //{
        //    // Assert
        //    const string sql = "SELECT * FROM \"Employee\";";

        //    const string entityName = "Employee";

        //    Assert.IsNull(_service.Table);

        //    // Act
        //    _service.GetMetaData(_conn, entityName, sql);

        //    // Assert
        //    Assert.IsNotNull(_service.Table);

        //    Assert.AreEqual(entityName, _service.Table.Name);

        //    Assert.IsTrue(_service.Table.Fields.Any());
        //}

        [Test]
        public void TestCreateEntityClass()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateEntityClass();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }


        [Test]
        public void TestCreateNewEntity()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateNewEntity();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }


        [Test]
        public void TestCreateMappingFromDbToEntityForDataReader()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateMappingFromDbToEntityForDataReader();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateNewEntityCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateNewEntityCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }


        [Test]
        public void TestCreateUpdateEntityCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateUpdateEntityCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateDeleteEntityCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateDeleteEntityCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateEntityServiceClass()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateEntityServiceClass();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateGetAllEntitiesCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateGetAllEntitiesCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateCountCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateCountCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestCreateGetByIdCommand()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.CreateGetByIdCommand();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            Debug.Print(result);
        }

        [Test]
        public void TestExport()
        {
            // Assert
            Assert.IsNull(_service.Table);

            _service.GetMetaData(_conn, EntityName, Sql, PrimaryKeyField);

            Assert.IsNotNull(_service.Table);

            Assert.AreEqual(EntityName, _service.Table.Name);

            Assert.IsTrue(_service.Table.Fields.Any());

            // Act
            var result = _service.ExportAll(TargetPath);

            // Assert
            Assert.IsTrue(result.Any());

            foreach (var fileName in result)
            {
                Debug.Print(fileName);
            }
        }
    }
}