using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int ID;
    [SerializeField] GameObject[] placementOfDoors;
    
    [SerializeField] Vector3 RoomPos;
    // Start is called before the first frame update
    void Start()
    {
        RoomPos = transform.position;
    }

    public Vector3 getPos()
    {
        return RoomPos;
    }

    public GameObject[] getPlacement()
    {
        return placementOfDoors;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
