using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoomSpawn : MonoBehaviour
{
    public int roomSize;
    public int NumberOfRoom;

    public GameObject room;

    [SerializeField] List<GameObject> RoomLoaded;

    int hold;
    Vector3 holdPos;
    int[] holdPlacement;

    // Start is called before the first frame update
    void Start()
    {
        RoomLoaded.Add(Instantiate(room, new Vector3(0f, 0f, 0f), Quaternion.identity));
        Invoke("spawn", 0.1f);
        
    }

    //void Start()
    //{
    //    RoomLoaded.Add(Instantiate(room, new Vector3(0f, 0f, 0f), Quaternion.identity));

    //    for (int x = 0; x < NumberOfRoom; x++)
    //    {
    //        holdPos = RoomLoaded[0].GetComponent<Room>().getPos();
    //        Invoke("spawn", 0.1f);



    //    }

    //}

    void spawn()
    {
        for (int x = 0; x < NumberOfRoom; x++)
        {
            //hold = RoomLoaded[x].GetComponent<Room>().NumberOfDoor;
            Vector3 holdPos = RoomLoaded[x].GetComponent<Room>().getPos();
            Debug.Log("RoomPos " + holdPos + "  :  " + RoomLoaded.Capacity);
            //holdPlacement = RoomLoaded[x].GetComponent<Room>().getPlacement();
            Invoke("spawn2", 0.1f);
        }
    }

    void spawn2()
    {
        for (int j = 0; j < hold; j++)
        {
            Debug.Log("Enter");
            if (holdPlacement[j] == 0)
            {
                Vector3 a = holdPos + new Vector3((float)-roomSize, 0f, 0f);
                RoomLoaded.Add(Instantiate(room, a, Quaternion.identity));
            }
            else if (holdPlacement[j] == 1)
            {
                Vector3 b = holdPos + new Vector3(0f, 0f, (float)roomSize);
                RoomLoaded.Add(Instantiate(room, b, Quaternion.identity));
            }
            else if (holdPlacement[j] == 2)
            {
                Vector3 c = holdPos + new Vector3((float)roomSize, 0f, 0f);
                RoomLoaded.Add(Instantiate(room, c, Quaternion.identity));
            }
            else if (holdPlacement[j] == 3)
            {
                Vector3 d = holdPos + new Vector3(0f, 0f, (float)-roomSize);
                RoomLoaded.Add(Instantiate(room, d, Quaternion.identity));
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
