using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;

public class CustomerTest : MonoBehaviour
{
    public CustomerJSONParser JSONParser;
    [SerializeField] private GameObject[] bodies, faces;
    [SerializeField] private GameObject bodyTemplate, currentBody, currentFace;
    [SerializeField] private Transform bodyT, faceT;
    [SerializeField] private bool activeCustomer = false;
    [SerializeField] private string currentLine;
    public Vector3 spawnPos, behindCounterPos;
    public Vector3 currentOptions;
    private void Update()
    {
        SpawnCustomer();
    }
    private void SpawnCustomer()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!activeCustomer)
            {
                activeCustomer = true;
                int customerID = Random.Range(0, JSONParser.customers.Length);
                int clothes = JSONParser.customers[customerID].CLOTHES;
                int age = JSONParser.customers[customerID].AGE;
                int personality = JSONParser.customers[customerID].PERSONALITY;
                string line = JSONParser.customers[customerID].LINE;
                currentOptions = new Vector3(clothes, age, personality);
                BuildCustomer(clothes, age, personality, line);
            }
            else
            {
                Destroy(currentBody);
                Destroy(currentFace);
                activeCustomer = false;
            }
        }
    }
    private void BuildCustomer(int clothes, int age, int personality, string line)
    {
        Debug.Log($"clothes: {clothes}, age: {age}, personality: {personality}");
        currentBody = Instantiate(bodies[clothes], bodyT);
        currentFace = Instantiate(faces[age], faceT);
        currentLine = line;
        Debug.Log($"{line}");
    }
}
