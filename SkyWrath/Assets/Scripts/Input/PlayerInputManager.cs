using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{    
    public static PlayerInputManager Instance;
    
    public MousePressEvent OnMousePress;

    private Vector3 _position;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MousePress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Hello1");

            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                    OnMousePress?.Invoke(hit.transform.position);
            }

            
        }
    }

    
}
