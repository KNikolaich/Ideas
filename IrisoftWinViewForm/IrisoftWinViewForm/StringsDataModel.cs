namespace IrisoftWinViewForm
{
    /// <summary>
    /// модель для передачи данных view < = > controller 
    /// </summary>
    public class StringsDataModel
    {
        public StringsDataModel(string strOne, string strTwo)
        {
            ArticleOne = strOne.ToLower();
            ArticleTwo = strTwo.ToLower();
        }

        public string ArticleOne { get; set; }

        public string ArticleTwo { get; set; }

        public float Answer { get; set; }

        public override string ToString()
        {
            return string.Format("{ArticleOne} и {ArticleTwo} совпадение {Answer}");
        }
    }
}