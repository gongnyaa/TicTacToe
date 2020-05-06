using NUnit.Framework;
using Script;
using UnityEditor.VersionControl;

namespace Tests.Editor
{
    public class GameLogicTests
    {
        // A Test behaves as an ordinary method

        [Test]
        public void CanSelectTest()
        {
            var gameLogic = new GameLogic();
            Assert.IsTrue(gameLogic.CanSelect(0, 0));
            
            gameLogic.Select(0, 0);
            Assert.IsFalse(gameLogic.CanSelect(0, 0));
        }

        [Test]
        public void SelectTest()
        {
            var gameLogic = new GameLogic();
            gameLogic.Select(0, 0);
        }

        [Test]
        public void GetTurnPlayerTest()
        {
            var gameLogic = new GameLogic();
            var turnPlayer = gameLogic.GetTurnPlayer();
            Assert.AreEqual(PlayerMark.Circle, turnPlayer);
        }
        
        
        [Test]
        public void GetWinnerPlayerTest()
        {
            var gameLogic = new GameLogic();
            gameLogic.Select(0,0);
            gameLogic.Select(1,0);
            gameLogic.Select(0,1);
            gameLogic.Select(1,1);
            Assert.AreEqual(PlayerMark.Blank, gameLogic.GetWinnerPlayer());
            gameLogic.Select(0,2);
            Assert.AreEqual(PlayerMark.Circle, gameLogic.GetWinnerPlayer());
        }
    }
}