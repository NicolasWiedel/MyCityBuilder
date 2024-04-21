using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask;

    //public GameObject buildingPrefab;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    /// <summary>
    /// Getting Mouse input on the ground
    /// </summary>
    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
            }
        }  
    }

    
    ///// <summary>
    ///// method for placing Buildings
    ///// </summary>
    ///// <param name="gridPosition"></param>
    //public void CreatBuilding(Vector3 gridPosition)
    //{
    //    Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
    //}
}
