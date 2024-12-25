using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangingRoom : MonoBehaviour
{
    private bool isColliding = false;


    public Camera mainCam;
    public GameObject target; // Kameranın hareket edeceği hedef obje
    public float duration = 3.0f; // Hareketin tamamlanma süresi

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float elapsedTime = 0f;

    // void Start()
    // {
    //     initialPosition = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    //     //targetPosition = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);
    // }

    
    
    


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            isColliding = true;
            elapsedTime = 0f;
            target = collision.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if (isColliding)
        {
            GameObject child = target.transform.GetChild(0).gameObject;
            
            // initialPosition = new Vector3(target.transform.position.x,target.transform.position.y - 10,target.transform.position.z);

            initialPosition = new Vector3(mainCam.transform.position.x,mainCam.transform.position.y,mainCam.transform.position.z);
            
            targetPosition = new Vector3(child.transform.position.x, child.transform.position.y, -10);
            if (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                float smoothStep = t * t * (3f - 2f * t); // Easing fonksiyonu (SmoothStep)

                mainCam.transform.position = Vector3.Lerp(initialPosition, targetPosition, smoothStep);

                target.GetComponent<Collider2D>().enabled = false;

                if (elapsedTime > 2.5)
                {
                    isColliding = false;
                }
            }
            // elapsedTime = 0;
        }
    }

    
}
