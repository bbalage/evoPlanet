/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using EvoPlanet.Simulator.Celestial;
using EvoPlanet.Simulator.Simulator;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdk.SimulatorConsole.Simulator
{
    internal class CollisionDetectorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NonCollidingBodies_NotColliding()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 100000.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.False);
        }

        [Test]
        public void CollidingBodies_Colliding()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.True);
        }

        //Finish test on zero radius, same position
        [Test]
        public void EdgeCaseCollidingBodies_CollidingOnSummedRadius()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                6);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                4);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.True);
        }
        [Test]
        public void CollidingBodies_CollidingOnSummedRadius()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                6);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                4);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.True);
        }

        [Test]
        public void CollisionOnSameCenter()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                5);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                4);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            
            Assert.That(isColliding, Is.True);

        }

        [Test]
        public void CollisionHasZeroRadius()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                5);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                0);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.False);
        }

        [Test]
        public void CollisionBothHasZeroRadius()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                0);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                0);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            
            Assert.That(isColliding, Is.False);
        }

        [Test]
        public void EdgeCase()
        {
            // Arrange
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                5);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 10.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                4);
            var collisionDetector = new CollisionDetector();

            // Act
            bool isColliding = collisionDetector.IsColliding(body1, body2);

            // Assert
            Assert.That(isColliding, Is.False);
        }
    }
}
