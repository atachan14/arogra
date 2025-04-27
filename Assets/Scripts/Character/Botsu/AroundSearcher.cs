using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AroundSearcher : MonoBehaviour
{
    [SerializeField] GameObject Combat;
    [SerializeField] NextPos nextPos;
    List<GameObject> TargetList { get; } = new List<GameObject>();
    GameObject FirstTarget { get; set; }
    float FirstTargetDistance { get; set; }

    void Update()
    {
        TargetList.RemoveAll(target => target == null);

        if (TargetList.Count > 0)
        {
            SelectFirstTarget();
        }
        else
        {
            FirstTarget = null;
        }
    }

    void SelectFirstTarget()
    {
        FirstTargetDistance = float.MinValue;

        foreach (GameObject target in TargetList)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance > FirstTargetDistance)
            {
                FirstTarget = target;
                FirstTargetDistance = distance;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((CompareTag("PlayerCharacter") && collision.CompareTag("EnemyCharacter"))
         || (CompareTag("EnemyCharacter") && collision.CompareTag("PlayerCharacter")))
        {
            if (!TargetList.Contains(collision.gameObject))
                TargetList.Add(collision.gameObject);
        }
    }
}
