using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLeft : MonoBehaviour
{
    public GameObject[] WallLeftPrefabs;
    
    private Transform playerTransform;
    private float spawnX = -4f;
    private float spawnY = 0f;
    private float spawnZ = 0f;
    private float wallLeftLength = 10.0f;
    private int amountWallLeftOnScreen = 7;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountWallLeftOnScreen; i++)
        {
            SpawnWallLeft();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amountWallLeftOnScreen * wallLeftLength))
        {
            SpawnWallLeft();
        }
    }
    private void SpawnWallLeft (int prefabIndex = -1)
    {
        GameObject wallLeft;
        wallLeft = Instantiate(WallLeftPrefabs [0]) as GameObject;
        wallLeft.transform.SetParent (transform);
        gameObject.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        spawnZ += wallLeftLength;
        
    }
}
