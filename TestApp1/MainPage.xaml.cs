using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TestApp1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Contact _item;
        public MainPage()
        {
            this.InitializeComponent();


            BaseExample.ItemsSource = Contact.GetContactsAsync();
        }

        private void SourceImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Navigate to detail page.
            // Suppress the default animation to avoid conflict with the connected animation.
            Frame.Navigate(typeof(BlankPage1), null, new SuppressNavigationTransitionInfo());
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //ConnectedAnimationService.GetForCurrentView()
            //    .PrepareToAnimate("forwardAnimation", SourceImage);
            if (_item != null)
                BaseExample.PrepareConnectedAnimation("forwardAnimation", _item, "PortraitEllipse");
            // You don't need to explicitly set the Configuration property because
            // the recommended Gravity configuration is default.
            // For custom animation, use:
            // animation.Configuration = new BasicConnectedAnimationConfiguration();
        }

        private async void ContactsListView_Loaded(object sender, RoutedEventArgs e)
        {
            //Data item = GetPersistedItem(); // Get persisted item
            //if (item != null)
            //{
            //    ContactsListView.ScrollIntoView(item);
            //    ConnectedAnimation animation =
            //        ConnectedAnimationService.GetForCurrentView().GetAnimation("portrait");
            //    if (animation != null)
            //    {
            //        await ContactsListView.TryStartConnectedAnimationAsync(
            //            animation, item, "PortraitEllipse");
            //    }
            //}
        }

        private void BaseExample_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (BaseExample.ContainerFromItem(e.ClickedItem) is ListViewItem container)
            {
                _item = container.Content as Contact;
                Frame.Navigate(typeof(BlankPage1), null, new SuppressNavigationTransitionInfo());
            }
        }

        //void PrepareAnimationWithItem(Data item)
        //{
        //    ContactsListView.PrepareConnectedAnimation("portrait", item, "PortraitEllipse");
        //}
    }

    public class Data
    {

        public string name = "1";
    }

    public class Contact
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Company { get; private set; }
        public string Name => FirstName + " " + LastName;

        public Contact(string firstName, string lastName, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }

        public static List<Contact> GetContactsAsync()
        {
            List<Contact> contact = new List<Contact>()
            {
                new Contact("1","2","3"),
                new Contact("1","2","3"),
                new Contact("1","2","3")
            };

            return contact;

        }
    }

}
