namespace Engine.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.FSharp.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FSSC = Microsoft.FSharp.Collections.FSharpSet<char>;

    [TestClass]
    public class CombinationTests
    {
        [TestMethod]
        public void AssertAllCombinationsArePresent()
        {
            var result = Functions.Calculate(ListModule.OfSeq(new[] { 'A', 'B', 'C' })).ToList();

            var expectedCombinations = new List<FSSC>
                                       {
                                           new FSSC(new[] { 'A' }),
                                           new FSSC(new[] { 'B' }),
                                           new FSSC(new[] { 'C' }),
                                           new FSSC(new[] { 'A', 'B' }),
                                           new FSSC(new[] { 'A', 'C' }),
                                           new FSSC(new[] { 'B', 'C' }),
                                           new FSSC(new[] { 'A', 'B', 'C' }),
                                       };

            Assert.AreEqual(result.Count, expectedCombinations.Count);

            foreach (var expectedCombination in expectedCombinations)
            {
                Assert.IsTrue(result.Contains(expectedCombination), "{0} was not found in the results");
            }
        }
    }
}
