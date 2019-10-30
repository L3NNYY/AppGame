using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    float masterVolumePercent = 1;
    float sfxVolumePercent = 1;
    float musicVolumePercent = 1;

    public static AudioManager instance;

    void Start(){
        if (GameObject.Find ("Audio Manager") 
                 && GameObject.Find ("Audio Manager") != this.gameObject)
                     {
                         Destroy (this.gameObject);
                     }
    }
    void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip, Vector3 pos) {
        if (clip != null) {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * masterVolumePercent);
        }
    }
}
