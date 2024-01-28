using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public CustomerJSONParser JSONParser;
    [SerializeField] private GameObject[] bodies, faces;
    [SerializeField] private GameObject customerTemplate;
    [SerializeField] private string currentLine;
    public Transform spawnTransform, behindCounterTransform;
    [System.NonSerialized] public Vector3Int currentOptions;
    [System.NonSerialized] public GameObject currentCustomer;
    public float slideT;
    public bool missionStarted;
    string good, mid, bad;
    private void Start()
    {
        Invoke("SpawnCustomer", 2f);
    }
    public void SpawnCustomer()
    {
        int customerID = Random.Range(0, JSONParser.customers.Length);
        int clothes = JSONParser.customers[customerID].CLOTHES;
        int age = JSONParser.customers[customerID].AGE;
        int personality = JSONParser.customers[customerID].PERSONALITY;
        string line = JSONParser.customers[customerID].LINE;
        good = JSONParser.customers[customerID].GOOD;
        mid = JSONParser.customers[customerID].MID;
        bad = JSONParser.customers[customerID].BAD;
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
    }
    public void StartMission()
    {
        missionStarted = true;
        SayDialogue(currentLine);
    }
    public void EndMission(IngredientAttributes ia)
    {
        Vector3Int playerOptions = new Vector3Int(ia.ingredient, ia.cookMethod, ia.seasoning);
        currentOptions += Vector3Int.one;
        int score = 0;
        if (playerOptions.x == currentOptions.x) score++;
        if (playerOptions.y == currentOptions.y) score++;
        if (playerOptions.z == currentOptions.z) score++;
        if (score == 3)
        {
            SayDialogue(good);
        }
        else if (score == 2)
        {
            SayDialogue(mid);
        }
        else
        {
            SayDialogue(bad);
        }
        missionStarted = false;
    }
    public void SayDialogue(string dialogue)
    {
        Debug.Log($"{dialogue}");
    }
}
