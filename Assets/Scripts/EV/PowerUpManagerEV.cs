using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum PowerupIndex
{
    ORANGEMUSHROOM = 0,
    REDMUSHROOM = 1
}

public class PowerUpManagerEV : MonoBehaviour
{
    // reference of all player stats affected
    public IntVariable marioJumpSpeed;
    public IntVariable marioMaxSpeed;
    public PowerupInventory powerupInventory;
    public List<GameObject> powerupIcons;
    public List<KeyCode> powerupKeyCodes;
    // Start is called before the first frame update
    void Start()
    {
        if (!powerupInventory.gameStarted)
        {
            powerupInventory.gameStarted = true;
            powerupInventory.Setup(powerupIcons.Count);
            resetPowerup();
        }
        else
        {
            // re-render the contents of the powerup from the previous time
            for (int i = 0; i < powerupInventory.Items.Count; i++)
            {
                Powerup p = powerupInventory.Get(i);
                if (p != null)
                {
                    AddPowerupUI(i, p.powerupTexture);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPowerup()
    {
        for (int i = 0; i < powerupIcons.Count; i++)
        {
            powerupIcons[i].SetActive(false);
        }
    }

    void AddPowerupUI(int index, Texture t)
    {
        powerupIcons[index].GetComponent<RawImage>().texture = t;
        powerupIcons[index].SetActive(true);
    }

    public void AddPowerup(Powerup p)
    {
        powerupInventory.Add(p, (int)p.index);
        AddPowerupUI((int)p.index, p.powerupTexture);
    }

    public void OnApplicationQuit()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        powerupInventory.Clear();
    }

    public void AttemptConsumePowerup(KeyCode k)
    {
        Debug.Log("Consume pup");
        int i = powerupKeyCodes.FindIndex(_k => _k == k);
        if (i < 0) return;
        Powerup powerup = powerupInventory.Get(i);
        powerupInventory.Remove(i);
        RemoveUI(i);
        UpdateEffect(powerup);        
    }

    private void RemoveUI(int i)
    {
        powerupIcons[i].GetComponent<RawImage>().texture = null;
        powerupIcons[i].SetActive(false);
    }

    private void UpdateEffect(Powerup powerup)
    {
        marioMaxSpeed.ApplyChange(powerup.aboluteSpeedBooster);
        StartCoroutine(RemoveEffect(marioMaxSpeed, powerup.aboluteSpeedBooster, powerup.duration));
        marioJumpSpeed.ApplyChange(powerup.absoluteJumpBooster);
        StartCoroutine(RemoveEffect(marioJumpSpeed, powerup.absoluteJumpBooster, powerup.duration));
    }

    IEnumerator RemoveEffect(IntVariable intVar, int change, int duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Removing effect");
        intVar.ApplyChange(-change);
    }
}
