using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    public AudioSource Source;
    public AudioSource EffectSource;
    public void PlayMusic(AudioClip clip)
    {
        Source.clip = clip;
        Source.Stop();
        Source.Play();
    }
    public void PlayEffect(AudioClip clip)
    {
        EffectSource.clip = clip;
        EffectSource.Stop();
        EffectSource.Play();
    }
}