using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f, jumpForce = 5f;

    public Rigidbody2D rigidBody;
    public Vector2 _moveVector;
    public bool jumpRequested = false;
    public bool isGrounded = false;

    public int health = 3;
    public TMP_Text healthUI;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = _moveVector.x * moveSpeed;
        if(jumpRequested && isGrounded)
        {
            isGrounded = false;
            rigidBody.linearVelocityY = jumpForce;
            jumpRequested = false;
        }

        if(health <= 0)
        {
            Debug.Log("you died");
            SceneManager.LoadScene("Death Screen", LoadSceneMode.Single);
        }
    }

    public void Move(Vector2 moveVector)
    {
        _moveVector = moveVector;
    }

    public void Jump()
    {
        jumpRequested = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            healthUI.text = ("Health: " + health).ToString();

            Destroy(collision.gameObject);
        }

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            Debug.Log("hello");
        }
    }
}
