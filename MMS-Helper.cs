using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAAI
{
  /*
   * Xfinity Mobile: number@vtext.com (SMS), number@mypixmessages.com (MMS) 
Virgin Mobile: number@vmobl.com (SMS), number@vmpix.com (MMS) 
Tracfone: number@mmst5.tracfone.com (MMS) 
Simple Mobile: number@smtext.com (SMS) 
Mint Mobile: number@mailmymobile.net (SMS) 
Red Pocket: number@vtext.com (SMS) 
Metro PCS: number@mymetropcs.com (SMS & MMS) 
Boost Mobile: number@sms.myboostmobile.com (SMS), number@myboostmobile.com (MMS) 
Cricket: number@sms.cricketwireless.net (SMS), number@mms.cricketwireless.net (MMS) 
Republic Wireless: number@text.republicwireless.com (SMS) 
Google Fi (Project Fi): number@msg.fi.google.com (SMS & MMS) 
U.S. Cellular: number@email.uscc.net (SMS), number@mms.uscc.net (MMS) 
Ting: number@message.ting.com 
Consumer Cellular: number@mailmymobile.net 
C-Spire: number@cspire1.com 
Page Plus: number@vtext.com
*/

  public partial class MMS_Helper : Form
  {
    public string SelectedMMS = string.Empty;
    public MMS_Helper()
    {
      InitializeComponent();

      string[][] numbers = new string[21][]
      {
      new string [] {"Verizon", "number@vzwpix.com"},
      new string []{ "Xfinity Mobile", "number@mypixmessages.com" },
      new string []{ "Virgin Mobile",  "number@vmpix.com" },
      new string []{  "Tracfone", "number@mmst5.tracfone.com" },
      new string []{ "Simple Mobile", "number@smtext.com" },
      new string []{ "Mint Mobile", "number@mailmymobile.net" },
      new string []{"Red Pocket", "number@vtext.com" },
      new string []{"Boost Mobile", "number@myboostmobile.com" },
      new string []{"Cricket", "number@mms.cricketwireless.net" },
      new string []{"Republic Wireless", "number@text.republicwireless.com" },
      new string []{"Google Fi", "number@msg.fi.google.com" },
      new string []{"U.S. Cellular", "number@mms.uscc.net" },
      new string []{"Ting", "number@message.ting.com"},
      new string []{"Consumer Cellular", "number@mailmymobile.net"  },
      new string []{"C-Spire", "number@cspire1.com" },
      new string []{"Page Plus", "number@vtext.com" },
      new string []{"TMobile", "number@tmomail.net" },
      new string[]{"AT&T", "number@mms.att.net" },
      new string[]{"Metro PCS", "number@mymetropcs.com" },
      new string[]{"Sprint", "number@pm.sprint.com" },
      new string[]{"Alltel", "mms.alltelwireless.com " }

    };



      foreach (var carrier in numbers)
      {
        ListViewItem item = new ListViewItem(carrier);
        mmsListView.Items.Add(item);
      }

    }

    private void OnActiveate(object sender, EventArgs e)
    {
      ListViewItem item = mmsListView.Items[mmsListView.SelectedIndices[0]];
      SelectedMMS = item.SubItems[1].Text;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
