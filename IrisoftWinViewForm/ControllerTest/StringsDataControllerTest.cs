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

            Assert.Equal(result, 1f);
        }

        [Theory]
        [MemberData(nameof(Differents50PercentStrings))]
        public void AllString_AreDifferent50Percents(string dataOne, string dataTwo)
        {
            StringsDataModel model = new StringsDataModel(dataOne, dataTwo);
            var result = new StringsDataController(model).GetAnswer();

            Assert.Equal(result, 0.5f);
        }


        [Theory]
        [MemberData(nameof(FullDifferentsStrings))]
        public void AllString_AreDifferentFully(string dataOne, string dataTwo)
        {
            StringsDataModel model = new StringsDataModel(dataOne, dataTwo);
            var result = new StringsDataController(model).GetAnswer();

            Assert.Equal(result, 0f);
        }
    }
}
