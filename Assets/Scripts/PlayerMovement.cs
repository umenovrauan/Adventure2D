using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        //flip player start
        if(horizontalInput>0.01f)
        {
            transform.localScale = Vector3.one;
        } else if(horizontalInput<-0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        //flip player end

        //Jump start
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
        }
        //Jump end

        //anim parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
