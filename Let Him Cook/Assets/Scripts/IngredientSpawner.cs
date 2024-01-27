using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
 {
    public GameObject ingredient;
    public Vector3 spawnDirection;
    void GetInteracted()
    {
        GameObject newIngredientObject = Instantiate(ingredient, transform.Find("SpawnPoint").position, Quaternion.identity);
        newIngredientObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(spawnDirection).normalized * 3f, ForceMode.Impulse);
    }
}
