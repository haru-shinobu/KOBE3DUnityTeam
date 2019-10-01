using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{

    [SerializeField]
    private GameObject MainCamera;
    [SerializeField]
    private GameObject thirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける
    [SerializeField]
    private GameObject CanonCamera;

    public float moveSpeed;//10?
    public float JampForce;//1000?
    float Speed;
    bool Ground = true;
    float inputHorizontal;
    float inputVertical;
    float inputJamp;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed = moveSpeed;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


    }
    //接触した瞬間
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            Ground = true;
        }
        if (col.gameObject.tag == "Carpet")
        {
            Speed = moveSpeed * 0.5f;
        }
    }
    //離れた瞬間
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Carpet")
        {
            Speed = moveSpeed;
        }
        if (col.gameObject.tag == "Canon_Sphere")
        {
            Ground = false;
        }
    }

    void LateUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * Speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きは、サードパーソンカメラが有効な時だけ変更する
        if (moveForward != Vector3.zero)
        {
            if (thirdPersonCamera.activeInHierarchy && CanonCamera.activeInHierarchy)
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

        //ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Ground)
            {
                Ground = false;
                Vector3 force = new Vector3(0f, JampForce, 0f);
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
        if (!Ground)
        {
            rb.AddForce(0, -1f, 0);
        }
    }
}