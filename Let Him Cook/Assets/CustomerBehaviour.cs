using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    bool spawnSliding;
    Vector3 startPos, endPos;
    float t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSlide();
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
}
