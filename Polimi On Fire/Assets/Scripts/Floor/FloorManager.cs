using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class FloorManager : MonoBehaviour
{
    public GameObject[] FloorPrefabs;

    private Transform playerTransform;
    private float spawnX = 0f;
    private float spawnY = 0f;
    private float spawnZ = 0.0f;
    private float floorLength = 10.0f;
    private int amountFloorOnScreen = 50;
    private float safeZone = 200.0f;
    private int lastPrefabIndex = 0;
    public int flagForward;
    public int flagLeft;
    public int flagRight;
    public float turnCounter;
    //List of objects
    private List<GameObject> activeFloor;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        flagForward = 1;
        flagLeft = 0;
        flagRight = 0;

        turnCounter = 0;
        
        activeFloor = new List<GameObject>();
        for (int i = 0; i < amountFloorOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnFloor(0);
            }
            else
            {
                if (i == 5)
                    turnCounter = 6;
                SpawnFloor();   
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        turnCounter += Time.deltaTime;
        if ((flagForward == 1) && (playerTransform.position.z > (spawnZ - safeZone)))
        {
            SpawnFloor();
            DeleteFloor();
        }

        if ((flagLeft == 1) && (-playerTransform.position.x > (-spawnX - safeZone)))
        {
            SpawnFloor();
            DeleteFloor();
        }

        if ((flagRight == 1) && (playerTransform.position.x > (spawnX - safeZone)))
        {
            SpawnFloor();
            DeleteFloor(); 
        }
    }

    private void SpawnFloor(int prefabIndex = -1)
    {
        GameObject floor;
        if (prefabIndex == -1)
        {
            floor = Instantiate(FloorPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            floor = Instantiate(FloorPrefabs[prefabIndex]) as GameObject;
        }

        if (flagLeft == 1)
        {
            floor.transform.SetParent(transform);
            if (lastPrefabIndex != 3){
                floor.transform.Rotate(0f, -90f, 0f);
            } 
            floor.transform.position = new Vector3(spawnX, spawnY, spawnZ);
            spawnX -=floorLength;
            activeFloor.Add(floor);
            return;
        }
        if (flagRight == 1)
        { 
            floor.transform.SetParent(transform);
            if (lastPrefabIndex != 4){
                floor.transform.Rotate(0f, 90f, 0f);
            } 
            floor.transform.position = new Vector3(spawnX, spawnY, spawnZ);
            spawnX +=floorLength;
            activeFloor.Add(floor);
            return;
        }
        if (flagForward == 1)
        {
            floor.transform.SetParent(transform);
            floor.transform.position = new Vector3(spawnX, spawnY, spawnZ);
            spawnZ += floorLength;
            activeFloor.Add(floor);
            return;
        }
       
    }

    private void DeleteFloor()
    {
        Destroy(activeFloor[0]);
        activeFloor.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (FloorPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, FloorPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        
        // More probability of turn
        if (turnCounter > 15)
        {
            randomIndex = Random.Range(3, 7);
        }
        
        if ((turnCounter < 5) && ((randomIndex == 3) || (randomIndex == 4) || (randomIndex == 5) || (randomIndex == 6)))
        {
            randomIndex = 0;
        }

        if ((flagLeft == 1) && ((randomIndex == 3) || (randomIndex == 4) || (randomIndex == 6)))
        {
            randomIndex = 7; 
        }
        
        if ((flagRight == 1) && ((randomIndex == 3) || (randomIndex == 4) || (randomIndex == 5)))
        {
            randomIndex = 6;
        }
        
        if ((flagForward == 1) && ((randomIndex == 5) || (randomIndex == 6)))
        {
            randomIndex = 0;
        }
        
        if ((randomIndex == 3) && (turnCounter > 5))
        {
            flagForward = 0;
            flagLeft = 1;
            flagRight = 0;
            turnCounter = 0;
        }
        if ((randomIndex == 4) && (turnCounter > 5))
        {
            flagForward = 0;
            flagLeft = 0;
            flagRight = 1;
            turnCounter = 0;
        }
        if ((randomIndex == 5) && (turnCounter > 5))
        {
            flagForward = 1;
            flagLeft = 0;
            flagRight = 0;
            turnCounter = 0;
        }
        if ((randomIndex == 6) && (turnCounter > 5))
        {
            flagForward = 1;
            flagLeft = 0;
            flagRight = 0;
            turnCounter = 0;
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
