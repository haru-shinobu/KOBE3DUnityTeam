using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraContoroller : MonoBehaviour
{
    public GameObject player;
    Vector3 targetPos;
    void Update()
    {
        targetPos = player.transform.position;
        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
        }
    }
}
