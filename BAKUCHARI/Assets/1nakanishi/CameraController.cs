using UnityEngine;

public class CameraController : MonoBehaviour
{
    // プレイヤー
    public GameObject player;

    // 前回のプレイヤー位置
    Vector3 prePlayerPos;

    void Update()
    {
        // プレイヤーの位置が変わったら
        if (player.transform.position != prePlayerPos)
        {
            // カメラをプレイヤー位置に合わせる
            transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y + 1, -10);

            // 現在のプレイヤー位置を保存
            prePlayerPos = player.transform.position;
        }
    }
}