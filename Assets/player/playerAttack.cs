using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject trypod;
    public Vector3 turretOffset; 
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetTrigger("SwingDaWoopen");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(trypod, transform.position+ transform.TransformDirection(Vector3.forward + turretOffset), transform.rotation);
        }
    }
    
}
