using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 10;
    public float JampForce = 0f;
    bool JampFlag = false;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();


        if (Input.GetKey(KeyCode.Space))
        {
            if (!JampFlag)
            {
                JampFlag = true;
                rigidbody.AddForce(0f, JampForce, 0f);
            }
        }
        else
        {
            if (JampFlag)
            {
                rigidbody.AddForce(0f, -3f, 0f);
                JampFlag = false;
            }
        }

        // xとzに10をかけて押す力をアップ
        rigidbody.AddForce(x * PlayerSpeed, 0f, z * PlayerSpeed);
    }
}

/*HP管理用
    public int MaxHP = 10;
    public int HP = 10;
    public void Damage(int val)
    {
        HP -= val;
        HP = HP < 0 ? 0 : HP;
    }
    public void Heal(int val)
    {
        HP += val;
        HP = HP < 0 ? 0 : HP;
    }
*/