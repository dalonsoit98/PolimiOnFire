using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public GameObject fire;
    private Transform playerTransform;
    private float radius = 0f;
    private int numberOfFire = 1;
    private int numberOfFireRandom = 0;
    private float countFire;
    
    private float spawnX = 33.25f;
    private float spawnY = 0f;
    private float spawnZ = -78.25f;

    private float planeX = 260f;
    private float planeY = 0f;
    private float planeZ = 216f;

    //List of objects
    private List<GameObject> activeFireCircle;
    private List<GameObject> activeFireRandom;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        countFire = 0.0f;
        activeFireCircle = new List<GameObject>();
        activeFireRandom = new List<GameObject>();
        SpawnFireCircle();
        SpawnFireAtRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMoveBuilding>().isDead)
        {
            return;
        }

        if (numberOfFire > 80)
        {
            DeleteFireCircle();
            numberOfFire = 1;
            //radius = 0;
            SpawnFireCircle();
        }

        if (radius > planeZ)
        {
            DeleteFireCircle();
            numberOfFire = 1;
            radius = 0;
            SpawnFireCircle();
        }
        if (countFire > 3.0f)
        {
            DeleteFireCircle();
            SpawnFireCircle();
            SpawnFireAtRandom();
            countFire = 0;
            if (numberOfFireRandom > 35)
            {
                DeleteFireRandom();
            }
        }
        else
        {
            countFire += Time.deltaTime;
        }
    }

    private void DeleteFireCircle()
    {
        for (int i = 0; i < numberOfFire-2; i++)
        {
                Destroy(activeFireCircle[0]);
                activeFireCircle.RemoveAt(0);
        }
    }
    
    private void SpawnFireCircle()
    {
        GameObject fireObject;
        Vector3 targetPosition = Vector3.zero;
        for (int i = 0; i < numberOfFire; i++)
        {
            fireObject  = Instantiate(fire);

            float angle = i * (2 * Mathf.PI / numberOfFire);

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            
            targetPosition = new Vector3( spawnX + x, spawnY + 0, spawnZ + z);
            fireObject.transform.position = targetPosition;
            
            activeFireCircle.Add(fireObject);
        }
        radius += 1.4f;
        numberOfFire += 2;
    }

    void SpawnFireAtRandom()
    {
        GameObject fireObject;
        Vector3 randomPos = new Vector3(Random.Range(-planeX / 2, planeX / 2), Random.Range(-planeY / 2, planeY / 2),
            Random.Range(-planeZ / 2, planeZ / 2));
        if ((playerTransform.position.x == randomPos.x) && (playerTransform.position.z == randomPos.z))
        {
            return;
        }
        fireObject  = Instantiate(fire);
        fireObject.transform.position = randomPos;
        activeFireRandom.Add(fireObject);
        numberOfFireRandom += 1;
    }
    private void DeleteFireRandom()
    {
        Destroy(activeFireRandom[0]);
            activeFireRandom.RemoveAt(0);
    }
}
