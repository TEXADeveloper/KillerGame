using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float force;
    private Rigidbody2D rb;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        impulse();
        Destroy(this.gameObject, time);
    }

    void impulse()
    {
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}