﻿using UnityEngine;

namespace _DroppyTower
{
    public class Character : MonoBehaviour
    {
        public int characterSequenceNumber;
        public string characterName;
        public int price;
        public bool isFree = false;

        public bool IsUnlocked
        {
            get
            {
                return true;
            }
        }

        void Awake()
        {
            characterName = characterName.ToUpper();
        }

        public bool Unlock()
        {
            if (IsUnlocked)
                return true;

            if (CoinManager.Instance.Coins >= price)
            {
                PlayerPrefs.SetInt(characterName, 1);
                PlayerPrefs.Save();
                CoinManager.Instance.RemoveCoins(price);

                return true;
            }

            return false;
        }
    }
}