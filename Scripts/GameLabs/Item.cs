using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New item", menuName = "Item")]
public class Item : ScriptableObject {
    public string itemName;
    public Texture2D icon;
    public Bar[] bars;
    public Action[] onEquip;

    void Equip () {
        foreach (var item in onEquip)
        {
            item.Invoke();
        }
    }
}