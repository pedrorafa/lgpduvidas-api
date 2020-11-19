using LgpDuvidas.Models;
using System.Collections.Generic;
using System.Linq;

namespace LgpDuvidas.ViewModels
{
    public class MessagesViewModel
    {
        public string Title { get; set; }
        public List<Message> Messages { get; set; }
        public MessagesViewModel(string title,IEnumerable<Message> messages)
        {
            Title = $"{title} - Messages";
            Messages = messages.ToList();
        }
        public void OnAppearing()
        {

        }
    }
}