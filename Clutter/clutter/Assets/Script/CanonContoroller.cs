using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonContoroller : MonoBehaviour
{
    public GameObject player;
    public bool BangFlag;

    void Start()
    {
        player = GameObject.Find("player");
        BangFlag = false;
    }


    void OnTrigerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            Vector3 pos = this.transform.position;
            pos.y += 50;
            player.transform.position = pos;
            player.GetComponent<Rigidbody>().useGravity = false;
            BangFlag = true;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && BangFlag)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0.0f, 10.0f, 0.0f);
            rb.AddForce(force,ForceMode.Impulse);
            if (BangFlag)
            {
                Vector3 pos = this.transform.position;
                pos.y -= 50;
                player.transform.position = pos;
                player.GetComponent<Rigidbody>().useGravity = true;
                BangFlag = false;
            }
        }
    }
}
