using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

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
        }
    }

    public void FixedUpdate()
    {
        //on Left Click hold
        if(grow) {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * _increaseRate, transform.localScale.z);
            UpdateAngle();
        }



        
    }

    private void UpdateAngle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        transform.up = direction;
    }
}
