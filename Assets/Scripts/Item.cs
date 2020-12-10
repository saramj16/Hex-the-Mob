using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum Element {
        Water,
        Air,
        Fire,
        Earth,
        NUM_ELEM
    }

    public Element elem;
    public int amount;

    /*public Sprite GetSprite() {
        switch (elem) {
            default:
            case Element.Air:   return ItemAssets.Instance.airSprite;
            case Element.Earth: return ItemAssets.Instance.earthSprite;
            case Element.Water: return ItemAssets.Instance.waterSprite;
            case Element.Fire:  return ItemAssets.Instance.fireSprite;

        }
    }*/

}
