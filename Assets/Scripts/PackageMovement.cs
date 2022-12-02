using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMovement : MonoBehaviour
{
    int counter = 0;
    int direction = 1;
    int maxDistance = 100;
    float moveSpeed = 0.01f;
    void Update()
    {
       // determine direction 
       if(Mathf.Abs(counter) > maxDistance){
        direction = direction * -1;
       }
       // move it
       transform.Translate(0,moveSpeed * direction,0);

       // increment/decrement counter. 
       if(direction > 0){
        counter--;
       }
       else{
        counter++;
       }
    }
}
