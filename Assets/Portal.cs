using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private Transform destination;

    public bool isEnemy;
    public float distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (isEnemy == true){
            destination = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        }
        
    }

   void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.tag == "Enemy"){
            Debug.Log("Start Over");
            other.transform.position = new Vector2(destination.position.x, destination.position.y); 
    }
   }
}
