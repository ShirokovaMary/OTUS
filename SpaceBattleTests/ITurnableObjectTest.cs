using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class ITurnableObjectTest
    {
       
        [Fact]
        public void Turnable_CorrectTurn()
        {
            // Arrange
            var mock = new Mock<ITurnable>();
            mock.SetupProperty(m => m.Velocity, new Vector2(-7, 3));

            var turn = new Turn();

            //Act
            turn.Execute(mock.Object, 1);

            //Assert
            var turnable = mock.Object;
            Assert.Equal(new Vector2(-7, 4), turnable.Velocity); // Проверяем

        }
       
    }
}
