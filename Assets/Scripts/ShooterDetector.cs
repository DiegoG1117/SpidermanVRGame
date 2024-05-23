using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterDetector : MonoBehaviour
{
    public Material materialWhenTrue;
    public Material materialWhenFalse;
    public Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer.material = materialWhenFalse;
    }

    // Update is called once per frame

       void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReloadShooter"))
        {
            objectRenderer.material = materialWhenTrue;
        }
    }
}
