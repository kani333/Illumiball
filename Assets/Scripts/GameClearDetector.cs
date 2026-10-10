using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public Hole HoleRed;
    public Hole HoleBlue;
    public Hole HoleGreen;

    private void OnGUI()
    {
        // 全てのボールが入ったらラベル表示
        if(HoleRed.IsHolding() && HoleBlue.IsHolding() && HoleGreen.IsHolding())
        {
            // 文字を見やすくするためサイズを調整
            GUI.matrix = Matrix4x4.Scale(Vector3.one * 2.0f);
            GUI.Label(new Rect(50, 50 ,100, 30), "Game Clear!");
        }
    }
}
