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
using OnGuardCore.Src.Properties;

namespace OnGuardCore
{
  public partial class MQTTSettings : Form
  {
    public MQTTSettings()
    {
      InitializeComponent();

      string server = Storage.Instance.GetGlobalString("MQTTServerAddress");
      if (!string.IsNullOrEmpty(server))
      {
        ServerText.Text = server;
      }

      int port = Storage.Instance.GetGlobalInt("MQTTPort");
      if (port >= 80)
      {
        PortNumeric.Value = port;
      }

      UserText.Text = Storage.Instance.GetGlobalString("MQTTUser");
      PasswordText.Text = Storage.Instance.GetGlobalString("MQTTPassword");

      int coolDownValue = Storage.Instance.GetGlobalInt("MQTTCoolDown");
      if (coolDownValue >= 5)
      {
        CoolDownNumeric.Value = (decimal) coolDownValue;
      }

      UseSecureLinkCheck.Checked = Storage.Instance.GetGlobalBool("MQTTUseSecureLink");

      string motionTopic = Storage.Instance.GetGlobalStringNull("MQTTMotionTopic");
      if (!string.IsNullOrEmpty(motionTopic))
      {
        MotionActivityText.Text = motionTopic;
      }

      string motionPayload = Storage.Instance.GetGlobalStringNull("MQTTMotionPayload");
      if (!string.IsNullOrEmpty(motionPayload))
      {
        MotionActivityPayloadText.Text = motionPayload;
      }
      

      string stoppedTopic = Storage.Instance.GetGlobalStringNull("MQTTStoppedTopic");
      if (!string.IsNullOrEmpty(stoppedTopic))
      {
        StoppedActivityTopicText.Text = stoppedTopic;
      }

      string stoppedPayload = Storage.Instance.GetGlobalStringNull("MQTTStoppedPayload");
      if (!string.IsNullOrEmpty(stoppedPayload))
      {
        StoppedPayloadText.Text = stoppedPayload;
      }
      
      if (string.IsNullOrEmpty(ServerText.Text))
      {
        ServerText.Text = "localhost";
      }

      bool jsonFormat = Storage.Instance.GetGlobalBool("JSONFormat");
      jjsonFormatPaths.Checked = jsonFormat;

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.SetGlobalString("MQTTServerAddress", ServerText.Text);
      Storage.Instance.SetGlobalInt("MQTTPort", (int)PortNumeric.Value);
      Storage.Instance.SetGlobalString("MQTTUser", UserText.Text);
      Storage.Instance.SetGlobalString("MQTTPassword", PasswordText.Text);
      Storage.Instance.SetGlobalInt("MQTTCoolDown", (int) CoolDownNumeric.Value);
      Storage.Instance.SetGlobalBool("MQTTUseSecureLink", UseSecureLinkCheck.Checked);
      Storage.Instance.SetGlobalString("MQTTMotionTopic", MotionActivityText.Text);
      Storage.Instance.SetGlobalString("MQTTMotionPayload", MotionActivityPayloadText.Text);
      Storage.Instance.SetGlobalString("MQTTStoppedTopic", StoppedActivityTopicText.Text);
      Storage.Instance.SetGlobalString("MQTTStoppedPayload", StoppedPayloadText.Text);
      Storage.Instance.SetGlobalBool("JSONFormat", jjsonFormatPaths.Checked);
      Storage.Instance.Update();

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
