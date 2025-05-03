using System.Collections;
using UnityEngine;

public interface ISkillActor
{
    IEnumerator ActCoroutineFlow();

    public GameObject Target { get; set; }
}
