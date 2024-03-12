using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject cameraTarget;
    public GameObject _aimCursor;
    public GameObject pfRail;

    private bool _railBeingCreated;


    private void Awake()
    {
        _railBeingCreated = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        UpdateAngle();

        if(Input.GetMouseButtonDown(0) && !_railBeingCreated) {
            Instantiate(pfRail);
            _railBeingCreated=true;
        }
        
    }

    private void FixedUpdate()
    {
        

    }

    private void UpdateAngle() { 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        transform.up = direction;
    }
}
