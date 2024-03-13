using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float speed;

    private Rigidbody rb;
    public GameObject cameraTarget;
    public GameObject _aimCursor;
    public GameObject pfRail;

    public GameObject currentRail_Created;
    public GameObject currentRail_Riding;

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
            currentRail_Created = Instantiate(pfRail);
            _railBeingCreated=true;
        }

        if(Input.GetMouseButtonUp(0) && _railBeingCreated) {
            _railBeingCreated = false;
            Destroy(currentRail_Riding);
            currentRail_Riding = currentRail_Created;
            currentRail_Created = null;
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
