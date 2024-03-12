using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller: MonoBehaviour
{

    public GameObject Camera_Target;

    private void Update()
    {
        transform.position = Camera_Target.transform.position;
    }

}
