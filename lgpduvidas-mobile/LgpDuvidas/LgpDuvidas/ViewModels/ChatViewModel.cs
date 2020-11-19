using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class ChatViewModel
    {
        public IWatsonAssistantService WatsonAssistant => DependencyService.Get<IWatsonAssistantService>();

        public string input { get; set; }
        public WatsonMessage ActualMessage { get; set; }
        public ObservableCollection<ChatText> Messages { get; }
        public ICommand SendMessage { get; }


        public ChatViewModel()
        {
            Messages = new ObservableCollection<ChatText>();
            SendMessage = new Command(OnSendMessage);
        }

        public void OnAppearing()
        {
            ActualMessage = new WatsonMessage();
            if (Messages.Count <= 0)
                Messages.Add(new ChatText { text = "Oi, consigo responder dúvidas sobre a LGPD\nGostaria de informar que gravamos as mensagens de nossa conversa, para me atualizar sobre os assuntos mais relevantes e aprimorar meus conhecimentos", isResponse = true });
            _countErros = 0;
        }

        private int _countErros = 0;
        private async void OnSendMessage()
        {
            if (String.IsNullOrWhiteSpace(input))
                return;

            ActualMessage.input = input;
            Messages.Add(new ChatText { isResponse = false, text = input });

            DependencyService.Get<IKeyboardHelper>().HideKeyboard();
            ActualMessage.input = string.Empty;

            ActualMessage = await WatsonAssistant.Send(ActualMessage);
            if (ActualMessage != null)
            {
                Messages.Add(new ChatText { isResponse = true, text = ActualMessage.text });
            }
            else
            {
                if (_countErros == 0)
                    Messages.Add(new ChatText { isResponse = true, text = "Desculpe, houve um problema em nossos servidores\nConversamos mais tarde tudo bem?" });
                else
                    Messages.Add(new ChatText { isResponse = true, text = "Desculpe, mas ainda não resolvemos\nConversamos mais tarde tudo bem?" });

                _countErros++;
            }
        }
    }
}