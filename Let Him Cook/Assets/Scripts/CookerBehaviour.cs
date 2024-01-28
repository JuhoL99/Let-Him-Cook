using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CookerBehaviour : MonoBehaviour
{
    PickupDrop2 pickupScript;
    public int cookMethod;
    public float runtime = 3f;
    public Vector3 launchDirection;
    Transform cookPoint, spawnPoint;
    public Material cookedMaterial;
    float timer;
    bool running;
    IngredientAttributes ingredientAttributes;
    GameObject objectInside;
    void Start()
    {
        pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
        cookPoint = transform.Find("CookPoint");
        spawnPoint = transform.Find("SpawnPoint");
        timer = runtime;
    }
    private void Update()
    {
        Running();
    }
    void GetInteracted()
    {
        if (running || pickupScript.pickedUpObject == null) return;
        if (pickupScript.pickedUpObject.TryGetComponent(out IngredientAttributes ia))
        {
            ingredientAttributes = ia;
            objectInside = pickupScript.pickedUpObject;
            objectInside.transform.SetParent(cookPoint);
            objectInside.transform.localPosition = Vector3.zero;
            pickupScript.pickedUpObject = null;
            running = true;
        }
    }
    void Running()
    {
        if (!running) return;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            running = false;
            timer = runtime;
            Pop();
        }
    }
    void Pop()
    {
        ingredientAttributes.cookMethod = cookMethod;
        objectInside.GetComponent<Renderer>().material = Instantiate(cookedMaterial);
        objectInside.transform.SetParent(null);
        objectInside.transform.position = spawnPoint.position;
        objectInside.layer = LayerMask.NameToLayer("RigidbodyIngredient");
        Rigidbody newRB = objectInside.AddComponent<Rigidbody>();
        newRB.AddForce(transform.TransformDirection(launchDirection).normalized * 3f, ForceMode.Impulse);

        objectInside = null;
        ingredientAttributes = null;
    }
}
