using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initiliazed = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initiliazed; }
    }
    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initiliazed = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Click,
            Resources.Load<AudioClip>("Click"));
        audioClips.Add(AudioClipName.Hit,
            Resources.Load<AudioClip>("Hit"));
        audioClips.Add(AudioClipName.Spawn,
            Resources.Load<AudioClip>("Spawn"));
        audioClips.Add(AudioClipName.Speedup,
            Resources.Load<AudioClip>("Speedup"));
        audioClips.Add(AudioClipName.Freezer,
            Resources.Load<AudioClip>("Freezer"));
        audioClips.Add(AudioClipName.LoseBall,
            Resources.Load<AudioClip>("LoseBall"));
        audioClips.Add(AudioClipName.SpeedupDeactivated,
            Resources.Load<AudioClip>("SpeedupDeactivated"));
        audioClips.Add(AudioClipName.FreezerDeactivated,
            Resources.Load<AudioClip>("FreezerDeactivated"));
        audioClips.Add(AudioClipName.LoseGame,
            Resources.Load<AudioClip>("LoseGame"));
    }
    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
