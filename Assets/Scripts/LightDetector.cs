using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetector : MonoBehaviour
{

    public GameObject Switch;
    public bool light = false;
    void Start()
    {
       Switch.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("H") && light == false)
        {
            Switch.SetActive(true);
            light = true;
        }
        else if (other.CompareTag("H") && light == true)
        {
            Switch.SetActive(false);
            light = false;
        }
  
    }

}
