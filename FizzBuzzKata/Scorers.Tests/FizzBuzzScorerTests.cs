using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scorers.Models;

namespace Scorers.Tests
{
    [TestClass]
    public class FizzBuzzScorerTests
    {
        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_NumberIsNotMultiple_ReturnsNormalNumber()
        {
            TestFizzBuzzScorerScoring(0, "0");
            TestFizzBuzzScorerScoring(1, "1");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf3_ReturnsFizz()
        {
            TestFizzBuzzScorerScoring(3, "fizz");
            TestFizzBuzzScorerScoring(663, "fizz");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf5_ReturnsBuzz()
        {
            TestFizzBuzzScorerScoring(5, "buzz");
            TestFizzBuzzScorerScoring(545, "buzz");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf7_ReturnsPop()
        {
            TestFizzBuzzScorerScoring(7, "pop");
            TestFizzBuzzScorerScoring(28, "pop");
        }
        
        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf3And5_ReturnsFizzBuzz()
        {
            TestFizzBuzzScorerScoring(15, "fizz buzz");
            TestFizzBuzzScorerScoring(615, "fizz buzz");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf3And7_ReturnsFizzPop()
        {
            TestFizzBuzzScorerScoring(21, "fizz pop");
            TestFizzBuzzScorerScoring(147, "fizz pop");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf5And7_ReturnsBuzzPop()
        {
            TestFizzBuzzScorerScoring(35, "buzz pop");
            TestFizzBuzzScorerScoring(245, "buzz pop");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_StandardScoring_MultipleOf3And5And7_ReturnsFizzBuzzPop()
        {
            TestFizzBuzzScorerScoring(105, "fizz buzz pop");
            TestFizzBuzzScorerScoring(210, "fizz buzz pop");
        }

        [TestMethod]
        public void FizBuzzScorer_Score_OneCustomScoringRule_NumberIsNotMultiple_ReturnsNormalNumber()
        {
            var scoringSettings = new ScoringSettings().AddRule(2, "fuzz");

            TestFizzBuzzScorerScoring(0, "0", scoringSettings);
            TestFizzBuzzScorerScoring(3, "3", scoringSettings);
        }

        [TestMethod]
        public void FizBuzzScorer_Score_OneCustomScoringRule_NumberIsMultiple_ReturnsCustomScore()
        {
            const string customScore = "fuzz";
            var scoringSettings = new ScoringSettings();
            scoringSettings.AddRule(2, customScore);

            TestFizzBuzzScorerScoring(2, customScore, scoringSettings);
            TestFizzBuzzScorerScoring(16, customScore, scoringSettings);
        }

        [TestMethod]
        public void FizBuzzScorer_Score_ManyCustomScoringRules_NumberIsNotMultiple_ReturnsNormalNumber()
        {
            var scoringSettings = new ScoringSettings();
            scoringSettings
                .AddRule(2, "fuzz")
                .AddRule(9, "bizz")
                .AddRule(13, "pep");

            TestFizzBuzzScorerScoring(231, "231", scoringSettings);
        }

        [TestMethod]
        public void FizBuzzScorer_Score_ManyCustomScoringRules_NumberIsMultipleOf1Custom_ReturnsCustomScore()
        {
            var scoringSettings = new ScoringSettings();
            scoringSettings
                .AddRule(13, "pep")
                .AddRule(2, "fuzz")
                .AddRule(9, "bizz");

            TestFizzBuzzScorerScoring(13, "pep", scoringSettings);
        }

        [TestMethod]
        public void FizBuzzScorer_Score_ManyCustomScoringRules_NumberIsMultipleOf2Custom_ReturnsCustomScore()
        {
            var scoringSettings = new ScoringSettings();
            scoringSettings
                .AddRule(2, "fuzz")
                .AddRule(13, "pep")
                .AddRule(9, "bizz");

            TestFizzBuzzScorerScoring(26, "fuzz pep", scoringSettings);
        }

        [TestMethod]
        public void FizBuzzScorer_Score_ManyCustomScoringRules_NumberIsMultipleOf3Custom_ReturnsCustomScore()
        {
            var scoringSettings = new ScoringSettings();
            scoringSettings
                .AddRule(9, "bizz")
                .AddRule(2, "fuzz")
                .AddRule(13, "pep");

            TestFizzBuzzScorerScoring(234, "fuzz bizz pep", scoringSettings);
        }

        public void TestFizzBuzzScorerScoring(int number, string expectedResult, ScoringSettings scoringSettings = null)
        {
            // Arrange
            var fizzBuzzScorer = new FizzBuzzScorer(scoringSettings);

            // Act
            var fizzBuzzScore = fizzBuzzScorer.Score(number);

            // Assert
            Assert.AreEqual(expectedResult, fizzBuzzScore);
        }
    }
}
