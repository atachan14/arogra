using UnityEngine;

public class BasicParameter : MonoBehaviour
{
    [SerializeField] float hp = 100;
    [SerializeField] float physical = 1;
    [SerializeField] float agile = 3f;
    [SerializeField] float size = 1;
    
    
    

    public float MoveSpeed { get => agile; set => agile = value; }

    public Vector3 NaturalSize()
    {
        return new Vector3(size, size);
    }
}
