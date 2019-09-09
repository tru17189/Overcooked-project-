using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holder : MonoBehaviour
{
    public movableAnchor movableAnchor;
    movableObject movable; 
    // Start is called before the first frame update
    void Start()
    {
        movable = movableAnchor.GetComponentInChildren<movableObject>();
    }

    public bool HasMovable()
    {
        return movable != null; 
    }

    public movableObject GetMovable()
    {
        return movable;
    }

    public void SetMovable(movableObject newMovable)
    {
        movable = newMovable;
        newMovable.gameObject.transform.SetParent(movableAnchor.transform);
        newMovable.transform.localPosition = new Vector3(0, 0, 0);
    }

    public movableObject RemoveMovable()
    {
        return movable = null; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
