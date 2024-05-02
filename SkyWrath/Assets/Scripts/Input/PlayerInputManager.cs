using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public MousePressEvent OnMousePress;

    private Vector3 _position;

    

    public void MousePress(InputAction.CallbackContext context)
    {
        if (Camera.main != null)
        {
            _position = Camera.main.WorldToScreenPoint(Input.mousePosition);
        }
        
        OnMousePress.Invoke(_position);
    }

    
}
