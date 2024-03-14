using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    [SerializeField] private GameObject BaseEnemy;

    [SerializeField] private float spawnTimer = 3.5f;
    [SerializeField] private float DifTimer = 10f;

    [SerializeField] private float left, right, top, bottom;

    [SerializeField] private float BaseSpeed;

    private Vector3[] spawnPoints = new Vector3[4];

    

    Vector2 spawnPos = Vector2.zero;
    void Start()
    {
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
        Position spawn = (Position)Random.Range(0, spawnPoints.Length);

        GameObject Created;

        switch (spawn){
            case Position.Left:
                Created = Instantiate(BaseEnemy, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[0], new Quaternion(0,0,0,0));
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(1*BaseSpeed, 0 * BaseSpeed));
                break;
            case Position.Right:
                Created = Instantiate(BaseEnemy, (Vector3)Game_Manager.instance.PlayerPos + spawnPoints[1], new Quaternion(-1, 0, 0, 0));
                Created.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * BaseSpeed, 0 * BaseSpeed));
                break;
            default:
                break;

        }

        
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
