namespace IrisoftWinViewForm
{
    /// <summary>
    /// модель для передачи данных view < = > controller 
    /// </summary>
    public class StringsDataModel
    {
        public StringsDataModel(string strOne, string strTwo)
        {
            ArticleOne = strOne;
            ArticleTwo = strTwo;
        }

        public string ArticleOne { get; set; }

        public string ArticleTwo { get; set; }

        public double Answer { get; set; }
    }
}