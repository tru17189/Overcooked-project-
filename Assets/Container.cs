using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public List<recipeIngredent> accepts;
    public List<food> contentFood;
    public int maxElements = 3;
    public Canvas canvas;
    public GameObject contentsParent;
    public List<Image> Iconlist;
    private int solution;
    int solutin2 = 0;

    public foodType one;
    public foodType two;
    public foodType three;
    //public List<recipedata> soups;

    private void Start()
    {
        contentFood = new List<food>();
    }

    private Sprite GetSprite(food Food) {
        Sprite result = null;

        foreach (recipeIngredent item in accepts)
        {
            if (item.foodTYPE == Food.type && item.foosSTATUS == Food.GetStatus())
            {
                if (solutin2 == 0)
                {
                    result = item.icon;
                    solutin2 += 1;
                    one = item.foodTYPE;
                    resultado();
                }
                else if (solutin2 == 1)
                {
                    result = item.icon;
                    solutin2 += 1;
                    two = item.foodTYPE;
                    resultado2();
                }
                else if (solutin2 == 2) {
                    result = item.icon;
                    solutin2 = 0;
                    three = item.foodTYPE;
                    resultado3();
                }
                break;
            }
        }

        return result;
    }

    public foodType resultado()
    {
        if (solutin2 == 1) {
            Debug.Log("Hola soy:"+one);
        }
        return one;
    }

    public foodType resultado2()
    {
        if (solutin2 == 2)
        {
            Debug.Log("Hola soy:" + two);
        }
        return two;
    }

    public foodType resultado3()
    {
        if (solutin2 == 0)
        {
            Debug.Log("Hola soy:" + three);
        }
        return three;
    }

    protected Material GetMaterial(food Food)
    {
        Material result = null;
        foreach (recipeIngredent item in accepts)
        {
            if (item.foodTYPE == Food.type && item.foosSTATUS == Food.GetStatus())
            {
                result = item.soupMaterial;
                break;
            }
        }

        return result;
    }

    public bool CanAccept(food Food) {
        bool result = false;
        if (contentFood.Count < 5)
        {        
            foreach (recipeIngredent item in accepts)
            {
                if (item.foodTYPE == Food.type && item.foosSTATUS == Food.GetStatus())
                {
                    result = true;
                    break;
                }
            }

        }

        return result;
    }
    
    public virtual void recived(food Food) {
        contentFood.Add(Food);
        Food.transform.SetParent(contentsParent.transform);
        if (Iconlist.Count > 0)
        {
            solution += 1;
            Iconlist[Iconlist.Count - solution].sprite = GetSprite(Food);
            if (solution == 3) {
                solution = solution - 3;
            }
        }
        Food.Hidemodel();
    }

    private void LateUpdate()
    {
        Camera camera = Camera.main;
        canvas.transform.LookAt(canvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }

}
