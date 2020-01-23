using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showAddTask : MonoBehaviour
{

    public Animator anim;

    public void show()
    {
        // runs the animation that shows the panel in which one can add a task
        anim.SetBool("isShown", true);
        Debug.Log("yes it is shown");

    }
    public void hide()
    {
        // hides the panel described above
        anim.SetBool("isShown", false);

    }

}
