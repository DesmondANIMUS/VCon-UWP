
using System.Collections.ObjectModel;

namespace VCon
{
    class ChatMessageViewModel
    {
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
    }
}
