using LgpDuvidas.Models;
using Xamarin.Forms;

namespace LgpDuvidas.CustomCells
{
    public class SelectorMessageTemplate : DataTemplateSelector
    {
        private readonly DataTemplate textInDataTemplate;
        private readonly DataTemplate textOutDataTemplate;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as ChatText;
            if (messageVm == null)
                return null;
            return messageVm.isResponse ? this.textOutDataTemplate : this.textInDataTemplate;
        }


        public SelectorMessageTemplate()
        {
            this.textInDataTemplate = new DataTemplate(typeof(TextInViewCell));
            this.textOutDataTemplate = new DataTemplate(typeof(TextOutViewCell));
        }
    }
}
