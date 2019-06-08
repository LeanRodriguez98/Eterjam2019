using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Game : MonoBehaviour {

    public Slider slider;
    public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.enabled && slider.enabled)
            slider.value = player.stats.life;
	}
}
