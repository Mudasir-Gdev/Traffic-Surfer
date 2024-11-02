using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyButtons : MonoBehaviour
{
    public bool isPressed;
    
    
    private void Start()
    {
      SetUpbutton();
    }
    void SetUpbutton()
    {
        EventTrigger trigger =gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => OnClickDown());

        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => OnClickUp());

        trigger.triggers.Add(pointerDown);  
        trigger.triggers.Add(pointerUp);
    }
    void OnClickDown()
    {
        isPressed = true;
    }
     public void OnClickUp()
    {
        isPressed = false;
    }
}
