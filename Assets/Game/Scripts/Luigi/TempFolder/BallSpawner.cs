using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private ObjectPooler m_objectpool;

    private float m_spawnTimer;
    public float m_startSpawnTimer;

    private float m_decision;

    void Start()
    {
        m_objectpool = ObjectPooler.Instance;
        m_spawnTimer = m_startSpawnTimer;
        m_decision = 0;
    }
    void Update()
    {
        if (m_spawnTimer <= 0 && m_decision == 0)
        {
            m_decision = 1;
            m_objectpool.SpawnFromPool("GoodBall", transform.position, Quaternion.identity);
            m_spawnTimer = m_startSpawnTimer;
        }
        else if (m_spawnTimer <= 0 && m_decision == 1)
        {
            m_decision = Random.Range(0, 1);
            m_objectpool.SpawnFromPool("BadBall", transform.position, Quaternion.identity);
            m_spawnTimer = m_startSpawnTimer;
        }
        else
        {
            m_spawnTimer -= Time.deltaTime;
        }
    }
}
