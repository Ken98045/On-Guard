using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class ScheduledPreset : Form
  {
    public PresetTrigger TriggerInfo { get; }
    public ScheduledPreset()
    {
      TriggerInfo = new PresetTrigger();
      InitializeComponent();
    }

    public ScheduledPreset(PresetTrigger trigger)
    {
      TriggerInfo = new PresetTrigger(trigger);

      InitializeComponent();
      PresetNameTextBox.Text = trigger.Name;
      PresetNumeric.Value = trigger.PresetNumber;

      switch (trigger.TriggerType)
      {
        case PresetTriggerType.Sunrise:
          SunriseRadio.Checked = true;
          break;

        case PresetTriggerType.Sunset:
          SunsetRadio.Checked = true;
          break;

        case PresetTriggerType.AtTime:
          TimeRadio.Checked = true;
          TriggerTime.Value = trigger.TriggerTime;
          break;
      }

    }

    private void OnRadioChanged(object sender, EventArgs e)
    {
      if (SunriseRadio.Checked || SunsetRadio.Checked)
      {
        TriggerTime.Enabled = false;
      }
      else
      {
        TriggerTime.Enabled = true;
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      TriggerInfo.Name = PresetNameTextBox.Text;
      if (SunriseRadio.Checked)
      {
        TriggerInfo.TriggerType = PresetTriggerType.Sunrise;
      }
      else if (SunsetRadio.Checked)
      {
        TriggerInfo.TriggerType = PresetTriggerType.Sunset;
      }
      else
      {
        TriggerInfo.TriggerType = PresetTriggerType.AtTime;
        TriggerInfo.TriggerTime = TriggerTime.Value;
      }

      TriggerInfo.PresetNumber = (int)PresetNumeric.Value;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }

  public enum PresetTriggerType
  {
    Sunrise,
    Sunset,
    AtTime
  }

  public class PresetTrigger
  {
    public PresetTrigger()
    {
      ID = Guid.NewGuid();
      TriggerTime = DateTime.MinValue;
    }

    public PresetTrigger(PresetTrigger src)
    {
      ID = src.ID;
      Name = src.Name;
      TriggerType = src.TriggerType;
      PresetNumber = src.PresetNumber;
      TriggerTime = src.TriggerTime;
    }

    public Guid ID { get; set; }
    public string Name { get; set; }
    public int PresetNumber { get; set; }
    public PresetTriggerType TriggerType { get; set; }

    public DateTime TriggerTime { get; set; }


  }

}
