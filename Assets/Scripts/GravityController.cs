using UnityEngine;
using UnityEngine.InputSystem;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;

    //重力の適応具合
    public float gravityScale = 1.0f;
    InputAction _moveAction;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("move");
    
        // 加速度センサーを有効化
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }

    void Update()
    {
        Vector3 vector = new Vector3();
        if (Application.isMobilePlatform)
        {
            //モバイルの場合は加速度センサーの値を取得
            vector.x = Accelerometer.current.acceleration.ReadValue().x;
            vector.y = Accelerometer.current.acceleration.ReadValue().y;
            vector.z = Accelerometer.current.acceleration.ReadValue().z;
        }
        else
        {
            //キーの入力を検知しベクトルを設定
            vector.x = _moveAction.ReadValue<Vector2>().x;
            vector.z = _moveAction.ReadValue<Vector2>().y;

            //高さ方向の判定はキーのzとする
            if (Keyboard.current.zKey.isPressed)
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }

        //シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
