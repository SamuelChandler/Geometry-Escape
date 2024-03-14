using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Spawner : MonoBehaviour
{

    [SerializeField] private GameObject BaseEnemyLR, BaseEnemyTB;

    [SerializeField] private float spawnTimer = 3.5f;
    [SerializeField] private float DifTimer = 10f;

    [SerializeField] private int DifCounter;

    [SerializeField] private float left, right, top, bottom;

    [SerializeField] private float BaseSpeed;

    private Vector3[] spawnPoints = new Vector3[4];

    

    Vector2 spawnPos = Vector2.zero;
    void Start()
    {
        DifCounter = 0;
        setSpawnPoints();
        SpawnEnemyBase_RandLocation();
        StartCoroutine(spawnerBase());
        StartCoroutine(IncreaseDifficulty());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator IncreaseDifficulty()
    {
        yield return new WaitForSeconds(DifTimer);
        spawnTimer -= 0.1f;
        BaseSpeed += 0.1f;
        DifCounter += 1;
        StartCoroutine(IncreaseDifficulty());
    }

    private IEnumerator spawnerBase()
    {
        yield return new WaitForSeconds(spawnTimer);
        SpawnEnemyBase_RandLocation();
        StartCoroutine(spawnerBase());
    }

    private void SpawnEnemyBase_RandLocation()
    {
        Position spawn;
        if (DifCounter < 3) {spawn = (Position)Random.Range(0, 2); }
        else{ spawn = (Position)Random.Range(0, 4); }
        

        GameObject Created;

        switch (spawn){
            case Position.Left:
                Created = Instantiate(BaseEnemyLR, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[0], new Quaternion());
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(1*BaseSpeed, 0 * BaseSpeed));
                break;
            case Position.Right:
                Created = Instantiate(BaseEnemyLR, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[1], new Quaternion());
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * BaseSpeed, 0 * BaseSpeed));
                break;
            case Position.Top:
                Created = Instantiate(BaseEnemyTB, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[2], new Quaternion());
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(0 * BaseSpeed, -1 * BaseSpeed));
                break;
            case Position.Bottom:
                Created = Instantiate(BaseEnemyTB, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[3], new Quaternion());
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(0 * BaseSpeed, 1 * BaseSpeed));
                break;
            default:
                break;
        }

        //add points for a spawned enemy 
        Game_Manager.instance.PointChange(3);
    }


    private void setSpawnPoints()
    {
        spawnPoints[0] = new Vector3(left,0f,0f);
        spawnPoints[1] = new Vector3(right, 0f, 0f);
        spawnPoints[2] = new Vector3(0f, top, 0f);
        spawnPoints[3] = new Vector3(0f, bottom, 0f);
    }

    enum Position
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
