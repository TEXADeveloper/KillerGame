using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public static event Action GameFinished;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D[] colliders;
    private float spawnCooldown;
    float cooldown;
    [SerializeField] private int maxEnemiesAmount;
    private int enemiesAmount;
    List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private GameMode gameModeConfig;
    [SerializeField] private TMP_Text enemiesLeft;
    private int killedEnemies = 0;

    void Start()
    {
        enemiesLeft.text = getEnemiesObjective().ToString();
        spawnCooldown = getSpawnCooldown();
    }

    void Update()
    {
        if (cooldown <= 0 && enemiesAmount < maxEnemiesAmount)
            spawnEnemy();
        cooldown -= Time.deltaTime;
    }

    private void spawnEnemy()
    {
        cooldown = spawnCooldown;
        Vector2 position = getPosition();
        GameObject go = GameObject.Instantiate(enemyPrefab, position, Quaternion.identity, this.transform);
        enemies.Add(go);
        go.GetComponent<EnemyAI>().SetPlayer(player, this);
        enemiesAmount++;
    }

    private Vector2 getPosition()
    {
        float x = 0;
        float y = 0;
        BoxCollider2D bc = colliders[UnityEngine.Random.Range(0, colliders.Length)];
        x = UnityEngine.Random.Range(bc.bounds.min.x, bc.bounds.max.x);
        y = UnityEngine.Random.Range(bc.bounds.min.y, bc.bounds.max.y);

        return new Vector2(x, y);
    }

    private float getSpawnCooldown()
    {
        ConfigData data = SaveAndLoadGame.LoadConfig();
        if (data == null)
            return gameModeConfig.spawnCooldown[0]; ;
        int dificulty = data.dificulty;

        return gameModeConfig.spawnCooldown[dificulty];
    }

    private int getEnemiesObjective()
    {
        ConfigData data = SaveAndLoadGame.LoadConfig();
        if (data == null)
            return gameModeConfig.killObjective[0];
        int dificulty = data.dificulty;

        return gameModeConfig.killObjective[dificulty];
    }

    public void EnemyDied()
    {
        killedEnemies++;
        enemiesLeft.text = (getEnemiesObjective() - killedEnemies).ToString();
        if (killedEnemies >= getEnemiesObjective())
            GameFinished?.Invoke();
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        enemiesAmount--;
        enemies.Remove(enemy);
    }
}
