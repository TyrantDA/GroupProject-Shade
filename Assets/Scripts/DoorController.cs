using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorController : MonoBehaviour
{
    [SerializeField] List<GameObject> rooms = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RoomLink(int doorID, GameObject room, GameObject self)
    {
        bool find = false;
        while (!find)
        {
            System.Random rnd = new System.Random();
            int num = rnd.Next(4);
            if (rooms[num] == room)
            {
                num++;
                if (num >= rooms.Count)
                {
                    num = 0;
                }
            }

           if(doorID >= rooms[num].GetComponent<Room>().getPlacement().Length)
            {
                Debug.Log("shit");
            }
           else
            {
                if(doorID == 0)
                {
                    if (!rooms[num].GetComponent<Room>().getPlacement()[2].GetComponent<MoveRoom>().IsLinked())
                    {
                        find = true;
                        self.GetComponent<MoveRoom>().EnterLink(2, rooms[num]);
                        rooms[num].GetComponent<Room>().getPlacement()[2].GetComponent<MoveRoom>().EnterLink(doorID, room);
                    }
                }
                else if (doorID == 1)
                {
                    if (!rooms[num].GetComponent<Room>().getPlacement()[3].GetComponent<MoveRoom>().IsLinked())
                    {
                        find = true;
                        self.GetComponent<MoveRoom>().EnterLink(3, rooms[num]);
                        rooms[num].GetComponent<Room>().getPlacement()[2].GetComponent<MoveRoom>().EnterLink(doorID, room);
                    }
                }
                else if (doorID == 2)
                {
                    if (!rooms[num].GetComponent<Room>().getPlacement()[0].GetComponent<MoveRoom>().IsLinked())
                    {
                        find = true;
                        self.GetComponent<MoveRoom>().EnterLink(0, rooms[num]);
                        rooms[num].GetComponent<Room>().getPlacement()[2].GetComponent<MoveRoom>().EnterLink(doorID, room);
                    }
                }
                else if (doorID == 3)
                {
                    if (!rooms[num].GetComponent<Room>().getPlacement()[1].GetComponent<MoveRoom>().IsLinked())
                    {
                        find = true;
                        self.GetComponent<MoveRoom>().EnterLink(1, rooms[num]);
                        rooms[num].GetComponent<Room>().getPlacement()[2].GetComponent<MoveRoom>().EnterLink(doorID, room);
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       // int hold = rooms[0].transform.FindChild("DoorTrigger").GetComponent<MoveRoom>().ID;
       // int hold2 = rooms[0].transform.Find("DoorTrigger").GetComponent<MoveRoom>().ID;

    }
}
