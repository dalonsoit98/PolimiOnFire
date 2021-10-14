using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRight : MonoBehaviour
{
    public GameObject[] WallRightPrefabs;
    
    private Transform playerTransform;
    private float spawnX = 4f;
    private float spawnY = 0f;
    private float spawnZ = 0f;
    private float wallRightLength = 10.0f;
    private int amountWallRightOnScreen = 7;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountWallRightOnScreen; i++)
        {
            SpawnWallRight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amountWallRightOnScreen * wallRightLength))
        {
            SpawnWallRight();
        } 
    }
    private void SpawnWallRight (int prefabIndex = -1)
    {
        GameObject wallRight;
        wallRight = Instantiate(WallRightPrefabs [0]) as GameObject;
        wallRight.transform.SetParent(transform);
        gameObject.transform.position = new Vector3( spawnX, spawnY, spawnZ);
        spawnZ += wallRightLength;
    }
}
