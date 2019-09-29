using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    //トリガー接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            // 何らかの処理
        }
        // 接触対象はRunbaタグですか？
        if (hit.CompareTag("Runba"))
        {

            // 何らかの処理
        }
    }
}
