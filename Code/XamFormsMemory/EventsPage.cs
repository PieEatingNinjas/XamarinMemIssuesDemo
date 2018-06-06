using System;

using Xamarin.Forms;
using XamFormsMemory.CustomControls;

namespace XamFormsMemory
{
    public class EventsPage : ContentPage
    {
        public EventsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new CustomView()
                }
            };
        }
    }
}

