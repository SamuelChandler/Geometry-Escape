using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Camera_Controller: MonoBehaviour
{

    public static Camera_Controller instance;
    public CinemachineVirtualCamera vcam;

    private void Start()
    {
        instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        
    }

}
