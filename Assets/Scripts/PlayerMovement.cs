using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tf;

    private float canJump = 0f;

    public float Xforce = 5000f;
    public float Zforce = 5000f;
    public float Yforce = 1400f;

    public float Xangle = 5f;
    public float Zangle = 5f;
    public float Yangle = 5f;

    public GameManager GM;

    bool isGrounded = false;
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if (Input.GetKey("d"))
        { rb.AddForce(Xforce * Time.deltaTime, 0, 0); }
        if (Input.GetKey("a"))
        { rb.AddForce(-Xforce * Time.deltaTime, 0, 0); }
        if (Input.GetKey("w"))
        { rb.AddForce(0, 0, Zforce * Time.deltaTime); }
        if (Input.GetKey("s"))
        { rb.AddForce(0, 0, -Zforce * Time.deltaTime); }
        if (Input.GetKey("space") && Time.time > canJump && isGrounded == true)
        {
            rb.AddForce(0, Yforce, 0); 
            canJump = Time.time + 0.5f;
        }

        if (Input.GetKey("q"))
        { tf.Rotate(0, Yangle, 0); }
        if (Input.GetKey("e"))
        { tf.Rotate(0, -Yangle, 0); }
        if (Input.GetKey("c"))
        { tf.Rotate(0, 0, Zangle); }
        if (Input.GetKey("v"))
        { tf.Rotate(0, 0, -Zangle); }
        if (Input.GetKey("x"))
        { tf.Rotate(Xangle, 0, 0); }
        if (Input.GetKey("z"))
        { tf.Rotate(-Xangle, 0, 0); }

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Lava")
        { FindObjectOfType<GameManager>().EndGame(); }
    }


    void OnCollisionStay(Collision collisionInfo)
    {
          if (collisionInfo.gameObject.tag == "Ground")
          { isGrounded = true; }
          
    }

    void OnCollisionExit(Collision collisionInfo)
    {
          if (collisionInfo.gameObject.tag == "Ground")
          { isGrounded = false; }
        
    }
}
