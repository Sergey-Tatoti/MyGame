using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
  [SerializeField] private List<Skin> _skin;
  [SerializeField] private Player _player;
  [SerializeField] private PlayerLook _playerLook;
  [SerializeField] private GameObject _itemConteiner;
  [SerializeField] private SkinView _template;

    private void Awake()
  {
    for (int i = 0; i < _skin.Count; i++)
    {
      AddItem(_skin[i]);
    }
  }
    private void AddItem(Skin skin)
  {
    var view = Instantiate(_template, _itemConteiner.transform);

    view.SellButtonClick += OnSellButtonClick;
    view.EquipButtonClick += OnEquipButtonClick;

    view.Render(skin);
  }

  private void OnSellButtonClick(Skin skin, SkinView view)
  {
    if(SceneManager.GetActiveScene().buildIndex == 0)
    TrySellSkin(skin, view);
  }

    private void OnEquipButtonClick(Skin skin, SkinView view)
  {
    TryEquipSkin(skin, view);
  }

  private void TrySellSkin(Skin skin, SkinView view)
  {
    if (skin.Price <= _player.CountCrystals)
    {
      _player.BuySkin(skin);
      skin.Buy();
      view.SellButtonClick -= OnSellButtonClick;
    }
  }

    private void TryEquipSkin(Skin skin, SkinView view)
  {
    if (skin != _playerLook.CurrentSkin)
    {
      _playerLook.ChangeSkin(skin);
    }
  }
}
