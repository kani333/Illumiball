using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかタグで指定
    public string targetTag;
    bool _isHolding;

    public bool IsHolding()
    {
        return _isHolding;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            _isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            _isHolding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //コライダーに触れているオブジェクトのRigidbodyを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;

        direction.Normalize();

        //タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag)
        {
            //中心地点でボールを止めるため速度を減速させる
            r.linearVelocity *= 0.9f;
            r.AddForce(direction * -20f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80f, ForceMode.Acceleration);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
