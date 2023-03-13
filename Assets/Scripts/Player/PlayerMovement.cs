using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 5)] private float speed;
    [SerializeField, Range(0, 1)] private float moveInertiaMultiplier;
    Vector2 previousVelocity;
    [SerializeField, Range(0, 360)] private float maxRotationSpeed;
    [SerializeField, Range(0, 10)] private float rotationInertiaMultiplier;
    float previousAngularVelocity;
    Rigidbody2D rb;
    Vector2 input;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void SetInput(float horizontal, float vertical)
    {
        input = new Vector2((int)horizontal, (int)Mathf.Clamp(vertical, 0, 1));
    }

    void FixedUpdate()
    {
        if (input.y != 0)
            move();
        else if (rb.velocity != Vector2.zero)
            stopMovement();

        if (input.x != 0)
            rotate();
        else if (rb.angularVelocity != 0)
            stopRotation();
    }

    void move()
    {
        rb.AddForce(transform.up * speed * input.y, ForceMode2D.Force);
    }

    void stopMovement()
    {
        float x = 0, y = 0;
        if (rb.velocity.x > 0)
            x = Mathf.Clamp(rb.velocity.x - moveInertiaMultiplier, 0, rb.velocity.x);
        else if (rb.velocity.x < 0)
            x = Mathf.Clamp(rb.velocity.x + moveInertiaMultiplier, rb.velocity.x, 0);
        if (rb.velocity.y > 0)
            y = Mathf.Clamp(rb.velocity.y - moveInertiaMultiplier, 0, rb.velocity.y);
        else if (rb.velocity.y < 0)
            y = Mathf.Clamp(rb.velocity.y + moveInertiaMultiplier, rb.velocity.y, 0);
        rb.velocity = new Vector2(x, y);
    }

    void rotate()
    {
        float newVel = 0;
        if (input.x > 0)
            newVel = Mathf.Clamp(rb.angularVelocity - rotationInertiaMultiplier, -maxRotationSpeed, rb.angularVelocity);
        else if (input.x < 0)
            newVel = Mathf.Clamp(rb.angularVelocity + rotationInertiaMultiplier, rb.angularVelocity, maxRotationSpeed);
        rb.angularVelocity = newVel;
    }

    void stopRotation()
    {
        float newVel = 0;
        if (rb.angularVelocity > 0)
            newVel = Mathf.Clamp(rb.angularVelocity - rotationInertiaMultiplier, 0, rb.angularVelocity);
        else if (rb.angularVelocity < 0)
            newVel = Mathf.Clamp(rb.angularVelocity + rotationInertiaMultiplier, rb.angularVelocity, 0);
        rb.angularVelocity = newVel;
    }
}
