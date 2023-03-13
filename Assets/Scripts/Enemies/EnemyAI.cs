using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = player.position - transform.position;
        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2d(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            //QuitarVida
        }
    }
}
