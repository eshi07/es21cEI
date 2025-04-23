using UnityEngine;

public class SawHitAudioChanger : MonoBehaviour
{
    public AudioClip newClip; // Assign the new audio clip in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        ChangeBGM();
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeBGM();
    }

    private void ChangeBGM()
    {
        GameObject bgmObject = GameObject.FindGameObjectWithTag("bgm");
        if (bgmObject != null)
        {
            AudioSource audioSource = bgmObject.GetComponent<AudioSource>();
            if (audioSource != null && newClip != null)
            {
                audioSource.clip = newClip;
                audioSource.Play();
            }
        }
    }
}
