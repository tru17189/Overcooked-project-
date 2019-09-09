using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class barra : MonoBehaviour
{
    Image TimeBar;
    public float MaxTime = 5f;
    float Timeleft;
    float FlagTime;
    public GameObject timesUpText;
    private foodState state;
    barra objeto;

    // Start is called before the first frame update
    void Start()
    {
        timesUpText.SetActive(false);
        TimeBar = GetComponent<Image>();
        Timeleft = MaxTime;
        state = GetComponent<foodState>();
      
    }

    // Update is called once per frame
     void Update()
    {
        //if (objeto.se)
       // {
         //   FlagTime = 1;
        //}

        //if (FlagTime == 1)
        //{
            if (Timeleft > 0)
            {
                Timeleft -= Time.deltaTime;
                TimeBar.fillAmount = Timeleft / MaxTime;
            }
            else
            {
                timesUpText.SetActive(true);
                MaxTime = 5f;
                //Time.timeScale = 0;
            }

        //}
        }
        
 
}
