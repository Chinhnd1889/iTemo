namespace iTemo.jsGrid
{
    public class NumberOption
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
        public string ASign { get; set; }
        public string PSign { get; set; }
        public string MRound { get; set; }
        public bool APad { get; set; }
        public int? NumberOfDecimal { get; set; }

        private string _aSep;

        private string _aDec;

        public string ASep
        {
            get
            {
                if (string.IsNullOrEmpty(_aSep))
                {
                    _aSep = string.Empty;
                }
                return _aSep;

            }
            set => _aSep = value;
        }
        public string ADec
        {
            get
            {
                if (string.IsNullOrEmpty(_aDec))
                {
                    _aDec = ".";
                }
                return _aDec;

            }
            set => _aDec = value;
        }

        public NumberOption()
        {
            APad = true;
        }
    }
}
