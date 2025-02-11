namespace SHMS.Models;


    public class PatientReportViewModel
    {
        public string PatientName
        {
            get; set;
        }
        public List<TestResultViewModel> TestResults
        {
            get; set;
        }
    }

    public class TestResultViewModel
    {
        public string TestName
        {
            get; set;
        }
        public double Value
        {
            get; set;
        }
        public string ReferenceRange
        {
            get; set;
        }
        public bool IsAbnormal
        {
            get; set;
        }
    }

