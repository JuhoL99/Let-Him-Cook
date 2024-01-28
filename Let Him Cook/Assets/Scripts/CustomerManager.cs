using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    TextMeshProUGUI tmp;
    private void Start()
    {
        tmp = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Invoke("SpawnCustomer", 2f);
    }
    public void SpawnCustomer()
    {
        int customerID = Random.Range(0, JSONParser.customers.Length);
        int clothes = JSONParser.customers[customerID].PERSONALITY;
        int age = JSONParser.customers[customerID].AGE;
        int personality = JSONParser.customers[customerID].CLOTHES;
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
        Debug.Log("Customer options: " + currentOptions);
    }
    public void EndMission(IngredientAttributes ia)
    {
        Vector3Int playerOptions = new Vector3Int(ia.ingredient, ia.cookMethod, ia.seasoning);
        Debug.Log("Clothes-Ingredient: " + currentOptions.x + "-" + playerOptions.x);
        Debug.Log("Age-CookMethod: " + currentOptions.x + "-" + playerOptions.x);
        Debug.Log("Personality-Seasoning: " + currentOptions.x + "-" + playerOptions.x);
        currentOptions += Vector3Int.one;
        int score = 0;
        if (playerOptions.x == currentOptions.x) score++;
        if (playerOptions.y == currentOptions.y) score++;
        if (playerOptions.z == currentOptions.z) score++;
        string endDialogue;
        if (score == 3)
        {
            endDialogue = good;
        }
        else if (score == 2)
        {
            endDialogue = mid;
        }
        else
        {
            endDialogue = bad;
        }
        SayDialogue(endDialogue + "\nScore: " + score);

        missionStarted = false;
        Invoke("ClearDialogue", 3f);
    }
    public void SayDialogue(string dialogue)
    {
        tmp.text = dialogue;
    }
    void ClearDialogue()
    {
        tmp.text = "";
    }
}
