using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour 
{

    public GameObject startingPoint;
    public GameObject anchorPoint;
    public int worldWidth = 10;
    public int worldHeight = 10;
    float spawnSpeed = 0;
    public float blockWidth = 2.5f;
    Vector3 startingPosition;

    void Start()
    {
        StartCoroutine(CreateWorld());
        if (startingPoint == null)
        {
            Debug.Log("Warning: No starting point is set.");
        }
        else
        {
            startingPosition = startingPoint.transform.position;
        }
    }

    IEnumerator CreateWorld()
    {

        for (int x = 0; x < worldWidth; x += 1)
        {
            yield return new WaitForSeconds(spawnSpeed);
            for (int z = 0; z < worldHeight; z += 1)
            {
                yield return new WaitForSeconds(spawnSpeed);

                GameObject block = Instantiate(anchorPoint, anchorPoint.transform.position, anchorPoint.transform.rotation) as GameObject;
                anchorPoint.transform.position = new Vector3(startingPosition.x + (x * blockWidth), startingPosition.y, startingPosition.z + (z * blockWidth));

            }

        }

    }
}

