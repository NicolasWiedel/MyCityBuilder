using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
    // delegate
    private Action<Vector3> OnPointerSecondDownHandler;
    private Action OnPointerSecondUpHandler;
    private Action<Vector3> OnPointerDownHandler;
    public LayerMask mouseInputMask;

    // Update is called once per frame
    void Update()
    {
        GetPointerPosition();
        GetPanningPointer();
    }

    /// <summary>
    /// Getting Mouse input on the ground
    /// </summary>
    public void GetPointerPosition()
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

    public void GetPanningPointer()
    {
        if (Input.GetMouseButton(1))
        {
            var position = Input.mousePosition;
            OnPointerSecondDownHandler?.Invoke(position);
        }
        if (Input.GetMouseButtonUp(1))
        {
            OnPointerSecondUpHandler?.Invoke();
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

    public void AddListenerOnPointerSecondDownEvent(Action<Vector3> listener)
    {
        OnPointerSecondDownHandler += listener;
    }

    public void RemoveListenerOnPointerSecondDownEvent(Action<Vector3> listener)
    {
        OnPointerSecondDownHandler -= listener;
    }

    public void AddListenerOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler += listener;
    }

    public void RemoveListenerOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler -= listener;
    }
}
