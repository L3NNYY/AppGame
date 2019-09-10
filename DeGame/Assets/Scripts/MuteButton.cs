using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private Image image;
    public Sprite mutedButtonSprite;
    public Sprite unmutedButtonSprite;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioListener.pause == false)
        {
            image.sprite = unmutedButtonSprite;
        }
        else if (AudioListener.pause == true)
        {
            image.sprite = mutedButtonSprite;
        }
    }
}
