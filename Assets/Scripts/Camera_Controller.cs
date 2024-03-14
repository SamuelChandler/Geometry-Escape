using Cinemachine;
using UnityEngine;


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
