using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private EnemySpawner eS;
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void SetPlayer(Transform playerTransform, EnemySpawner enemySpawner)
    {
        player = playerTransform;
        eS = enemySpawner;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Bullet"))
            eS.EnemyDied();
        if (col.transform.CompareTag("Player") || col.transform.CompareTag("Bullet"))
            Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        eS.EnemyDestroyed(this.gameObject);
    }
}
