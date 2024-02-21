using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class SFXManager : MonoBehaviour
    {
        [SerializeField] private AudioSource sfxObjectPrefab;
        
        public void PlayRandomSoundEffect(AudioClip[] audioClips, Transform spawnTransform, float volume)
        {
            // Instantiate sound effect object
            AudioSource audioSource = Instantiate(sfxObjectPrefab, spawnTransform.position, Quaternion.identity);

            // Pick a random sound effect from the array
            int index = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[index];

            // Get the clip's length
            float clipLength = audioSource.clip.length;

            // Set the volume
            audioSource.volume = volume;

            // Play the sound effect
            audioSource.Play();

            // Destroy the sound effect object after the clip finishes playing
            Destroy(audioSource.gameObject, clipLength);
        }
    }
}
