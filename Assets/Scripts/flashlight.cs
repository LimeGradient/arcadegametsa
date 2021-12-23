using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehavior
{
    public GameObject light;
    public int lightOn;
    void start()
    {
  
    }
    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
       {
          if (lightOn = 0)
          {
             light.SetActive(true);
             lightOn += 1;
          }
          if (lightOn = 1)
          {
              light.SetActive(false);
              lightOn -= 1;
          }
       }
    }
  
}
