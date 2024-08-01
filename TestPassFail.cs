namespace CIGALHE.MFD.Optical
{
    class TestPassFail
    {
        public TestPassFail(string name, int passes, int fails)
        {
            Name = name;
            Passes = passes;
            Fails = fails;
        }

        public string Name { get; set; }
        public int Passes { get; set; }
        public int Fails { get; set; }
    }
}
