using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCooldown;
    float cooldown;

    public void ShootInput()
    {
        if (cooldown <= 0)
            shoot();
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void shoot()
    {
        cooldown = shootCooldown;
        GameObject go = GameObject.Instantiate(bullet, shootPoint.position, Quaternion.identity, bulletParent);
        go.transform.up = this.transform.up;
    }
}
