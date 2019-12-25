using IrisoftWinViewForm;
using Xunit;

namespace ControllerTest
{
    public partial class StringsDataControllerTest
    {
        [Theory]
        [MemberData(nameof(EqualsStrings))]
        public void AllString_AreEquals(string dataOne, string dataTwo)
        {
            StringsDataModel model = new StringsDataModel(dataOne, dataTwo);
            var result = new StringsDataController(model).GetAnswer();

            Assert.Equal(result, actual: 1);
        }

    }
}
