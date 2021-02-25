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
using OnGuardCore.Properties;

namespace OnGuardCore
{
  public partial class MQTTSettings : Form
  {
    public MQTTSettings()
    {
      InitializeComponent();

      ServerText.Text = Storage.Instance.GetGlobalString("MQTTServerAddress");
      PortNumeric.Value = Storage.Instance.GetGlobalInt("MQTTPort");
      UserText.Text = Storage.Instance.GetGlobalString("MQTTUser");
      PasswordText.Text = Storage.Instance.GetGlobalString("MQTTPassword");

      int coolDownValue = Storage.Instance.GetGlobalInt("MQTTCoolDown");
      CoolDownNumeric.Value = (decimal)(coolDownValue);

      UseSecureLinkCheck.Checked = Storage.Instance.GetGlobalBool("MQTTUseSecureLink");

      string motionTopic = Storage.Instance.GetGlobalStringNull("MQTTMotionTopic");
      if (null != motionTopic)
      {
        MotionActivityText.Text = motionTopic;
      }
      

      string motionPayload = Storage.Instance.GetGlobalStringNull("MQTTMotionPayload");
      if (null != motionPayload)
      {
        MotionActivityPayloadText.Text = motionPayload;
      }
      

      string stoppedTopic = Storage.Instance.GetGlobalStringNull("MQTTStoppedTopic");
      if (null != stoppedTopic)
      {
        StoppedActivityTopicText.Text = stoppedTopic;
      }

      string stoppedPayload = Storage.Instance.GetGlobalStringNull("MQTTStoppedPayload");
      if (null != stoppedPayload)
      {
        StoppedPayloadText.Text = stoppedPayload;
      }
      
      if (PortNumeric.Value == 0)
      {
        PortNumeric.Value = 1883;
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
