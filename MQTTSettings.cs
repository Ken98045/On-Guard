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

      ServerText.Text = Settings.Default.MQTTServerAddress;
      PortNumeric.Value = Settings.Default.MQTTPort;
      UserText.Text = Settings.Default.MQTTUser;
      PasswordText.Text = Settings.Default.MQTTPassword;
      CoolDownNumeric.Value = Settings.Default.MQTTCoolDown;
      UseSecureLinkCheck.Checked = Settings.Default.MQTTUseSecureLink;

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
      Settings.Default.MQTTServerAddress = ServerText.Text;
      Settings.Default.MQTTPort = (int)PortNumeric.Value;
      Settings.Default.MQTTUser = UserText.Text;
      Settings.Default.MQTTPassword = PasswordText.Text;
      Settings.Default.MQTTCoolDown = (int) CoolDownNumeric.Value;
      Settings.Default.MQTTUseSecureLink = UseSecureLinkCheck.Checked;

      Settings.Default.Save();

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
      ServerAddress = data.ServerAddress;
      Port = data.Port;
      UserName = data.UserName;
      Password = data.Password;
    }

    public string ServerAddress { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }

}
