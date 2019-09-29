using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManeger : MonoBehaviour
{
    [SerializeField]
    private GameObject MainCamera;
    [SerializeField]
    private GameObject firstPersonCamera;   // インスペクターで主観カメラを紐づける
    [SerializeField]
    private GameObject thirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける
    [SerializeField]
    private GameObject CanonCamera;

    public GameObject Canon_Sphere;
    CanonContoroller script;


    // Start is called before the first frame update
    void Start()
    {
        MainCamera.SetActive(false);
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        CanonCamera.SetActive(false);
        Canon_Sphere = GameObject.Find("Canon_Sphere");
        script = Canon_Sphere.GetComponent<CanonContoroller>();
    }

    // Update is called once per frame
    void Update()
    {
        //        bool flag = script.BangFlag;

        if (script.BangFlag)
        {
            MainCamera.SetActive(false);
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(false);
            CanonCamera.SetActive(true);
        }
        else
        {
            // キーでカメラを切り替える
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MainCamera.SetActive(true);
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(false);

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MainCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
                thirdPersonCamera.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                MainCamera.SetActive(false);
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
            }
        }
    }
}
