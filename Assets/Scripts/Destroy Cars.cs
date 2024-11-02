using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyCars : MonoBehaviour
{
    public Transform car;
    public EnemyCarSpawner ECS;

    private void Start()
    {
        // enemyCarSpawner = GetComponent<EnemyCarSpawner>();

    }
    private void FixedUpdate()
    {

        transform.position = new Vector3(0f, 2f, car.position.z - 20f);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TrafficCars>())
        {
            Debug.Log("Collision Called.");

            Destroy(collision.gameObject);
             int index = ECS.carsList.IndexOf(collision.gameObject);
             Destroy(ECS.carsList[index]);
             ECS.carsList.Remove(collision.gameObject);

             ECS.carsList.RemoveAt(index);
             



        }
    }
}
   

