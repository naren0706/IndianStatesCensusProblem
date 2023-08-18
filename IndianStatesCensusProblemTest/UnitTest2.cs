using IndianStateCensusAnaylzer;
using IndianStatesCensusProblem;

namespace IndianStatesCensusProblemTest
{
    public class StateCodeTest
    {
        public string stateCodeDataFilePath = @"E:\BridgeGateProblems\IndianStatesCensusProblem\IndianStatesCensusProblem\Files\StateCode.csv";
        public string stateCode_NODataFilePath = @"E:\BridgeLabz\IndianStateCensusAnayl.csv";
        public string stateCode_FileIncorrect = @"E:\certificates\complains traning.pdf";


        [Test]
        public void GivenStateCodeData_WhenAnalysed_RecordsShouldBeMatched()
        {
            Assert.AreEqual(
                StateCodeAnalyser.ReadStateCodeData(stateCodeDataFilePath), CsvStateCode.ReadStateCodeData(stateCodeDataFilePath)
                );
            Assert.Pass();
        }
        [Test]
        public void GivenStateCodeDataFileIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyser.ReadStateCodeData(stateCode_FileIncorrect);
            }
            catch (StateCodeException ex)
            {
                Assert.AreEqual(ex.Message, "File extension incorrect");
            }



        }
        [Test]
        public void GivenStateCodeDataFileNotExists_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyser.ReadStateCodeData(stateCode_NODataFilePath);
            }
            catch (StateCodeException ex)
            {
                Assert.AreEqual(ex.Message, "File not exists");
            }



        }
        [Test]
        public void GivenStateCodeHeaderIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyser.ReadStateCodeData(stateCodeDataFilePath);
            }
            catch (StateCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Header Incorrect");
            }
        }
        [Test]
        public void GivenStateCodeDelimeterIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyser.ReadStateCodeData(stateCodeDataFilePath);
            }
            catch (StateCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
    }
}