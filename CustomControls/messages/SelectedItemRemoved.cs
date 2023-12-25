using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.messages
{
    public class SelectedItemRemoved : ValueChangedMessage<string>
    {
        public SelectedItemRemoved(string itemtxt) : base(itemtxt)
        { }
    }
}
