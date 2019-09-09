using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum foodType {
    TOMATO,
    ONION,
    MUSHROOM
}

public class food : MonoBehaviour
{
    public foodType type;
    public foodState currentState;

    public void ChangeState(foodState newState)
    {
        currentState.gameObject.SetActive(false);
        newState.gameObject.SetActive(true);
        currentState = newState;
    }

    public void processFood(float time) {
        currentState.ProcessFood(time);
    }

    public foodStatus GetStatus() {
        return currentState.Status;
    }

    public void Hidemodel() {
        currentState.mesh.SetActive(false);
    }
}
