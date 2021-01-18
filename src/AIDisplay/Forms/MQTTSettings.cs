using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SAAI.Properties;

namespace SAAI
{
  public partial class MQTTSettings : Form
  {
    public MQTTSettings()
    {
      InitializeComponent();

      ServerText.Text = Storage.GetGlobalString("MQTTServerAddress");
      PortNumeric.Value = Storage.GetGlobalInt("MQTTPort");
      UserText.Text = Storage.GetGlobalString("MQTTUser");
      PasswordText.Text = Storage.GetGlobalString("MQTTPassword");

      int coolDown = Storage.GetGlobalInt("MQTTCoolDown");
      if (coolDown == 0)
      {
        coolDown = Settings.Default.MQTTCoolDown;
      }
      CoolDownNumeric.Value = coolDown;

      UseSecureLinkCheck.Checked = Storage.GetGlobalBool("MQTTUseSecureLink");

      string motionTopic = Storage.GetGlobalString("MQTTMotionTopic");
      if (string.IsNullOrEmpty(motionTopic))
      {
        motionTopic = Settings.Default.MQTTMotionTopic;
      }
      MotionActivityText.Text = motionTopic;

      string motionPayload = Storage.GetGlobalString("MQTTMotionPayload");
      if (string.IsNullOrEmpty(motionPayload))
      {
        motionPayload = Settings.Default.MQTTMotionPayload;
      }
      MotionActivityPayloadText.Text = motionPayload;

      string stoppedTopic = Storage.GetGlobalString("MQTTStoppedTopic");
      if (string.IsNullOrEmpty(stoppedTopic))
      {
        stoppedTopic = Settings.Default.MQTTStoppedTopic;
      }
      StoppedActivityTopicText.Text = stoppedTopic;

      string stoppedPayload = Storage.GetGlobalString("MQTTStoppedPayload");
      if (string.IsNullOrEmpty(stoppedPayload))
      {
        stoppedPayload = Settings.Default.MQTTStoppedPayload;
      }
      StoppedPayloadText.Text = stoppedPayload;

      if (PortNumeric.Value == 0)
      {
        PortNumeric.Value = 1883;
      }

      if (string.IsNullOrEmpty(ServerText.Text))
      {
        ServerText.Text = "localhost";
      }

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      Storage.SetGlobalString("MQTTServerAddress", ServerText.Text);
      Storage.SetGlobalInt("MQTTPort", (int)PortNumeric.Value);
      Storage.SetGlobalString("MQTTUser", UserText.Text);
      Storage.SetGlobalString("MQTTPassword", PasswordText.Text);
      Storage.SetGlobalInt("MQTTCoolDown", (int) CoolDownNumeric.Value);
      Storage.SetGlobalBool("MQTTUseSecureLink", UseSecureLinkCheck.Checked);
      Storage.SetGlobalString("MQTTMotionTopic", MotionActivityText.Text);
      Storage.SetGlobalString("MQTTMotionPayload", MotionActivityPayloadText.Text);
      Storage.SetGlobalString("MQTTStoppedTopic", StoppedActivityTopicText.Text);
      Storage.SetGlobalString("MQTTStoppedPayload", StoppedPayloadText.Text);

      DialogResult = DialogResult.OK;

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

  }

  public class MQTTData
  {
    public MQTTData(string serverAddress, int port, string userName, string password)
    {
      ServerAddress = serverAddress;
      Port = port;
      UserName = userName;
      Password = password;
    }

    public MQTTData(MQTTData data)
    {
      if (data != null)
      {
        ServerAddress = data.ServerAddress;
        Port = data.Port;
        UserName = data.UserName;
        Password = data.Password;
      }
    }

    public string ServerAddress { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }

}
