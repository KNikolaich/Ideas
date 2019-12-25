namespace IrisoftWinViewForm
{
    public class StringsDataController
    {
        private StringsDataModel _model;

        public StringsDataController(StringsDataModel model)
        {
            _model = model;
            if (model.ArticleOne == model.ArticleTwo)
            {
                model.Answer = 1;
            }
        }

        public double GetAnswer() { return _model.Answer; }
    }
}