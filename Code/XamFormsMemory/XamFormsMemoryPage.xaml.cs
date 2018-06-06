using Xamarin.Forms;

namespace XamFormsMemory
{
    public partial class XamFormsMemoryPage : ContentPage
    {
        public XamFormsMemoryPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new EventsPage());
        }
    }
}
