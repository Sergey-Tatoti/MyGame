using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SkinView : MonoBehaviour
{
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _EquipButton;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _buyStatus;
    private Skin _skin;

    public UnityAction<Skin, SkinView> SellButtonClick;
    public UnityAction<Skin, SkinView> EquipButtonClick;


    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryUnLockItem);
        _EquipButton.onClick.AddListener(OnEquipButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryUnLockItem);
        _EquipButton.onClick.RemoveListener(OnEquipButtonClick);
    }

    private void TryUnLockItem()
    {
        if (_skin.IsBuyed == true)
        {
            RenderBuying();
        }
    }

    public void Render(Skin skin)
    {
        _skin = skin;

        _icon.sprite = _skin.Icon;

        if (skin.IsBuyed == false)
            _price.text = _skin.Price.ToString();
        else
            RenderBuying();
    }

    private void RenderBuying()
    {
        _price.gameObject.SetActive(false);
        _sellButton.gameObject.SetActive(false);

        _buyStatus.gameObject.SetActive(true);
        _EquipButton.gameObject.SetActive(true);
    }

    public void OnButtonClick()
    {
        SellButtonClick?.Invoke(_skin, this);
    }

    public void OnEquipButtonClick()
    {
        EquipButtonClick?.Invoke(_skin, this);
    }
}
