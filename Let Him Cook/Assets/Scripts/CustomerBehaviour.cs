using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    bool spawnSliding, endSliding, missionStarted;
    Vector3 startPos, endPos;
    float backwardSpeed = 0;
    float t;
    float backwardAcceleration = 10f;
    static CustomerManager manager;
    static PickupDrop2 pickupScript;
    void Start()
    {
        manager = GameObject.Find("Customer Manager").GetComponent<CustomerManager>();
        pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
    }

    void Update()
    {
        SpawnSlide();
        EndSlide();
    }

    public void StartSpawnSlide(Vector3 startPos, Vector3 endPos, float t)
    {
        spawnSliding = true;
        this.endPos = endPos;
        this.t = t;
    }
    void SpawnSlide()
    {
        if (!spawnSliding) return;
        transform.position = Vector3.Lerp(transform.position, endPos, t);
        if ((transform.position-endPos).magnitude < 0.01f){
            spawnSliding = false;
        }
    }
    void EndSlide()
    {
        if (!endSliding) return;
        backwardSpeed += backwardAcceleration * Time.deltaTime;
        transform.position += -transform.forward * backwardSpeed * Time.deltaTime;
    }
    void GetInteracted()
    {
        Debug.Log("Customer was interacted, mission started: "+missionStarted);
        if (missionStarted)
        {

            if (pickupScript.pickedUpObject == null) return;
            if (pickupScript.pickedUpObject.TryGetComponent(out IngredientAttributes ia))
            {

                manager.EndMission(ia);
                Destroy(pickupScript.pickedUpObject);
                pickupScript.pickedUpObject = null;
                Invoke("StartDespawnSlide", 4f);
                Invoke("SpawnNewCustomer", 7f);
            }
        }
        else
        {
            missionStarted = true;
            manager.StartMission();
        }
    }
    void StartDespawnSlide()
    {
        endSliding = true;
    }
    void SpawnNewCustomer()
    {
        manager.SpawnCustomer();
        Destroy(gameObject);
    }
}
