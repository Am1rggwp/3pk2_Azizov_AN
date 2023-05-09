namespace pz_kr
{
    public class TXTinfo
    {
        public string NameTxt { get; set; }
        public string NoteTxt { get; set; }

        public TXTinfo(string name, string txt)
        {
            NameTxt = name;
            NoteTxt = txt;
        }
    }
}
