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
  public partial class AIAlertDialog : Form
  {
    public AIAlertDialog()
    {
      InitializeComponent();
      foreach (var options in EmailAddresses.EmailAddressList)
      {
        EmailListBox.Items.Add(options.EmailAddress);
      }

      string emailRecipient = Storage.Instance.GetGlobalString("NotifyAIGoneEmail");

      if (!string.IsNullOrEmpty(emailRecipient))
      {
        EmailListBox.SelectedItem = emailRecipient;
      }

      string mqttAIDiedTopic = Storage.Instance.GetGlobalString("MQTTaiDiedTopic");
      string mqttAIDiedPayload = Storage.Instance.GetGlobalString("MQTTaiDiedPayload");
      bool mqttSendAIDied = Storage.Instance.GetGlobalBool("MQTTSendAIDied");

      if (!string.IsNullOrEmpty(mqttAIDiedTopic))
      {
        AIDiedTopicText.Text = mqttAIDiedTopic;
      }

      if (!string.IsNullOrEmpty(mqttAIDiedPayload))
      {
        AIDiedPayloadText.Text = mqttAIDiedPayload;
      }

      sendAIDiedMQTTCheckbox.Checked = mqttSendAIDied;

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (EmailListBox.SelectedItems.Count > 0)
      {
        Storage.Instance.SetGlobalString("NotifyAIGoneEmail", (string)EmailListBox.SelectedItem);
      }

      Storage.Instance.SetGlobalString("MQTTaiDiedTopic", AIDiedTopicText.Text);
      Storage.Instance.SetGlobalString("MQTTaiDiedPayload", AIDiedPayloadText.Text);
      Storage.Instance.SetGlobalBool("MQTTSendAIDied", sendAIDiedMQTTCheckbox.Checked);
      Storage.Instance.Update();
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.RemoveGlobalValue("NotifyAIGoneEmail");
      DialogResult = DialogResult.OK;
    }
  }
}

