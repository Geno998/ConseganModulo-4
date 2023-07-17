using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "recipes", menuName = "scriptableObjects/Recipes")]
public class RecipesSO : ScriptableObject
{

    public string dishName;

    public List<string> recipe;
}
