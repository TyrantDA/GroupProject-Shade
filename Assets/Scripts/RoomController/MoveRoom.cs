using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRoom : MonoBehaviour
{
    //to be attached to the door trigger

    public int ID; // the doors ID, ID's are to be labled clockwise start with 0 at the botton possition of the room e.g. botton door will all ways be 0 top door will be 2 and left door 1 and right 3  
    public GameObject room; // the room game object that the door trigger is in
    public DoorController control; // the controller object 
    public Transform SpawnPos; // the empty game object in front of the door which is where the player will be spawn when exiting

    bool linked;
    [SerializeField] int linkedWith;
    [SerializeField] GameObject roomLink;
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

    public GameObject getLinkedRoom()
    {
        return roomLink;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("has detected " + other.tag);
        if(other.CompareTag("Player"))
        {
            if(linked)
            {
                // used roomlink and linedwith to find location
                GameObject[] hold = roomLink.GetComponent<Room>().getPlacement();
                for(int x = 0; x < hold.Length; x++)
                {
                    if(hold[x].GetComponent<MoveRoom>().ID == linkedWith)
                    {
                        other.gameObject.transform.position = hold[x].GetComponent<MoveRoom>().SpawnPos.position;
                        //Debug.Log(hold[x].GetComponent<MoveRoom>().SpawnPos.position);
                    }
                }
                

            }
            else
            {
                // run function in doorcontoller to find linked
                control.RoomLink(ID, room, gameObject);
                if(linked)
                {
                    GameObject[] hold = roomLink.GetComponent<Room>().getPlacement();
                    for (int x = 0; x < hold.Length; x++)
                    {
                        if (hold[x].GetComponent<MoveRoom>().ID == linkedWith)
                        {
                            other.gameObject.transform.position = hold[x].GetComponent<MoveRoom>().SpawnPos.position;
                            //Debug.Log(hold[x].GetComponent<MoveRoom>().SpawnPos.position);
                        }
                    }
                }
                else
                {
                    //Debug.Log("something when wrong");
                }
             }
            

        }
    }
}
