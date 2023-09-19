using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] private ShopView _shopView;

    public void ShowShop()
    {
        if (_shopView.gameObject.activeSelf == false)
            _shopView.gameObject.SetActive(true);
        else
            _shopView.gameObject.SetActive(false);
    }
}
