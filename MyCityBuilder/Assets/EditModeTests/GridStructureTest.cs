﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridStructureTest
    {
        private GridStructure structure;

        [OneTimeSetUp]
        public void init()
        {
            structure = new GridStructure(3, 100, 100);
        }

        [Test]
        public void CalculateGridPositionPasses()
        {
            // Arange
            Vector3 position = new Vector3(0, 0, 0);
            // Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            // Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatPasses()
        {
            // Arange
            Vector3 position = new Vector3(2.9f, 0, 2.9f);
            // Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            // Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFail()
        {
            // Arange
            Vector3 position = new Vector3(3.1f, 0, 0);
            // Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            // Assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
    }
}
