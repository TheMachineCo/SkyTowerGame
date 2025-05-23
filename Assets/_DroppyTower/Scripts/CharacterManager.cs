using UnityEngine;
using System.Collections;

namespace _DroppyTower
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance;

        public static readonly string CURRENT_CHARACTER_KEY = "SGLIB_CURRENT_CHARACTER";

        public int CurrentCharacterIndex
        {
            get
            {
                int currentIndex = PlayerPrefs.GetInt(CURRENT_CHARACTER_KEY, 0);
                return currentIndex;
            }
            set
            {
                PlayerPrefs.SetInt(CURRENT_CHARACTER_KEY, value);
                PlayerPrefs.Save();
            }
        }


        public GameObject[] characters;

        void Awake()
        {
            Instance = this;
        }
    }
}