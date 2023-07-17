using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class request : MonoBehaviour
{

    public List<RecipesSO> recipePull;
    public List<string> currentRecipe = new List<string>();
    public RecipesSO currentRecipeSO;

    void Awake()
    {
        currentRecipeSO = recipePull[ Random.Range(0, recipePull.Count)];
    }

    
    void Update()
    {
        currentRecipe = currentRecipeSO.recipe;

    }
}
