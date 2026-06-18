using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI; // UI操作に必要

public class BikeMove : MonoBehaviour
{
    public Rigidbody2D rearWheel; // 後輪（トルクをかける対象）

    public float motorSpeed = 10f; // 通常のスピード
    public float rotateSpeed = 20f; // 回転スピード

    // ===== ダッシュ関連 =====
    public float dashPower = 50f; // ダッシュ時の強さ

    // ===== DashPad =====
    public float dashPadPower = 100f; // DashPadの強さ
    public float dashPadTime = 2f; // DashPad継続時間

    private bool isDashPad = false;
    private float dashPadTimer = 0f;

    // ===== スタミナ =====
    public float maxStamina = 100f; // 最大スタミナ
    public float stamina; // 現在のスタミナ

    public float staminaUseRate = 10f; // ダッシュ中の消費速度
    public float staminaRecoverRate = 5f; // 通常回復速度
    public float overheatRecoverRate = 20f; // 使い切った後の回復速度（速い）

    private bool isOverheated = false; // スタミナ切れ状態かどうか

    // ===== UI =====
    public Image staminaBar; // スタミナゲージ（UI）

    private Rigidbody2D rb; // 本体

    // ===== Audio =====
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bellSE;//ベルSE

    [SerializeField] private AudioSource moveAudioSource;

    [SerializeField] private AudioClip moveSE;  // 通常走行
    [SerializeField] private AudioClip dashSE;  // ダッシュ
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 本体取得

        stamina = maxStamina; // スタミナを満タンにする
        
        moveAudioSource.loop = true;

    }
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            BikeBell();
        }

    }
    void FixedUpdate()
    {
        float moveInput = 0f;   // 前後入力
        float rotateInput = 0f; // 回転入力

        // ===== 入力処理 =====
        if (Keyboard.current.wKey.isPressed)
            moveInput = 1f;
        else if (Keyboard.current.sKey.isPressed)
            moveInput = -1f;

        if (Keyboard.current.aKey.isPressed)
            rotateInput = 1f;
        else if (Keyboard.current.dKey.isPressed)
            rotateInput = -1f;

        // Shiftが押されているか（ダッシュ判定）
        bool isDashing = Keyboard.current.leftShiftKey.isPressed;

        // ===== DashPadタイマー =====
        if (isDashPad)
        {
            dashPadTimer -= Time.fixedDeltaTime;

            if (dashPadTimer <= 0f)
            {
                isDashPad = false;
            }
        }

        // ===== スタミナ処理 =====
        if (isOverheated)
        {
            // スタミナ切れ中 → 高速回復
            stamina += overheatRecoverRate * Time.fixedDeltaTime;

            // 最大まで回復したら復帰
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                isOverheated = false;
            }
        }
        else
        {
            // ダッシュ中（かつ移動している時だけ消費）
            if (isDashing && stamina > 0f && moveInput != 0f)
            {
                stamina -= staminaUseRate * Time.fixedDeltaTime;

                // スタミナがなくなったらオーバーヒート
                if (stamina <= 0f)
                {
                    stamina = 0f;
                    isOverheated = true;
                }
            }
            else
            {
                // ダッシュしていない → 通常回復
                stamina += staminaRecoverRate * Time.fixedDeltaTime;

                // 最大値を超えないようにする
                stamina = Mathf.Min(stamina, maxStamina);
            }
        }

        // ===== 移動処理 =====
        if (!isOverheated) // スタミナ切れ中は移動不可
        {
            // DashPad中は勝手に前進
            if (isDashPad)
            {
                rearWheel.AddTorque(-dashPadPower);
            }
            else if (moveInput != 0f)
            {
                if (isDashing && stamina > 0f)
                {
                    // ダッシュ移動
                    rearWheel.AddTorque(-moveInput * dashPower);
                }
                else
                {
                    // 通常移動
                    rearWheel.AddTorque(-moveInput * motorSpeed);
                }
            }
        }

        // ===== 回転処理 =====
        // オーバーヒート中でも回転は可能
        if (rotateInput != 0f)
        {
            rb.AddTorque(rotateInput * rotateSpeed);
        }

        // ===== UI更新 =====
        // スタミナの割合（0～1）をゲージに反映
        if (staminaBar != null)
        {
            staminaBar.fillAmount = stamina / maxStamina;
        }
        // ===== 走行音 =====
        bool isMoving = rb.linearVelocity.magnitude > 0.5f;

        if (isMoving)
        {
            bool actuallyDashing =
                !isOverheated &&
                isDashing &&
                moveInput != 0f &&
                stamina > 0f;

            AudioClip targetClip = actuallyDashing ? dashSE : moveSE;

            if (moveAudioSource.clip != targetClip)
            {
                moveAudioSource.clip = targetClip;
            }

            if (!moveAudioSource.isPlaying)
            {
                moveAudioSource.loop = true;
                moveAudioSource.Play();
            }
        }
        else
        {
            moveAudioSource.Stop();
        }
    }

    // ===== DashPad開始 =====
    public void StartDashPad()
    {
        isDashPad = true;
        dashPadTimer = dashPadTime;
    }

    // ===== DashPadに触れた時 =====
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DashPad"))
        {
            StartDashPad();
        }
    }
    private void BikeBell()
    {

        Debug.Log("ベルを鳴らす");
        audioSource.PlayOneShot(bellSE, 2.0f);
    }
}