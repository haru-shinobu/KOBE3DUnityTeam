using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonCamera : MonoBehaviour
{
    public GameObject Canon_shaft;
    Vector3 targetPos;
    void Start()
    {
        Canon_shaft = GameObject.Find("Canon_shaft");
        targetPos = Canon_shaft.transform.position;
    }

    void Update()
    {

        // targetの移動量分、自分（カメラ）も移動する
        transform.position /*+*/= /*Canon_shaft.transform.position -*/ targetPos;
        targetPos = Canon_shaft.transform.position;


        // マウスの右クリックを押している間
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            float InputX = 0;
            float InputY = 0;
            if (Input.GetKey(KeyCode.A))
            {
                InputX = 1;
            }
            else
            if (Input.GetKey(KeyCode.S))
            {
                InputX = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                InputY = 1;
            }
            else
                if (Input.GetKey(KeyCode.W))
            {
                InputY = -1;
            }
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, InputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(targetPos, transform.right, InputY * Time.deltaTime * 200f);
        }
    }
}
