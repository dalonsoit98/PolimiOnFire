using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] FloorPrefabs;

    private Transform playerTransform;
    private float spawnX = 0f;
    private float spawnY = 0f;
    private float spawnZ = 0f;
    private float floorLength = 10.0f;
    private int amountFloorOnScreen = 7;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountFloorOnScreen; i++)
        {
            SpawnFloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amountFloorOnScreen * floorLength))
        {
            SpawnFloor();
        }
    }

    private void SpawnFloor (int prefabIndex = -1)
    {
        GameObject floor;
        floor = Instantiate(FloorPrefabs[0]) as GameObject;
        floor.transform.SetParent(transform);
        gameObject.transform.position = new Vector3 (spawnX, spawnY, spawnZ);
        spawnZ += floorLength;
    }
}
