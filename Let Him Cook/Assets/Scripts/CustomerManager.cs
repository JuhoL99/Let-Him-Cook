using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public CustomerJSONParser JSONParser;
    [SerializeField] private GameObject[] bodies, faces;
    [SerializeField] private GameObject customerTemplate;
    [SerializeField] private bool activeCustomer = false;
    [SerializeField] private string currentLine;
    public Transform spawnTransform, behindCounterTransform;
    [System.NonSerialized] public Vector3Int currentOptions;
    [System.NonSerialized] public GameObject currentCustomer;
    public float slideT;
    private void Start()
    {
        Invoke("SpawnCustomer", 2f);
    }
    public void SpawnCustomer()
    {
        if (activeCustomer) return;
        activeCustomer = true;



        int customerID = Random.Range(0, JSONParser.customers.Length);
        int clothes = JSONParser.customers[customerID].CLOTHES;
        int age = JSONParser.customers[customerID].AGE;
        int personality = JSONParser.customers[customerID].PERSONALITY;
        string line = JSONParser.customers[customerID].LINE;
        currentOptions = new Vector3Int(clothes, age, personality);
        BuildCustomer(clothes, age, personality, line);
    }
    private void BuildCustomer(int clothes, int age, int personality, string line)
    {
        Debug.Log($"clothes: {clothes}, age: {age}, personality: {personality}");
        GameObject newCustomer = Instantiate(customerTemplate, spawnTransform.position, spawnTransform.rotation);
        currentCustomer = newCustomer;
        newCustomer.GetComponent<CustomerBehaviour>().StartSpawnSlide(spawnTransform.position, behindCounterTransform.position, slideT);
        Instantiate(bodies[clothes], newCustomer.transform.GetChild(0));
        Instantiate(faces[age], newCustomer.transform.GetChild(1));
        currentLine = line;
        Debug.Log($"{line}");
    }
}
