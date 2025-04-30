using UnityEngine;

public class BasicParameter : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    float size = 1f;
    float physical = 20;
    float hp = 100;
    

    public float MoveSpeed { get => speed; set => speed = value; }

    public Vector3 NaturalSize()
    {
        return new Vector3(size, size);
    }
}
