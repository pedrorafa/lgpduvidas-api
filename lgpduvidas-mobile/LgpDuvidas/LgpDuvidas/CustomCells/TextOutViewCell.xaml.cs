using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LgpDuvidas.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextOutViewCell : ViewCell
    {
        public string text { get; set; }
        public TextOutViewCell()
        {
            InitializeComponent();
        }
    }
}