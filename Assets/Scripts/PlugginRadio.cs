using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugginRadio : MonoBehaviour
{
    public bool radioPower;
    public AudioSource pin0; 
    public Material materialWhenTrue;
    public Material materialWhenFalse;
    private Renderer objectRenderer;


    void Start()
    {
       radioPower = false;
       pin0.enabled = false;
       objectRenderer = GetComponent<Renderer>();
       objectRenderer.material = materialWhenFalse;
       
    }
      void Update()
    {
        if(radioPower == false){

            objectRenderer.material = materialWhenFalse;
        }
        if(radioPower == true){
            objectRenderer.material = materialWhenTrue;
        }
       
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("H") && radioPower == false)
        {
            radioPower = true;
            pin0.enabled = true;
            objectRenderer.material = materialWhenTrue;
        }
        else if (other.CompareTag("H") &&  radioPower == false)
        {
            radioPower = false;
            pin0.enabled = false;
            objectRenderer.material = materialWhenFalse;
        }
  
    }
}
