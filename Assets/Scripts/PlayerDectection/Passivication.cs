using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;


public class Passivication : MonoBehaviour
{
    public bool acive = true;
    public bool stopped = false;
    public Rigidbody RB; 
    // Start is called before the first frame update
    void Start()
    {
        acive = false;
        RB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (acive != true)
        {

            if (stopped != true)
            {
                GetComponent<Patrol>().enabled = !GetComponent<Patrol>().enabled;
                GetComponent<Dectection>().enabled = !GetComponent<Dectection>().enabled;
                GetComponent<NavMeshAgent>().enabled = !GetComponent<NavMeshAgent>().enabled;

RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
                RB.Sleep();
                stopped = true;
                StartCoroutine("Delaythis");


            }
        }
        if (acive == true)
        {
            if(stopped == true)
            {
                GetComponent<Patrol>().enabled = !GetComponent<Patrol>().enabled;
                GetComponent<Dectection>().enabled = !GetComponent<Dectection>().enabled;
                GetComponent<NavMeshAgent>().enabled = !GetComponent<NavMeshAgent>().enabled;
                stopped = false;

            }
        }

    }
    IEnumerator Delaythis()
    {

        yield return new WaitForSeconds(5);
        acive = true;


    }
}
