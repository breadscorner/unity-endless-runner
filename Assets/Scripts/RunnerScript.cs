using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RunnerScript : MonoBehaviour
{
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isAlive = true;
    private Rigidbody2D RB;
    private Animator anim;

    [SerializeField] public TextMeshProUGUI ScoreText;
    public float JumpForce;
    float score;

    public float GetScore()
    {
        return score;
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
        Time.timeScale = 1f;
    }

    private void Jump()
    {
        if (isGrounded && isAlive)
        {
            // RB.AddForce(Vector2.up * JumpForce);
            float limitedJumpForce = Mathf.Clamp(JumpForce, 5f, 15f); // Adjust values as needed
            RB.linearVelocity = new Vector2(RB.linearVelocity.x, limitedJumpForce);

            anim.SetTrigger("isJumping");
            isGrounded = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isAlive)
        {
            Jump();
        }
        if (isAlive)
        {
            score += Time.deltaTime * 2;
            ScoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.ResetTrigger("isJumping");
            anim.SetTrigger("isIdle");
        }
        // else if (collision.gameObject.CompareTag("NextHurdle"))
        // {
        //     isAlive = false;
        //     // anim.SetTrigger("isHurt");
        // }
    }
}
