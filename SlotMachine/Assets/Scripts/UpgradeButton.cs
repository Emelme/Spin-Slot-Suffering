using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
	public Upgrade upgrade;
	
	public bool isUpgraded;
  public UpgradeNode[] nodesToOpen;

  public bool canBeUpgraded;
  public UpgradeNode[] nodesToBeOpen;

  public void Update()
  {
      foreach (var node in nodesToBeOpen)
      {
          if (node.isOpen)
          {
              canBeUpgraded = true;
          }
      }

      if (isUpgraded)
      {
          foreach (var node in nodesToOpen)
          {
              node.isOpen = true;
          }
      }
  }
  
	public void OnButtonClick()
	{
      if (!canBeUpgraded || isUpgraded)
          return;
          
      upgrade.ExecuteUpgrade();

      isUpgraded = true;
	}
}
