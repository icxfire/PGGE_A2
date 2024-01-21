using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStepSounds : MonoBehaviour
{
    // we create arrays to insert our audioclips for the specific materials
    [SerializeField] private AudioClip[] concreteSound;
    [SerializeField] private AudioClip[] dirtSound;
    [SerializeField] private AudioClip[] metalSound;
    [SerializeField] private AudioClip[] sandSound;
    [SerializeField] private AudioClip[] woodSound;
    [SerializeField] private AudioClip[] freddy;

    // we also create a bool array to check for the material type the player is standing on
    [SerializeField] private bool[] material;

    // two audio sourcecs are used to create a deeper sound
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource audio2;

    private int i;
    private int index;
    private int j;
    private int index2;
    private float audioVolume;
    private float audioVolume2;
    private int fazbear; // joke sound :)
    private float pitchShift;

    // Start is called before the first frame update
    void Start()
    {
        // initialises the materials as false on start. We will set them to true on trigger stay
        material[0] = false;
        material[1] = false;
        material[2] = false;
        material[3] = false;
        material[4] = false;
        material[5] = false;
    }

    void Update()
    {
    }

    // animation event that occurs when the players foot touches the floor
    private void step()
    {
        randomPitch();
        audio.volume = audioVolume;
        audio2.volume = audioVolume2;

        if (material[0] == true)
        {
            // we play 2 sounds at the same time to create a deeper sound
            audio.PlayOneShot(concreteSound[index]);
            audio2.PlayOneShot(concreteSound[index2]);
            // we also change the pitch to give more of a variation to the sound type
            audio.pitch = pitchShift;
        }

        if (material[1] == true)
        {
            audio.PlayOneShot(dirtSound[index]);
            audio2.PlayOneShot(dirtSound[index2]);
            audio.pitch = pitchShift;
        }

        if (material[2] == true)
        {
            audio.PlayOneShot(metalSound[index]);
            audio2.PlayOneShot(metalSound[index2]);
            audio.pitch = pitchShift;
        }

        if (material[3] == true)
        {
            audio.PlayOneShot(sandSound[index]);
            audio2.PlayOneShot(sandSound[index2]);
            audio.pitch = pitchShift;
        }

        if (material[4] == true)
        {
            audio.PlayOneShot(woodSound[index]);
            audio2.PlayOneShot(woodSound[index2]);
            audio.pitch = pitchShift;
        }

        if (material[5] == true)
        {
            audio.pitch = 1;
            audio.PlayOneShot(freddy[fazbear]);
        }
    }

    void OnTriggerStay(Collider other)
    {
        // we call this while the player is on a collider to randomise the sound each footstep makes
        if (other.gameObject.CompareTag("concrete")) // compares the tag with the 
        {
            randomNumber();
            if (i <= 3 && j <= 3 && i != j) // keeps the values in the array range, we also dont want the sounds to be the same
            {
                material[0] = true; // sets the bool in the array to true to play the sounds.
                index = i; // sets the index to use in the array
                index2 = j;
            } 
            else
            {
                randomNumber(); // randomises the number aghain if it doesnt fit the criteria above
            }
        }

        if (other.gameObject.CompareTag("dirt"))
        {
            randomNumber();
            if (i <= 3 && j <= 3 && i != j)
            {
                material[1] = true;
                index = i;
                index2 = j;
            }
            else
            {
                randomNumber();
            }
        }

        if (other.gameObject.CompareTag("metal"))
        {
            randomNumber();
            if (i <= 3 && j <= 3 && i != j)
            {
                material[2] = true;
                index = i;
                index2 = j;
            }
            else
            {
                randomNumber();
            }
        }

        if (other.gameObject.CompareTag("sand"))
        {
            randomNumber();
            if (i <= 3 && j <= 3 && i != j)
            {
                material[3] = true;
                index = i;
                index2 = j;
            }
            else
            {
                randomNumber();
            }
        }

        if (other.gameObject.CompareTag("wood"))
        {
            randomNumber();
            if (i <= 5 && j <= 5 && i != j)
            {
                material[4] = true;
                index = i;
                index2 = j;
            }
            else
            {
                randomNumber();
            }
        }

    }

    void OnTriggerEnter(Collider other) // for a joke sound, if you wanna hear it then you can run over the png file in game ( I did not showcase this in video )
    {
        if (other.gameObject.CompareTag("freddy"))
        {
            pitchShift = 1;
            audio.volume = 1;
            audio2.volume = 1;
            material[5] = true;
            step();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("concrete") && material[0])
        {
            material[0] = false; // we set the material back to false only if the material is true wwhen exitting the collider
        }

        if (other.gameObject.CompareTag("dirt") && material[1])
        {
            material[1] = false;
        }

        if (other.gameObject.CompareTag("metal") && material[2])
        {
            material[2] = false;
        }

        if (other.gameObject.CompareTag("sand") && material[3])
        {
            material[3] = false;
        }

        if (other.gameObject.CompareTag("wood") && material[4])
        {
            material[4] = false;
        }

        if (other.gameObject.CompareTag("freddy") && material[5])
        {
            if (fazbear <= 9)
            {
                fazbear++;
            }
            else
            {
                fazbear = 0;
            }
            material[5] = false;
        }

        audio.volume = 1;
        audio2.volume = 1;
        pitchShift = 1;
    }

    void randomNumber()
    {
        i = Random.Range(0, 5); // changes the index, the reason why index range is higher than some array ranges is to account for wood, which has more audio clips than other materials
        j = Random.Range(0, 5);
        audioVolume = Random.Range(0.5f, 1); //  changes the volumes
        audioVolume2 = Random.Range(0.5f, 1);
    }

    void randomPitch()
    {
        if (pitchShift != 0)
        {
            pitchShift = Random.Range(0.5f, 1.5f); // changes the pitch, I dont know why i made a separate function
        }
        else
        {
            pitchShift = 1;
        }

    }

}
