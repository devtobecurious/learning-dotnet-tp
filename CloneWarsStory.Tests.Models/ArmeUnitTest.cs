using CloneWarsStory.Core.Models;
using CloneWarsStory.Core.Models.Armes;
using CloneWarsStory.Tests.Models.Fakes;
using Xunit;

namespace CloneWarsStory.Tests.Models
{
    public class ArmeUnitTest
    {
        [Fact]
        public void Verif()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void DevraitInfliger20DeDegat()
        {
            // Arrange
            int puissance = 10;
            Arme arme = new SabreLaser("1", 10);
            FakeEtreVivant fake = new() { PointsDeVie = 100 };

            // Act
            arme.FaireMal(fake);

            // Assert
            Assert.True(fake.PointsDeVie == 80, 
                        $"Ici le degat est de 20, donc 100 - 20, il est de {fake.PointsDeVie}");
            
        }

        [Fact]
        public void DevraitAvoirUneVieAZero()
        {
            // Arrange
            int puissance = 10;
            Arme arme = new SabreLaser("1", 60);
            // FakeEtreVivant fake = new() { PointsDeVie = 0 };
            Moq.Mock<IEtreVivant> moq = new Moq.Mock<IEtreVivant>();

            //moq.SetupGet(x => x.PointsDeVie).Returns(100);
            //moq.SetupSet(x => x.PointsDeVie = -10);

            var fake = moq.Object;

            // Act
            arme.FaireMal(fake);

            // moq.Verify();

            // Assert
            Assert.True(fake.PointsDeVie == 0);
        }
    }
}