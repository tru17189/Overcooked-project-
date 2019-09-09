using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopper : MonoBehaviour
{
    public bool isChooping = false;
    private food currentFood;
    private holder choppingHolder;
    public AudioSource cut;
   
    // Start is called before the first frame update
    void Start()
    {
        choppingHolder = GetComponent<holder>();
    }

    public bool StartChooping() {
        if (choppingHolder.HasMovable()) {
            movableObject movable = choppingHolder.GetMovable();
            currentFood = movable.GetComponent<food>();
            if (currentFood != null && currentFood.GetStatus() == foodStatus.RAW) {
                isChooping = true;
                    cut.Play();
                
            }
        }
        return isChooping;
    }

    public void StopChooping() {
        isChooping = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isChooping) {
            currentFood.processFood(Time.deltaTime);
            if (currentFood.GetStatus() != foodStatus.RAW) {
                isChooping = false; 
            }
        }
        
    }
}
