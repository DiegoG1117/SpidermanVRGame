using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormuleCheck : MonoBehaviour
{
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;
    public GameObject check6;
    public GameObject check7;
    public WebFluid WF;
    public LiquidDetector LD;
    void Start()
    {
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(false);
        check4.SetActive(false);
        check5.SetActive(false);
        check6.SetActive(false);
        check7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(LD.Methanol == true)
        {
            check1.SetActive(true);
        }
        if(LD.Ethyl == true)
        {
            check2.SetActive(true);
        }
        if(LD.Pottasium == true)
        {
            check3.SetActive(true);
        }
        if(LD.Carbon == true)
        {
            check4.SetActive(true);
        }
        if(LD.Salicylic == true)
        {
            check5.SetActive(true);
        }
        if(LD.Toluene == true)
        {
            check6.SetActive(true);
        }
        if(WF.Stick == true)
        {
            check7.SetActive(true);
        }
    }
}
