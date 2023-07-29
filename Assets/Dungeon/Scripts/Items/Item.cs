using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonKIT
{
    public enum ItemType { Item, Key, Coin }

    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : MonoBehaviour
    {
        public ItemType type; //Item type

        public delegate void PickedUpAction(); //Delegate for Pick up item
        public event PickedUpAction onPickedUp; //Pick up event

        public virtual void OnTriggerEnter2D(Collider2D collision) //If player entered in trigger
        {
            if (collision.gameObject.tag == "Player") //if its player
            {
                onPickedUp(); //Event

                switch (type)
                {
                    case ItemType.Item:
                        AudioManager.Instance.Play(PlayerStats.Instance.audioSource, AudioManager.Instance.pickUpItems, false); //play pickup item sound
                        break;
                    case ItemType.Key:
                        AudioManager.Instance.Play(PlayerStats.Instance.audioSource, AudioManager.Instance.pickUpKey, false); //play pickup key sound
                        break;
                    case ItemType.Coin:
                        AudioManager.Instance.Play(PlayerStats.Instance.audioSource, AudioManager.Instance.pickUpCoin, false); //play pickup coin sound
                        break;
                }

                Destroy(gameObject); // Destroy this GameObject
            }
        }

    }
}