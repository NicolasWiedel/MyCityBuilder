using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // delegate
    private Action<Vector3> OnPointerDownHandler;
    public LayerMask mouseInputMask;

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

                // if ther are any subscribers of the delegate
                // they will be informed
                OnPointerDownHandler?.Invoke(position);
            }
        }  
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler += listener;
    }

    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler -= listener;
    }
}
