using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject buildingPrefab;

    public Transform ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// method for placing Buildings
    /// </summary>
    /// <param name="gridPosition"></param>
    public void CreatBuilding(Vector3 gridPosition)
    {
        Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
    }
}
