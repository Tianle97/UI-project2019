using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SceneGUI : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    // Draw some basic instructions.
    void OnGUI()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (!hub.hubInitialized)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "\n\n\nCannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        }
        else if (!thalmicMyo.isPaired)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "\n\n\nNo Myo currently paired."
            );
        }
        else if (!thalmicMyo.armSynced)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "\n\n\nPerform the Sync Gesture."
            );
        }
        else
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "\n\nFist: release ball.\n" +
                "Wave in: turn left\n" +
                "Wave out: turn right\n"
            );
        }
    }

    void Update()
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (Input.GetKeyDown("q"))
        {
            hub.ResetHub();
        }
    }
}
