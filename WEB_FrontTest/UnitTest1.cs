using Projects.Shared;
using WEB_Front.Data;

namespace WEB_FrontTest
{
    public class UnitTest1
    {
        [Fact]
        public async void TestGetProductsById()
        {
            Product expected, actual;
            GetData getdata = new GetData();
            actual =await getdata.GetProductsByIDAsync(15);
            expected = new Product();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async void TestGetCatedoryById()
        {
            Category expected, actual;
            GetData getdata = new GetData();
            actual = await getdata.GetCategoriesbyId(4);
            expected = new Category();
            Assert.Equal(expected, actual);
        }
    }
}