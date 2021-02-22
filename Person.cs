namespace ProjektApp
{
    class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string pesel { get; set; }
        public string employmentType { get; set; }
        public float brutto { get; set; }
        public float netto { get; set; }
        public float tax { get; set; }
        public float pensionContribution { get; set; }
        public float disabilityPensionContribution { get; set; }
        public string bruttoString { get; set; }
        public string nettoString { get; set; }
        public string taxString { get; set; }
        public string pensionContributionString { get; set; }
        public string disabilityPensionContributionString { get; set; }
    }
}
