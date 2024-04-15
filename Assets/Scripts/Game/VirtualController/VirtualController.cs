using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualController : MonoBehaviour
{
    public GameObject joystick;

    private void Awake()
    {
        joystick = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
