﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
    public Character character;
    public enum Character {
        Player,
        Boss
    }

    private Player player;
    private Enemy boss;
    private Text txt;

	void Start () {
        txt = GetComponent<Text>();
        if (character == Character.Player) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        } else if (character == Character.Boss) {
            boss = GameObject.FindGameObjectWithTag("Capataz").GetComponent<Enemy>();
        }
    }
	
	void Update () {
        UpdateLifeTotal();
	}

    void UpdateLifeTotal() {
        if (character == Character.Player) {
            int health = (int)(player.health / Player.MaxHealth * 100);
            if (health < 0) {
                health = 0;
            }
            txt.text = health.ToString() + "%";

            if (health <= 20) {
                txt.color = new Color(1, 0.15f, 0.05f);
            } else if (health <= 40) {
                txt.color = new Color(0.9f, 0.6f, 0.3f);
            }
        } else if (character == Character.Boss) {
            int health = (int)(boss.health / boss.maxHealth * 100);
            if (health < 0) {
                health = 0;
            }
            txt.text = health.ToString() + "%";

            if (health <= 20) {
                txt.color = new Color(1, 0.15f, 0.05f);
            } else if (health <= 40) {
                txt.color = new Color(0.9f, 0.6f, 0.3f);
            }
        }
    }
}
