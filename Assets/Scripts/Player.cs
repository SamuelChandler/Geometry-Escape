using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float speedUp;
    private bool SUP;

    public float energy;
    public float energyMax = 100;

    Rigidbody2D rb;
    public GameObject cameraTarget;
    public GameObject _aimCursor;
    public GameObject pfRail;

    public GameObject currentRail_Created;
    public GameObject currentRail_Riding;

    private bool _railBeingCreated;
    private bool _traveling;

    private Vector2 dest;
    [SerializeField] private GameObject VC;
    [SerializeField] private CinemachineVirtualCamera vcam;





    private void Awake()
    {
        Game_Manager.instance.player = this;
        _railBeingCreated = false;
        _traveling = false;
        SUP = false;
        energy = energyMax;

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Game_Manager.instance.PlayerDied) { Game_Manager.instance.PlayerDied = false; }

        //update camera
        Camera_Controller.instance.vcam.Follow = transform;
        Camera_Controller.instance.vcam.LookAt = transform;

        //update position and angle
        UpdateAngle();
        Game_Manager.instance.PlayerPos = transform.position;

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

        if (Input.GetMouseButtonDown(1)){SUP = true;}
        if (Input.GetMouseButtonUp(1)){ SUP = false;}
        if(energy <= 0) { SUP = false; }

        if (_traveling)
        {
            if (SUP)
            {
                transform.position = Vector3.MoveTowards(transform.position, Game_Manager.instance.endpoint, speedUp * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Game_Manager.instance.endpoint, speed * Time.deltaTime);
            }
            
        }

    }

    private void FixedUpdate()
    {
        if (_traveling && SUP) { 
            energy -= 0.5f;
            EnergyBar.instance.SetEnergy(energy, energyMax);  
        }else if (energy <= energyMax)
        {
            energy += 0.5f;
            EnergyBar.instance.SetEnergy(energy, energyMax);
        }

    }

    private void UpdateAngle() { 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);
        transform.up = direction;
    }

    public void DestroyMyself()
    {
        Destroy(currentRail_Created);
        Destroy(currentRail_Riding);
        Destroy(gameObject);

    }
}
