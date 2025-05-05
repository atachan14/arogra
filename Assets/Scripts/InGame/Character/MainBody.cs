using UnityEditor.Build;
using UnityEngine;

public class MainBody : MonoBehaviour
{
    bool alive = true; 
    public bool Alive
    { 
        get => alive;
        set
        {
            alive = value;
            if (!value) DeadFlow();
        }
    }

    void DeadFlow()
    {
        Debug.Log($"Ž„‚ÍŽ€‚ñ‚¾{this}");
    }

}
