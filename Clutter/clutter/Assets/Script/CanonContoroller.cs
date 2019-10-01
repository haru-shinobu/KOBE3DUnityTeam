using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonContoroller : MonoBehaviour
{
    public GameObject player;
    public bool BangFlag;
    Vector3 pos;
    /*
    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")]
    private GameObject ThrowingObject;


    [SerializeField, Tooltip("標的のオブジェクトをここに割り当てる")]
    private GameObject TargetObject;


    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;
    */


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

        /*        Vector3 vel = this.transform.forward * 100;
                float angle = throwAngle;
        */
        if (Input.GetKey(KeyCode.Space) && BangFlag)
        {
            pos.y = 21;
            player.transform.position = pos;
            player.GetComponent<Rigidbody>().isKinematic = false;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0f, 10f, 0f);
            rb.AddForce(Vector3.forward * 100.0f + force, ForceMode.Impulse);
            BangFlag = false;

            /*
                // マウス左クリックでボールを射出する
            ThrowingBall();
    
         */
        }
    }
    /*
    private void ThrowingBall()
    {
        
        if (ThrowingObject != null && TargetObject != null)
        {
            // Ballオブジェクトの生成
            GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // 標的の座標
            Vector3 targetPosition = TargetObject.transform.position;

            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
            Rigidbody rid = ball.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
    */
}


