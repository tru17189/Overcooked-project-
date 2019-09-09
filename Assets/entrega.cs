using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrega : MonoBehaviour
{
    public List<recipedata> possibleRecipes;
    public recipe baseRecipe;
    public Canvas canvas;
    public List<recipe> recipelist;
    int maxRecipe = 4;
    int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRecipe());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerateRecipe()
    {
        while (true) {
            if (recipelist.Count < maxRecipe) {
                randomIndex = Random.Range(0, possibleRecipes.Count);
                devolver();
                recipe Recipe = Instantiate(baseRecipe, canvas.transform);
                Recipe.Setup(possibleRecipes[randomIndex], recipelist.Count);
                recipelist.Add(Recipe);
            }
            yield return new WaitForSeconds(50);

        }
    }

    public int devolver()
    {
        return randomIndex;
    }
}
