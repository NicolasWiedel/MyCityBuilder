using System;
using System.Collections;
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

        #region GrisPositionTest
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
        #endregion

        #region GridCellTest

        [Test]
        public void PlaceStructure303AndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMINAndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(0, 0, 0);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMAXAndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(297, 0, 297);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
        {

            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = null;
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsFalse(structure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructureAndCheckIsTakenIndexOutOfBoundsFail()
        {

            Vector3 position = new Vector3(303, 0, 303);
            //Act
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => structure.IsCellTaken(position));
        }

        #endregion
    }
}
