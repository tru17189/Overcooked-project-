using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerca : MonoBehaviour
{
  List<table> tablelist;
  table current; 

    //Start is called before the first frame update
    void Start()
    {
        tablelist = new List<table>();
    }

    public table Getselected()
    {
        return current; 
    }  

    private void OnTriggerEnter(Collider other)
    {
        table f = other.gameObject.GetComponent<table>();
        if (f != null) {
            tablelist.Add(f);
            //Debug.Log("Se agrego: " + f.name);
        }
        selectTable();
    }

    private void OnTriggerExit(Collider other)
    {
        table f = other.gameObject.GetComponent<table>();
        if (f != null)
        {
            tablelist.Remove(f);
            chopper fChopper = f.GetComponent<chopper>();
            if (fChopper != null) {
                fChopper.StartChooping();
            }
            //Debug.Log("Se elimino: " + f.name);
        }
        selectTable();
    }

    private void selectTable() {
        if (current != null) {
            current.RemoveHighlight(); 
        }

        if (tablelist.Count > 0)
        {
            table selected = null;
            float Idistance = 1000f;
            foreach (table f in tablelist)
            {
                float distance = Vector3.Distance(transform.position, f.transform.position);
                if (distance < Idistance)
                {
                    Idistance = distance;
                    selected = f;
                }
            }

            if (selected != null)
            {
                //Debug.Log("El mas cercano es: " + selected.name);
                selected.Highlight();
                current = selected;
                //transform.localScale += new Vector3(0.1F, 0, 0);
            }
        }
    }

    void Update()
    {
        selectTable(); 
    }
}
