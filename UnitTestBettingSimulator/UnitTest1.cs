using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bettingSimulator;
using static bettingSimulator.bettingSimulator;

namespace UnitTestBettingSimulator
{
    [TestClass]
    public class PowerBallTests
    {
        [TestMethod]
        public void winning()
        {
            powerBall myResults = new powerBall(1, 2, 3, 4, 5, 6, 7);
            powerBall winningResults = new powerBall(1, 2, 3, 4, 5, 6, 7);

            Assert.AreEqual(myResults.CompareTo(winningResults),0);
        }

        [TestMethod]
        public void losing()
        {
            powerBall myResults = new powerBall(1, 2, 3, 4, 5, 6, 7);
            powerBall winningResults = new powerBall(3, 2, 3, 4, 5, 6, 7);

            Assert.AreNotEqual(myResults.CompareTo(winningResults), 0);
        }

        [TestMethod]
        public void gettingNumber()
        {
            powerBall myResults = new powerBall(1, 2, 3, 4, 5, 6, 7);
            
            Assert.AreEqual(myResults.getNumber(3), 4);
        }
    }
    [TestClass]
    public class HorseRacingTests
    {
        [TestMethod]
        public void winning()
        {
            horseRace myHorse = new horseRace(1);
            horseRace theirHorse = new horseRace(1);

            Assert.AreEqual(myHorse.CompareTo(theirHorse), 0);
        }

        [TestMethod]
        public void losing()
        {
            horseRace myHorse = new horseRace(1);
            horseRace theirHorse = new horseRace(2);

            Assert.AreNotEqual(myHorse.CompareTo(theirHorse), 0);
        }
    }
    [TestClass]
    public class PokerCardsTests
    {
        [TestMethod]
        public void winning()
        {
            poker myPoker = new poker(1, 2, 3, 4, 5);
            poker theirPoker = new poker(1, 2, 3, 4, 4);

            Assert.AreEqual(myPoker.CompareTo(theirPoker),1);
        }

        [TestMethod]
        public void losing()
        {
            poker myPoker = new poker(1, 2, 3, 4, 5);
            poker theirPoker = new poker(1, 2, 3, 4, 6);

            Assert.AreNotEqual(myPoker.CompareTo(theirPoker), 1);
        }

        [TestMethod]
        public void getCard()
        {
            poker myPoker = new poker(1, 2, 3, 4, 12);
            
            Assert.AreEqual(myPoker.getCardNumber(4), 12);
        }
    }
}
