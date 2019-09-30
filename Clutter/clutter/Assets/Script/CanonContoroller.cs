using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonContoroller : MonoBehaviour
{
    public GameObject player;
    public bool BangFlag;
    Vector3 pos;
    
    void Start()
    {
        player = GameObject.Find("player");
        BangFlag = false;
        pos = this.transform.position;
        pos.y += 500;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.position = pos;
            BangFlag = true;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && BangFlag)
        {
            pos.y = 21;
            player.transform.position = pos;
            player.GetComponent<Rigidbody>().isKinematic = false;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0f, 0f, 0f);
            rb.AddForce(force, ForceMode.Impulse);
            BangFlag = false;
        }
    }
}
