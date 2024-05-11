using EvoPlanet.Simulator.Celestial;
using EvoPlanet.Simulator.Simulator;
using MathNet.Numerics.LinearAlgebra;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdk.evoPlanet.Simulator.uTest.Simulators
{
    internal class SimulatorTest
    {
        [Test]
        public void WhenAllValuesAreOne_ResultIsOne()
        {
            // Arrange
            var pos1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            var vel1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass1 = 10.0;
            double radius1 = 0.1;

            var pos2 = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var vel2 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass2 = 10.0;
            double radius2 = 0.1;

            var body1 = new CelestialBody(pos1, vel1, mass1, radius1);
            var body2 = new CelestialBody(pos2, vel2, mass2, radius2);
            var solarSystem = new SolarSystem();
            solarSystem.CelestialBodies.Add(body1);
            solarSystem.CelestialBodies.Add(body2);

            var forceVector = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var gravityCalculator = new Mock<IGravityCalculator>();
            gravityCalculator.Setup(m => m.CalcForce(body1, body2))
                .Returns(forceVector);
            gravityCalculator.Setup(m => m.CalcForce(body2, body1))
                .Returns(-forceVector);
            var simulator = new SimulatorImpl(gravityCalculator.Object);

            // Act
            simulator.Simulate(solarSystem, 1);

            // Assert
            Assert.That(body1.Position[0], Is.EqualTo(0.1));
            Assert.That(body1.Position[1], Is.EqualTo(0));
            Assert.That(body2.Position[0], Is.EqualTo(0.9));
            Assert.That(body2.Position[1], Is.EqualTo(0));
            gravityCalculator.Verify(m => m.CalcForce(body1, body2), Times.Once());
            gravityCalculator.Verify(m => m.CalcForce(body2, body1), Times.Once());
        }

        [Test]
        public void IsOneHeavierThanTheOther()
        {
            // Arrange
            var pos1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            var vel1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass1 = 10.0;
            double radius1 = 0.1;

            var pos2 = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var vel2 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass2 = 10.0;
            double radius2 = 0.1;

            var body1 = new CelestialBody(pos1, vel1, mass1, radius1);
            var body2 = new CelestialBody(pos2, vel2, mass2, radius2);
            var solarSystem = new SolarSystem();
            solarSystem.CelestialBodies.Add(body1);
            solarSystem.CelestialBodies.Add(body2);

            var forceVector = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var gravityCalculator = new Mock<IGravityCalculator>();
            gravityCalculator.Setup(m => m.CalcForce(body1, body2))
                .Returns(forceVector);
            gravityCalculator.Setup(m => m.CalcForce(body2, body1))
                .Returns(-forceVector);
            var simulator = new SimulatorImpl(gravityCalculator.Object);

            // Act
            simulator.Simulate(solarSystem, 1);

            // Assert
            Assert.Greater(body1.Mass, body2.Mass);
            gravityCalculator.Verify(m => m.CalcForce(body1, body2), Times.Once());
            gravityCalculator.Verify(m => m.CalcForce(body2, body1), Times.Once());
        }

        [Test]
        public void IsTwoPositionsTheSame()
        {
            // Arrange
            var pos1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            var vel1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass1 = 10.0;
            double radius1 = 0.1;

            var pos2 = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var vel2 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 });
            double mass2 = 10.0;
            double radius2 = 0.1;

            var body1 = new CelestialBody(pos1, vel1, mass1, radius1);
            var body2 = new CelestialBody(pos2, vel2, mass2, radius2);
            var solarSystem = new SolarSystem();
            solarSystem.CelestialBodies.Add(body1);
            solarSystem.CelestialBodies.Add(body2);

            var forceVector = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 0.0 });
            var gravityCalculator = new Mock<IGravityCalculator>();
            gravityCalculator.Setup(m => m.CalcForce(body1, body2))
                .Returns(forceVector);
            gravityCalculator.Setup(m => m.CalcForce(body2, body1))
                .Returns(-forceVector);
            var simulator = new SimulatorImpl(gravityCalculator.Object);

            // Act
            simulator.Simulate(solarSystem, 1);

            // Assert

            Assert.That(body1.Position[0], Is.EqualTo(body2.Position[0])); 
            Assert.That(body1.Position[1], Is.EqualTo(body2.Position[1]));
            gravityCalculator.Verify(m => m.CalcForce(body1, body2), Times.Once());
            gravityCalculator.Verify(m => m.CalcForce(body2, body1), Times.Once());
        }


    }
}