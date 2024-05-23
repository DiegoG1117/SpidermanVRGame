using UnityEngine;

public class Radio : MonoBehaviour
{

    public AudioSource pin0; 
    public AudioSource pin1; 
    public AudioSource pin2; 
    public AudioSource pin3; 
    public AudioSource pin4; 
    public PlugginRadio Pr;

    void Start()
    {
        pin1.enabled = false;
        pin2.enabled = false;
        pin3.enabled = false;
        pin4.enabled = false;
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene una etiqueta específica
        if (other.CompareTag("Pin1") && Pr.radioPower == true)
        {
            pin1.enabled = true;
            pin0.enabled = false;
        }
        if (other.CompareTag("Pin2")&& Pr.radioPower == true)
        {
            pin2.enabled = true;
            pin0.enabled = false;
        }
        if (other.CompareTag("Pin3")&& Pr.radioPower == true)
        {
            pin3.enabled = true;
            pin0.enabled = false;
        }
        if (other.CompareTag("Pin4")&& Pr.radioPower == true)
        {
            pin4.enabled = true;
            pin0.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del trigger es uno de los pines
        if (other.CompareTag("Pin1")&& Pr.radioPower == true)
        {
            pin1.enabled = false;
            pin0.enabled = true;
        }
        if (other.CompareTag("Pin2")&& Pr.radioPower == true)
        {
            pin2.enabled = false;
            pin0.enabled = true;
        }
        if (other.CompareTag("Pin3")&& Pr.radioPower == true)
        {
            pin3.enabled = false;
            pin0.enabled = true;
        }
        if (other.CompareTag("Pin4")&& Pr.radioPower == true)
        {
            pin4.enabled = false;
            pin0.enabled = true;
        }
    }
}
