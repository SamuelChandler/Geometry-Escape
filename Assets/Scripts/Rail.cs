using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] public int _increaseRate;
    [SerializeField] public int _rateOfIncease;

    private Vector3 NextSize;

    private void Awake()
    {
        NextSize = transform.localScale;
    }

    public void Update()
    {
        //on Left Click
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * _increaseRate, transform.localScale.z);
        }
    }
}
