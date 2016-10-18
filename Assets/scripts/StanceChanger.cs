using UnityEngine;
using System.Collections;

public class StanceChanger : MonoBehaviour
{
    public float MaxSpeed = 10f;
    float Stance = 0f;
    Animator anim;
	private GameObject monkeyArm;
    // Use this for initialization
	void Awake()
	{
		monkeyArm = GameObject.FindGameObjectWithTag("MonkeyArm");
		monkeyArm.GetComponent<Renderer>().enabled = false;
	}
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stance == 1f)
        {
            MaxSpeed = 2f;
        }
        else
        {
            MaxSpeed = 10f;
        }
        if (Stance == 2f)
        {

        }
        else
        {

        }
		if(Stance == 3f)
		{
			monkeyArm.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			monkeyArm.GetComponent<Renderer>().enabled = false;
		}
        // No Wings Stance
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Stance = 0f;
            anim.SetFloat("StanceChange", Stance);

        }
        // Bear Stance
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Stance = 1f;
            anim.SetFloat("StanceChange", Stance);

        }
        // Cat Stance
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Stance = 2f;
            anim.SetFloat("StanceChange", Stance);

        }
        //Monkey Stance
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Stance = 3f;
            anim.SetFloat("StanceChange", Stance);

        }
        //Attack
        if (Input.GetKeyDown(KeyCode.F) && Stance == 1f)
        {

            Invoke("Attack", 1); // Invoking attack = slow attack time for animation
        }
    }

}
