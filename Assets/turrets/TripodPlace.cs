using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripodPlace : MonoBehaviour
    
{
    public GameObject turretHead;
    public Vector3 turretOffset;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 200))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            transform.position += new Vector3(0, -hit.distance, 0);
            Instantiate(turretHead, transform.position + turretOffset, transform.rotation);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
