
using System;


using UnityEngine;

public class CarController : MonoBehaviour
{
    public struct Car
    {
        public float Acceleration;
        public float Deaccelearation;
        public float slowdown;
        public float MinSpeed;
        public float MaxSpeed;
        public float CurrentSpeed;
    }
    public double speedui;
    
    private Rigidbody rb;
    private float deltaX  ;
    private float gyroSpeed = 20f;
    
    public int CarsStartPos;
    public int CarsEndPos;
    
    Car car = new Car();
    public MyButtons gasPedal;
    public MyButtons Brakepedal;
    
    void Start()
    {
        CarsStartPos = Convert.ToInt32(transform.position.z);

        car.MinSpeed = 10;
        car.MaxSpeed = 45;
        car.Acceleration = 3.4f;
        car.slowdown = 1f;
        car.Deaccelearation = 8f;
        car.CurrentSpeed = car.MinSpeed;
        rb = GetComponent<Rigidbody>();
    }  
    void Update()
    {
        CarsEndPos = Convert.ToInt32(transform.position.z);
         int distance = CarsEndPos - CarsStartPos;
        GameManager.Singleton.Distance(distance);

        deltaX = Input.acceleration.x * gyroSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
        if (gasPedal.isPressed)
        {
            CarAcceleration();

        }
         if(Brakepedal.isPressed)
        {
            CarDeacceleration();
        }
         if(!gasPedal.isPressed && !Brakepedal.isPressed)
        {
            SlowDown();
        }


        car.CurrentSpeed = Mathf.Clamp(car.CurrentSpeed, car.MinSpeed, car.MaxSpeed);
        Speed(car.CurrentSpeed);
        speedui = rb.velocity.magnitude * 3.6;
        GameManager.Singleton.UpdateSpeed(Convert.ToInt32(speedui));
    }
    public void CarAcceleration()
    {
        car.CurrentSpeed += car.Acceleration*Time.deltaTime;
        
        


    }
    public void CarDeacceleration()
    {
        car.CurrentSpeed -= car.Deaccelearation*Time.deltaTime;
        
        

    }
    public void SlowDown()
    {
        car.CurrentSpeed -=car.slowdown*Time.deltaTime;
    }
    public void Speed(float curspeed)
    {
        if (!GameManager.Singleton.gameover)
        {


            rb.velocity = new Vector3(deltaX, 0, curspeed);
            Debug.Log("Velocity = " + rb.velocity.magnitude * 3.6);
            
        }
        else
        {
            rb.velocity = Vector3.zero; 
        }
    }
    
        
    
}
