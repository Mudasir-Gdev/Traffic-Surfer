using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    public GameObject car;
   
    public GameObject[] TrfcCars=new GameObject[4];
    //private int cars;
    //private Vector3 InstantiatePos;
    private bool SpawnCars;
    public List<GameObject> carsList = new List<GameObject>();
    private int offsetZ;
    private int RandomDelay=0;
   
    
    
    void Start()
    {
      
        RandomDelay = Random.Range(1,4);
        if(!GameManager.Singleton.gameover)
        InvokeRepeating("SpawnTrafficCar", 2, RandomDelay);
    }
    void SpawnTrafficCar()
    {
        offsetZ =  Random.Range(70, 100);         //Random Z distance
        int RandomCars =Random.Range(0, 3);
        int offsetX = Random.Range(-7, 7);

        if (SpawnCars)
        {
            GameObject SpawnedCars = Instantiate(TrfcCars[RandomCars], new Vector3(offsetX, -0.1f, car.transform.position.z + offsetZ), Quaternion.identity);
            carsList.Add(SpawnedCars);

        }


        if (carsList.Count < 5)
        {
            SpawnCars = true;
        }
        else
        {
            SpawnCars = false;
        }
        
       
       
        
    }
}
