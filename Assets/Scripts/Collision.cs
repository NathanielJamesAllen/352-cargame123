using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color hasPackageColor = Color.red;
    [SerializeField] Color noPackageColor = Color.white;
    
    SpriteRenderer spriteRenderer;
    bool hasPackage = false;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("OUCH!!!");
     }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Package" && !hasPackage){
            Debug.Log("Picked Up A Package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.1f);
        }
        else if(other.gameObject.tag == "Delivery" && hasPackage) {
            Debug.Log("Delivered Package");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
     }
     
}
