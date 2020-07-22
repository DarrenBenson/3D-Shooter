﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Laser[] _lasers;

    private void Update()
    {
        
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            foreach (var laser in _lasers)
            {
//                Vector3 targetPosition = _transform.position + (_transform.forward * laser.Distance);
                laser.FireLaser();
            }
        }
    }

}