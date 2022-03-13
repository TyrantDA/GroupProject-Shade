using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRoom : MonoBehaviour
{
    public int ID;
    public GameObject room;
    public DoorController control;
    public Transform SpawnPos;

    bool linked;
    int linkedWith;
    GameObject roomLink;
    // Start is called before the first frame update
    void Start()
    {
        linked = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform hold = transform.parent;
        //GameObject h = hold.gameObject;
        //Debug.Log(h.name);
    }

    public void EnterLink(int dI, GameObject rI)
    {
        linkedWith = dI;
        roomLink = rI;
        linked = true;
    }

    public bool IsLinked()
    {
        return linked;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("has detected " + other.tag);
        if(other.CompareTag("Player"))
        {
            if(linked)
            {
                // used roomlink and linedwith to find location
                GameObject[] hold = roomLink.GetComponent<Room>().getPlacement();
                other.gameObject.transform.position = hold[linkedWith].GetComponent<MoveRoom>().SpawnPos.position;

            }
            else
            {
                // run function in doorcontoller to find linked
                control.RoomLink(ID, room, gameObject);
                if(linked)
                {
                    GameObject[] hold = roomLink.GetComponent<Room>().getPlacement();
                    other.gameObject.transform.position = hold[linkedWith].GetComponent<MoveRoom>().SpawnPos.position;
                }
                else
                {
                    Debug.Log("something when wrong");
                }
             }
            

        }
    }
}
