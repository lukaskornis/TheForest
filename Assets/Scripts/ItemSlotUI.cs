using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
   [SerializeField]private Image icon;
   [SerializeField]private TMP_Text stackCountText;
   
   public void UpdateUI(Item item)
   {
      stackCountText.text = item.stackSize.ToString();
      icon.sprite = item.data.icon;
   }
}
