using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UIElements;

public class Rail : MonoBehaviour
{
    [SerializeField] public float _increaseRate;
    [SerializeField] public GameObject _beginning;
    [SerializeField] public GameObject _ending;

    private Vector3 NextSize;
    private bool grow;

    private void Awake()
    {
        NextSize = transform.localScale;
        grow = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            grow = false;
            Game_Manager.instance.endpoint = _ending.transform.position;
        }
    }

    public void FixedUpdate()
    {
        //on Left Click hold
        if(grow) {          
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + _increaseRate, transform.localScale.z);
            UpdateAngle();
            UpdatePosition();
            
            
            
        }

    }

    private void UpdateAngle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _beginning.transform.position;
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        transform.up = direction;
    }

    private void UpdatePosition()
    {
        Vector2 PlayerPos = Game_Manager.instance.PlayerPos;
        Vector2 DeltaPos = PlayerPos - (Vector2)_beginning.transform.position;
        transform.position = transform.position + (Vector3)DeltaPos;
       

    }

    private bool isTouchingMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return GetComponent<Collider2D>().OverlapPoint(mousePosition);

    }

    
}
