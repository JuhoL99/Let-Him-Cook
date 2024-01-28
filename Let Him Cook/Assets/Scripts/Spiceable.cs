using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiceable : MonoBehaviour
{
    PickupDrop2 pickupScript;
    public GameObject spicedLayerObject;
    public Renderer spiceRend;
    IngredientAttributes ingredientAttributes;
    void Start()
    {
        pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
        spicedLayerObject = transform.GetChild(0).gameObject;
        spiceRend = spicedLayerObject.GetComponent<Renderer>();
        spiceRend.material = Instantiate(spiceRend.material);
        spiceRend.enabled = false;
        ingredientAttributes = GetComponent<IngredientAttributes>();
    }

    void Update()
    {
        
    }

    void GetInteracted()
    {
        if (!pickupScript.spiceHeld) return;
        SpiceBehaviour spiceScript = pickupScript.pickedUpObject.GetComponent<SpiceBehaviour>();
        int spiceNum = spiceScript.spiceNum;
        Color textureColor = spiceScript.spiceTextureColor;
        ingredientAttributes.seasoning = spiceNum;
        spiceScript.SpiceItUp();
        GetSpiced(textureColor);
    }
    void GetSpiced(Color textureColor)
    {
        spiceRend.enabled = true;
        spiceRend.material.color = textureColor;
    }
}
