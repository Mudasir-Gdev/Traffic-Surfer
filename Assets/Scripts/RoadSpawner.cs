using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadprefab;
    
    public Vector3 CheckOffset;
    private Vector3 SpawnPos;
    public bool roadinstantiate=false;
    public List<GameObject> roads = new List<GameObject>();
   


    private void Start()
    {
               SpawnPos = roadprefab.transform.position+CheckOffset;
    }
    private void Update()
    {
        if (roadinstantiate)
        {
            Spawnroad();
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>() != null)
        {
            roadinstantiate = true;
        }
    }
    void Spawnroad()
    {

        Debug.Log(roadprefab.transform.position.z);
        GameObject newRoad = Instantiate(roadprefab, SpawnPos , roadprefab.transform.rotation);
        
        roads.Add(newRoad);
        if (roads.Count > 3)
        {
            GameObject roadToDestroy = roads[0];
            
            roads.RemoveAt(0);
            Destroy(roadToDestroy);
        }
        SpawnPos = newRoad.transform.position+ CheckOffset;
        transform.Translate(CheckOffset);
        roadinstantiate=false;
    }
}
