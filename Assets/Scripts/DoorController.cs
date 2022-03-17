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
        // generate random number betweeen 0 and 3 
        System.Random rnd = new System.Random();
        int num = rnd.Next(4);
        bool find = false;
        int holdlink = 0;
        // check that room is not the same room 

        while (!find)
        {
            
            if (rooms[num].GetComponent<Room>().ID == room.GetComponent<Room>().ID)
            {
                num++;
               
            }

            if (num >= rooms.Count)
            {
                num = 0;
            }

            for (int x = 0; x < rooms[num].GetComponent<Room>().getPlacement().Length; x++)
            {
                if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                {
                    if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().getLinkedRoom().GetComponent<Room>().ID == room.GetComponent<Room>().ID)
                    {
                        Debug.Log("went off");
                        holdlink++;
                    }
                }
            }
            if (holdlink < 2)
            {
                for (int x = 0; x < rooms[num].GetComponent<Room>().getPlacement().Length; x++)
                {
                    if (doorID == 0)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 2)
                        {
                            if (!rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                            {
                                find = true;
                                self.GetComponent<MoveRoom>().EnterLink(2, rooms[num]);
                                rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().EnterLink(doorID, room);
                            }
                        }
                    }
                    else if (doorID == 1)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 3)
                        {
                            if (!rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                            {
                                find = true;
                                self.GetComponent<MoveRoom>().EnterLink(3, rooms[num]);
                                rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().EnterLink(doorID, room);
                            }
                        }
                    }
                    else if (doorID == 2)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 0)
                        {
                            if (!rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                            {
                                find = true;
                                self.GetComponent<MoveRoom>().EnterLink(0, rooms[num]);
                                rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().EnterLink(doorID, room);
                            }
                        }
                    }
                    else if (doorID == 3)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 1)
                        {
                            if (!rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                            {
                                find = true;
                                self.GetComponent<MoveRoom>().EnterLink(1, rooms[num]);
                                rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().EnterLink(doorID, room);
                            }
                        }
                    }

                }
            }
            num++;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // int hold = rooms[0].transform.FindChild("DoorTrigger").GetComponent<MoveRoom>().ID;
       // int hold2 = rooms[0].transform.Find("DoorTrigger").GetComponent<MoveRoom>().ID;

    }

    private void hold(int doorID, GameObject room, GameObject self)
    {
        bool find = false;
        bool inArray = false;
        bool contact = false;
        int hold = -1;
        int holdlink = 0;
        int count = 0;
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

            for (int x = 0; x < rooms[num].GetComponent<Room>().getPlacement().Length; x++)
            {
                if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().IsLinked())
                {
                    if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().getLinkedRoom().GetComponent<Room>().ID == room.GetComponent<Room>().ID)
                    {
                        Debug.Log("went off");
                        holdlink++;
                    }
                }
            }

            if (holdlink <= 2)
            {

                for (int x = 0; x < rooms[num].GetComponent<Room>().getPlacement().Length; x++)
                {
                    if (doorID == 0)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 2)
                        {
                            inArray = true;
                            hold = x;
                        }
                    }
                    else if (doorID == 1)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 3)
                        {
                            inArray = true;
                            hold = x;
                        }
                    }
                    else if (doorID == 2)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 0)
                        {
                            inArray = true;
                            hold = x;
                        }
                    }
                    else if (doorID == 3)
                    {
                        if (rooms[num].GetComponent<Room>().getPlacement()[x].GetComponent<MoveRoom>().ID == 1)
                        {
                            inArray = true;
                            hold = x;
                        }
                    }

                }

                if (inArray)
                {
                    if (doorID == 0)
                    {
                        if (!rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().IsLinked())
                        {
                            find = true;
                            self.GetComponent<MoveRoom>().EnterLink(2, rooms[num]);
                            rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().EnterLink(doorID, room);
                        }
                    }
                    else if (doorID == 1)
                    {
                        if (!rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().IsLinked())
                        {
                            find = true;
                            self.GetComponent<MoveRoom>().EnterLink(3, rooms[num]);
                            rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().EnterLink(doorID, room);
                        }
                    }
                    else if (doorID == 2)
                    {
                        if (!rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().IsLinked())
                        {
                            find = true;
                            self.GetComponent<MoveRoom>().EnterLink(0, rooms[num]);
                            rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().EnterLink(doorID, room);
                        }
                    }
                    else if (doorID == 3)
                    {
                        if (!rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().IsLinked())
                        {
                            find = true;
                            self.GetComponent<MoveRoom>().EnterLink(1, rooms[num]);
                            rooms[num].GetComponent<Room>().getPlacement()[hold].GetComponent<MoveRoom>().EnterLink(doorID, room);
                        }
                    }
                }
            }
            //count++;
            //if(count > 1000000)
            //{
            //    Debug.Log("could not connect");
            //    find = true;
            //}
        }
    }
}
