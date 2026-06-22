using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1f;
    public float distanceFromCamera = 20f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip cloudSE;
    [SerializeField] public float minInterval = 1f;
    [SerializeField] public float maxInterval = 3f;

    private Camera cam;
    private float nextPlayTime;

    void Start()
    {
        cam = Camera.main;

        ScheduleNextSound();
    }

    void Update()
    {
        // 左へ移動
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // カメラより左へ行きすぎたら右へ戻す
        if (transform.position.x < cam.transform.position.x - distanceFromCamera)
        {
            Vector3 pos = transform.position;
            pos.x = cam.transform.position.x + distanceFromCamera;
            transform.position = pos;
        }

        // ランダム間隔で音を鳴らす
        if (Time.time >= nextPlayTime)
        {
            audioSource.PlayOneShot(cloudSE,3f);
            ScheduleNextSound();
        }
    }

    private void ScheduleNextSound()
    {
        nextPlayTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}