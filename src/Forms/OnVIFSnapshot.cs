using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using OnGuardCore;

namespace OnGuardCore
{
  public partial class OnVIFSnapshot : Form
  {
    OnVIFSupport _onVIFSupport;
    ModelessMessageWindow _win;
    CameraData _camera;

    public OnVIFSnapshot(CameraData camera)
    {
      InitializeComponent();

      _camera = camera;
      _win = new ModelessMessageWindow(this, "Busy", "Loading OnVIF Information.  Please Wait", false);
      _onVIFSupport = new OnVIFSupport();
    }

    public async Task InitAsync()
    {
      _win.Show();

      try
      {
        CameraContactData data = _camera.Contact;
        await _onVIFSupport.Init(data.CameraIPAddress, data.OnVIFPort, data.CameraUserName, data.CameraPassword).ConfigureAwait(true);
        _win.Hide();

        foreach (ProfileData profileData in _onVIFSupport.Profiles)
        {
          profileListBox.Items.Add(string.Format("{0} - {1} {2}", profileData.Name, profileData.Width, profileData.Height));
        }


        if (profileListBox.Items.Count > 0)
        {
          profileListBox.SelectedIndex = 0;
        }

      }
      catch (Exception)
      {
        _win.Hide();
        MessageBox.Show(this, "There was an error when attemping to contact the OnVIF camera.  Please check the address, port, user name, and password", "Camera Definition Error!");
        this.TopLevel = true;
      }

      _win.Hide();
    }


    /*async Task WaitForOnVIF()
    {
      try
      {
        await _onVIFSupport.Init().ConfigureAwait(true);

        if (this.InvokeRequired)
        {
          Dbg.Write("Invoke Required on WaitForOnVIF");
        }

        _win.Hide();
        DialogResult = DialogResult.None;
        this.TopLevel = true;
        foreach (ProfileData data in OnVIFSupport.Profiles)
        {
          profileListBox.Items.Add(string.Format("{0} - {1} {2}", data.Name, data.Width, data.Height));
        }


        if (profileListBox.Items.Count > 0)
        {
          profileListBox.SelectedIndex = 0;
        }

      }
      catch (Exception ex)
      {
        _win.Hide();
        MessageBox.Show(this, "There was an error when attemping to contact the OnVIF camera.  Please check the address, port, user name, and password", "Camera Definition Error!");
        this.TopLevel = true;
      }


      // await OnVIFSupport.InitComplete.WaitAsync();
    }
    */


    public OnVIFSupport OnVIFSupport { get => _onVIFSupport; set => _onVIFSupport = value; }

    private void OkButton_Click(object sender, EventArgs e)
    {
      _onVIFSupport.SelectedProfile = _onVIFSupport.Profiles[profileListBox.SelectedIndex].Token;
      _onVIFSupport.SelectedProfileIndex = profileListBox.SelectedIndex;
      _camera.Contact.ONVIF = _onVIFSupport;

      _camera.Contact.JPGSnapshotURL = SnapshotTextBox.Text;
      _camera.Contact.PresetSettings.CameraMake = "OnVIF";
      _camera.Contact.PresetSettings.CameraModel = "OnVIF";
      _camera.Contact.PresetSettings.PresetMethod = PTZMethod.OnVIF;
      foreach (var preset in _onVIFSupport.PresetsResponse.Preset)
      {
        Preset p = new ();
        p.Name = preset.Name;
        p.Command = preset.token;
        _camera.Contact.PresetSettings.PresetList.Add(p);
      }

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void OnClosed(object sender, FormClosedEventArgs e)
    {

    }


    private void OnLocationChanged(object sender, EventArgs e)
    {

    }

    private void OnVisibleChanged(object sender, EventArgs e)
    {

    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      _onVIFSupport.SelectedProfile = _onVIFSupport.Profiles[profileListBox.SelectedIndex].Token;
      _onVIFSupport.SelectedProfileIndex = profileListBox.SelectedIndex;
      SnapshotTextBox.Text = _onVIFSupport.GetSnapshotUri();
    }

    private void Label5_Click(object sender, EventArgs e)
    {

    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("ONVIF Snapshots", new Size(320, 240), "ONVIFSnapshotHelp.rtf");
      dlg.ShowDialog();
    }
  }
}
