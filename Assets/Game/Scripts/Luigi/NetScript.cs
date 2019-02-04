using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour
{
    [SerializeField]
    private GoalScript m_Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Good"))
        {
            m_Goal.GetComponent<GoalScript>().m_score += 1;
            m_Goal.GetComponent<GoalScript>().m_yPos = Random.Range(-4, 1);
        }
        else if (collision.CompareTag("Bad"))
        {
            m_Goal.GetComponent<GoalScript>().m_score -= 1;
        }
    }
}
