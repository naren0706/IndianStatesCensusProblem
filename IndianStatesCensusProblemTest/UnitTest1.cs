using IndianStatesCensusProblem;
namespace IndianStatesCensusProblemTest
{
    public class Tests
    {
        public static string stateCensusDataFilePath = @"E:\BridgeGateProblems\IndianStatesCensusProblem\IndianStatesCensusProblem\Files\StateCensusData.csv";
        public static string stateCensusDataFilePath2 = @"E:\BridgeLabz\IndianStateCensusAnaylzer\IndianStateCensusAnaylzer\Files\StateCensusData.csv";



        [Test]
        public void GivenStateCencusData_WhenAnalysed_RecordsShouldBeMAtched()
        {
            Assert.AreEqual(StateCensusAnalyser.ReadstateCensusData(stateCensusDataFilePath), CsvStateCensus.ReadStateCensusData(stateCensusDataFilePath));
            Assert.Pass();
        }
        [Test]
        public void GivenStateCencusDataFileIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyser.ReadstateCensusData(stateCensusDataFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File extension incorrect");
            }
        }
        [Test]
        public void GivenStateCensusNoData_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyser.ReadstateCensusData(stateCensusDataFilePath2);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File Not Exist");
            }
        }
        [Test]
        public void GivenStateCensusHeaderIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyser.ReadstateCensusData(stateCensusDataFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Header Incorrect");
            }
        }
        [Test]
        public void GivenStateDelimeterIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyser.ReadstateCensusData(stateCensusDataFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
    }
}