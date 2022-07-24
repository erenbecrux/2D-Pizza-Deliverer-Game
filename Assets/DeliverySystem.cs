using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool hasPizza = false;
    [SerializeField] float delayTime;
    [SerializeField] Color hasPizzaColor = new Color (1,1,1,1);
    [SerializeField] Color noPizzaColor = new Color (1,1,1,1);


    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPizzaColor;
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Dude I hit something!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Am I a ghost?!");
        if (other.tag == "Pizza" && hasPizza == false)
        {
            Debug.Log("Pizza is picked up!");
            hasPizza = true;
            Destroy(other.gameObject,delayTime);
            spriteRenderer.color = hasPizzaColor;


        }

        if (other.tag == "Customer" && hasPizza == true)
        {
            Debug.Log("Pizza is delivered!");
            hasPizza = false;
            spriteRenderer.color = noPizzaColor;

        }
    }
}
