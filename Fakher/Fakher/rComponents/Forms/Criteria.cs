namespace rComponents
{
    public class Criteria
    {
        public string FieldName { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }

        public Criteria()
        {
        }

        public string FarsiText
        {
            get { return FieldName + "  = " + Value + ""; }
        }

        public string Text
        {
            get { return Field + "  = \"" + Value + "\""; }
        }
    }
}