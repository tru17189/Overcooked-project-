using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTable : MonoBehaviour
{
    public GameObject ingredient;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public movableObject GetIngredient()
    {
        GameObject NewObject = Instantiate(ingredient);
        movableObject movable = NewObject.GetComponent<movableObject>();
        return movable;
    }
}
