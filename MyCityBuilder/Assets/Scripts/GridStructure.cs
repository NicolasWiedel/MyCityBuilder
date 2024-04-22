using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
    private int cellSize;

    public GridStructure(int cellsize)
    {
        this.cellSize = cellsize;
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
}
