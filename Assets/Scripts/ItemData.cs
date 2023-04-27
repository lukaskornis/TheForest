using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string title = "Item";
    public Sprite icon;
    public GameObject toolPrefab;
    public GameObject dropPrefab;
}