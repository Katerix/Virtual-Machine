using Crossplatform_Lab4;

namespace TestVm
{
    /// <summary>
    /// Command tests
    /// </summary>
    public sealed class CommandTests
    {
        #region Public Properties

        /// <summary>
        /// The vm
        /// </summary>
        public VirtualMachine VM => new();

        #endregion

        #region Test Data

        /// <summary>
        /// Gets the test data1.
        /// </summary>
        /// <returns>Test commands.</returns>
        static IEnumerable<string> GetTestData1()
        {
            yield return "0 num 8";
            yield return "1 4";
            yield return "4 9";
            yield return "2";
            yield return "5 2";
            yield return "3";
        }

        /// <summary>
        /// Gets the test data2.
        /// </summary>
        /// <returns>Test commands.</returns>
        static IEnumerable<string> GetTestData2()
        {
            yield return "1 2";
            yield return "2";
            yield return "4 6";
            yield return "2";
            yield return "5 7";
        }

        /// <summary>
        /// Gets the test data3.
        /// </summary>
        /// <returns>Test commands.</returns>
        static IEnumerable<string> GetTestData3()
        {
            yield return "0 num 5";
            yield return "1 3";
            yield return "4 6";
            yield return "6"; // non-existing command code
            yield return "5 2";
            yield return "3";
        }
        
        /// <summary>
        /// Gets the test data4.
        /// </summary>
        /// <returns>Test commands.</returns>
        static IEnumerable<string> GetTestData4()
        {
            yield return "3"; // no value was provided
        }

        #endregion

        #region Test Methods

        [Fact]
        public void CommandExecutionReturnsTrue()
        {
            var data = GetTestData1();

            Assert.True(VM.ExecuteCommands(data));

            data = GetTestData2();

            Assert.True(VM.ExecuteCommands(data));
        }
        
        [Fact]
        public void CommandExecutionReturnsFalse()
        {
            var data = GetTestData3();

            Assert.False(VM.ExecuteCommands(data));

            data = GetTestData4();

            Assert.False(VM.ExecuteCommands(data));
        }

        #endregion
    }
}