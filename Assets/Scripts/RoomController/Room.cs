using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // to be placed on the game object repistion the room the parent object nomal an empty object
    public int ID; // ID of the room
    [SerializeField] GameObject[] placementOfDoors; // array of door in this room
    
    [SerializeField] Vector3 RoomPos; // room pos used for testing
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
