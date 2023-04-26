using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 60f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float slowSpeed = 5f;

    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {  
        currentSpeed = moveSpeed;  
      
    }
     
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Boost"){
          moveSpeed = boostSpeed;
        }
        else if(other.tag == "Slower"){
            moveSpeed = slowSpeed;
        }

    }
     void OnTriggerExit2D(Collider2D other) {
         moveSpeed = 20;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount * steerSpeed);
        transform.Translate(0,moveSpeed * moveAmount,0);
    }
}
