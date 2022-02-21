using DataDomain.Data.NoSql.Models;
using Repositories.RepositoriesMongo;
using Repositories.RepositoriesMongo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.DataDomainTest
{
    public class TestCollectionsName
    {
        [Fact]
        public void CheckReturnValueCategoryModel()
        {
            // Arrange
            MongoDbBase<CategoryModel> categoryRepositoty = new CategoryRepositoty();

            // Act
            var result = categoryRepositoty.GetNameAtributes();

            // Assert
            Assert.Equal("Categories", result);
        } 
    }
}
