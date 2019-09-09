using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum foodStatus {
    RAW,
    CUT,
    COOKED,
    BURNED

}

public class foodState : MonoBehaviour
{
    public GameObject mesh;
    public float processInTime;
    public foodStatus Status; 
    public foodState nextState;
    public float currentTime;
    private food parentfood;
    public float something;
    private barra tiempo;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        parentfood = GetComponentInParent<food>();
    }

    public void ProcessFood(float time)
    {
        
        currentTime += time;
        something = 1;

        if (currentTime >= processInTime) {
            //tiempo.convert(timebar);
            parentfood.ChangeState(nextState);
        }
    } 
    
}
