using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Moving;
    [SerializeField]
    private TextMeshProUGUI m_text;
    [SerializeField]
    private GameObject m_Net;

    public float m_score;

    public float m_yPos;

    void Start()
    {
        m_score = 0;
    }
    void Update()
    {
        m_text.text = m_score.ToString();
        if(m_score < 0)
        {
            m_score = 0;
        }

        m_Moving.transform.position = new Vector3(transform.position.x, m_yPos, transform.position.z);
    }
}
