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

    public SpriteRenderer spriteRenderer;
    public Sprite YellowBus;
    public Sprite BlueCar;
    public Sprite Racer;
    void ChangeSprite(Sprite newSprite) {
        spriteRenderer.sprite = newSprite; 
    }

    // Start is called before the first frame update
    void Start()
    {  
        currentSpeed = moveSpeed;  
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      
    }
     
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Boost"){
          moveSpeed = boostSpeed;
        }
        else if(other.tag == "Slower"){
            moveSpeed = slowSpeed;
        }
         if(other.gameObject.tag == "Big Boi"){
            gameObject.transform.localScale +=  new Vector3(1,1, 0);
            StartCoroutine(BigBoi(7));
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.tag == "Lil Goy"){
            gameObject.transform.localScale -=  new Vector3(0.2f,0.2f, 0);
            StartCoroutine(LilGoy(7));
            Destroy(other.gameObject, 0.2f);
        } 
        if(other.gameObject.tag == "Bus"){
            ChangeSprite(YellowBus);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector3(2.5f,7, 0);
            StartCoroutine(Bussie(15));
            Destroy(other.gameObject, 0.2f);
        } 
        if(other.gameObject.tag == "Racer"){
            ChangeSprite(Racer);
            StartCoroutine(RacerCar(15));
            Destroy(other.gameObject, 0.2f);
        } 

    }
     void OnTriggerExit2D(Collider2D other) {
         moveSpeed = 20;
        
    }

        IEnumerator LilGoy(float time) {
     yield return new WaitForSeconds(time);
        gameObject.transform.localScale +=  new Vector3(0.2f,0.2f, 0);
    }

    IEnumerator BigBoi(float time) {
     yield return new WaitForSeconds(time);
        gameObject.transform.localScale -=  new Vector3(1,1, 0);
    }

    IEnumerator Bussie(float time) {
     yield return new WaitForSeconds(time);
            ChangeSprite(BlueCar);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector3(1.8f,3.495438f, 0);
    }
    
    IEnumerator RacerCar(float time) {
     yield return new WaitForSeconds(time);
            ChangeSprite(BlueCar);
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
