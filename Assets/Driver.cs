using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotationSpeed = -250;
    [SerializeField] float translationSpeed = 15;
    [SerializeField] float startSpeed = 15;
    [SerializeField] float boostSpeed = 25;
    [SerializeField] float slowSpeed = 10;
    [SerializeField] float boostTimer = 10;
    float totalTime = 0;
    bool runningTimer = false;


    void Update()
    {
        float rotationValue = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float translationValue = Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime;

        transform.Rotate(0,0,rotationValue);
        transform.Translate(0,translationValue,0);
        
        if (runningTimer==true)
        {
            totalTime += Time.deltaTime;
        }
        if (totalTime >= boostTimer)
        {
            translationSpeed = startSpeed;
            totalTime = 0;
            runningTimer= false;

        }

        
    }

    void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Booster")
            {
                translationSpeed = boostSpeed;
                totalTime =0;
                runningTimer = true;

            }
            
        }

    void OnCollisionEnter2D(Collision2D other) 
        {  
            translationSpeed = slowSpeed;
            totalTime =0;
            runningTimer = true; 
        }
    
}
