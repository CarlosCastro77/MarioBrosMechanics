using UnityEngine;

public class GoombaBehavior : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private bool isGoingRight = true;

    void Start()
    {
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 directionTranslation = isGoingRight ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * moveSpeed;

        transform.Translate(directionTranslation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Floor")
        {
            isGoingRight = !isGoingRight;
        }
    }
}
