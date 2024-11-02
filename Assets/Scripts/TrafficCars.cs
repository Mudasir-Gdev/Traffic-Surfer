using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficCars : MonoBehaviour
{
    public float Speed=20f;

    
    void Update()
    {
        transform.Translate(Vector3.forward * Speed*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CarController>())
        {
            GameManager.Singleton.GameOver();
            
        }
    }
}
