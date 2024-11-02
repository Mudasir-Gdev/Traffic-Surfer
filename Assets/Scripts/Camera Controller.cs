using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Car;
    public Vector3 Offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CarLoc = Car.transform.position;
        CarLoc += Offset;
        transform.position = new Vector3(CarLoc.x, CarLoc.y, CarLoc.z);
    }
}
