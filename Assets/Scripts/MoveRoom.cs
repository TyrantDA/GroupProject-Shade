using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreDoor
{
    private string levelName;
    private int doorID;

    public StoreDoor(string ln, int di)
    {
        levelName = ln;
        doorID = di;
    }
}
public class MoveRoom : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("has detected " + other.tag);
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("TestScene");
        }
    }
}
