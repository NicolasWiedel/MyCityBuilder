using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
    private int cellSize;

    Cell[,] grid;

    private int width, length;

    public GridStructure(int cellsize, int width, int length)
    {
        this.cellSize = cellsize;
        this.width = width;
        this.length = length;

        grid = new Cell[this.width, this.length];

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = new Cell();
            }
        }
    }

    /// <summary>
    /// method, to calculate the position in the Grid
    /// </summary>
    /// <param name="inputPosition"></param>
    /// <returns>the coordinates of the (0, 0)-position of the cell</returns>
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    /// <summary>
    /// Calculates the cell position in the Grid
    /// </summary>
    /// <param name="gridPosition"></param>
    /// <returns> the cell </returns>
    public Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / cellSize), (int)(gridPosition.z / cellSize));
    }

    /// <summary>
    /// to verify, if the a given cell index ist taken by a structure
    /// </summary>
    /// <param name="cellIndex"></param>
    /// <returns> if a cell is taken </returns>
    public bool IsCellTaken(Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);

        if (CheckIndexValidity(cellIndex))
        {

            Debug.Log(grid[cellIndex.y, cellIndex.x].IsTaken);
            return grid[cellIndex.y, cellIndex.x].IsTaken;
        }
        else
        {
            throw new IndexOutOfRangeException("No valid index " + cellIndex + "in grid!");
        }
    }

    public void PlaceStructureOnTheGrid(GameObject structure, Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);

        if (CheckIndexValidity(cellIndex))
        {
            grid[cellIndex.y, cellIndex.x].SetConstruction(structure);
        }
        else
        {
            throw new IndexOutOfRangeException("No valid index " + cellIndex + "in grid!");
        }
    }

    public bool CheckIndexValidity(Vector2Int cellIndex)
    {
        if (cellIndex.x >= 0 && cellIndex.x < grid.GetLength(1) &&
            cellIndex.y >= 0 && cellIndex.y < grid.GetLength(0))
        {
            return true;
        }
        else
        {
            return true;
        }
    }
}
