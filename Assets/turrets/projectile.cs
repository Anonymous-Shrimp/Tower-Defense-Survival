using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(transform.forward * speed * 40);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        Destroy(gameObject);
    }
}
