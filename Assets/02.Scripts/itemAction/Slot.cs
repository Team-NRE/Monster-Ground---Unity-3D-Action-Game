using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Image image;

    private Item _item;
    private int itemCount;
    private Text text_Count;

    //유니티의 참조는 인스턴스에 의해 이루어진다.
    private effectItem _effectItem;

    public Item item    //아이템 프로퍼티로 획득한 아이템을 slot상에 표시
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();
        if (itemCount <= 0)
            ClearSlot();
    }

    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        image.sprite = null;

        text_Count.text = "0";
    }

    public void OnPointerClick()//UnityEngine.EventSystem에서 받아온 파라미터
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Consume)
                {
                    _effectItem.UseItem(item);
                    Debug.Log("소비형 아이템을 소비했습니다");
                }
            }
        }
    }
}
