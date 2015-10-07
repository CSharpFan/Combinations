namespace Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using Microsoft.FSharp.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CombinationTests
    {
        [TestMethod]
        public void AssertAllCombinationsArePresent()
        {
            var result = Functions.Calculate(ListModule.OfSeq(new[] { 'A', 'B', 'C' })).ToList();

            var expectedCombinations = new List<FSharpSet<char>>
                                       {
                                           new FSharpSet<char>(new[] { 'A' }),
                                           new FSharpSet<char>(new[] { 'B' }),
                                           new FSharpSet<char>(new[] { 'C' }),
                                           new FSharpSet<char>(new[] { 'A', 'B' }),
                                           new FSharpSet<char>(new[] { 'A', 'C' }),
                                           new FSharpSet<char>(new[] { 'B', 'C' }),
                                           new FSharpSet<char>(new[] { 'A', 'B', 'C' }),
                                       }
                ;

            Assert.AreEqual(result.Count, expectedCombinations.Count);

            foreach (var expectedCombination in expectedCombinations)
            {
                Assert.IsTrue(result.Contains(expectedCombination), "{0} was not found in the results");
            }
        }
    }
}