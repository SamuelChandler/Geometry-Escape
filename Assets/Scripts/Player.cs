using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float speed;

    Rigidbody2D rb;
    public GameObject cameraTarget;
    public GameObject _aimCursor;
    public GameObject pfRail;

    public GameObject currentRail_Created;
    public GameObject currentRail_Riding;

    private bool _railBeingCreated;
    private bool _traveling;

    private Vector2 dest;


    private void Awake()
    {
        _railBeingCreated = false;
        _traveling = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //update position and angle
        UpdateAngle();
        Game_Manager.instance.PlayerPos = this.transform.position;

        if(Input.GetMouseButtonDown(0) && !_railBeingCreated) {
            currentRail_Created = Instantiate(pfRail);
            _railBeingCreated=true;
        }

        if(Input.GetMouseButtonUp(0) && _railBeingCreated) {
            _railBeingCreated = false;
            Destroy(currentRail_Riding);
            currentRail_Riding = currentRail_Created;
            currentRail_Created = null;
            _traveling=true;
            dest = Game_Manager.instance.endpoint;
        }

        if (_traveling)
        {
            transform.position = Vector3.MoveTowards(transform.position, Game_Manager.instance.endpoint, speed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        

    }

    private void UpdateAngle() { 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        transform.up = direction;
    }


    private void OnDestroy()
    {
        Destroy(currentRail_Created);
        Destroy(currentRail_Riding);
    }
}
