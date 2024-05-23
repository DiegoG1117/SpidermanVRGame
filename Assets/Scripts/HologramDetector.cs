using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramDetector : MonoBehaviour
{
    public GameObject Hologram;
    public GameObject objectToScale;
    public Material materialWhenTrue;
    public Material materialWhenFalse;
    public Material materialBase;
    public Renderer objectRenderer;
    public bool DetectorON = false;
    public bool IndicatorON = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioSource FirstInstructionAudio;
    public AudioClip FirstInstructioClip;

    private float timer = 0f;
    private float interval = 3f;
    private bool waiting = false;
    private bool isScaling = false;

    void Start()
    {
        Hologram.SetActive(false);
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = materialBase;
        FirstInstructionAudio.Stop();
    }

    void Update()
    {
        if (!IndicatorON && !waiting)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                objectRenderer.material = materialBase;
                timer = 0f;

                audioSource.PlayOneShot(audioClip);
                StartCoroutine(ChangeMaterialDelayed(materialWhenFalse, audioClip.length));
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("H") && !DetectorON)
        {
            objectRenderer.material = materialWhenTrue;
            Hologram.SetActive(true);
            DetectorON = true;
            IndicatorON = true;
            StartCoroutine(PlaySoundAndScaleObject(FirstInstructionAudio, FirstInstructioClip));
        }
        else if (other.CompareTag("H") && DetectorON)
        {
            objectRenderer.material = materialWhenFalse;
            Hologram.SetActive(false);
            DetectorON = false;
            StopCoroutine("PlaySoundAndScaleObject");
        }
    }

    IEnumerator ChangeMaterialDelayed(Material newMaterial, float delay)
    {
        waiting = true;
        yield return new WaitForSeconds(delay);
        objectRenderer.material = newMaterial;
        waiting = false;
    }

IEnumerator PlaySoundAndScaleObject(AudioSource audioSource, AudioClip audioClip)
{
    // Reproducir el sonido
    audioSource.PlayOneShot(audioClip);

    // Activar el cambio de escala
    isScaling = true;

    // Definir los valores de escala mínima, intermedia y máxima
    Vector3 minScale = new Vector3(0.002116647f, 0.002116647f, 0.001122834f);
    Vector3 midScale = new Vector3(0.002116647f, 0.002116647f, 0.001235062f); // Escala intermedia
    Vector3 maxScale = new Vector3(0.002116647f, 0.002116647f, 0.001443315f);

    // Ciclo para cambiar intercaladamente la escala mientras el sonido está sonando
    while (audioSource.isPlaying)
    {
        // Escala mínima
        objectToScale.transform.localScale = maxScale;

        // Espera un momento
        yield return new WaitForSeconds(audioClip.length / 120); // El audioClip.length / 4 divide el tiempo en cuatro para hacer el cambio más rápido

        // Escala intermedia
        objectToScale.transform.localScale = midScale;

        // Espera otro momento
        yield return new WaitForSeconds(audioClip.length / 120); // El audioClip.length / 8 divide el tiempo en ocho para hacer el cambio más rápido

        // Escala máxima
        objectToScale.transform.localScale = minScale;

        // Espera otro momento
        yield return new WaitForSeconds(audioClip.length / 120); // El audioClip.length / 8 divide el tiempo en ocho para hacer el cambio más rápido
    }

    // Restablecer la escala al finalizar el audio
    objectToScale.transform.localScale = maxScale;

    isScaling = false;
}



}
