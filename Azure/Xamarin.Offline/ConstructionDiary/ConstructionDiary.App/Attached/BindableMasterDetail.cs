using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using static Xamarin.Forms.BindableProperty;

namespace ConstructionDiary.App.Attached
{
    public class BindableMasterDetail
    {
        public static readonly BindableProperty DetailProperty = BindableProperty.CreateAttached("Detail", typeof(object), typeof(BindableMasterDetail), null, BindingMode.OneWay, null, new BindingPropertyChangedDelegate(OnDetailChanged));

        public static readonly BindableProperty MasterProperty = BindableProperty.CreateAttached("Master", typeof(object), typeof(BindableMasterDetail), null, BindingMode.OneWay, null, new BindingPropertyChangedDelegate(OnMasterChanged));

        public static readonly BindableProperty NavigationProperty = BindableProperty.CreateAttached("Navigation", typeof(INavigationController), typeof(BindableMasterDetail), null, BindingMode.OneWay, null, new BindingPropertyChangedDelegate(OnNavigationChanged));

        public static object GetDetail(BindableObject view)
        {
            return (object)view.GetValue(DetailProperty);
        }

        public static object GetMaster(BindableObject view)
        {
            return (object)view.GetValue(MasterProperty);
        }

        public static INavigationController GetNavigation(BindableObject view)
        {
            return (INavigationController)view.GetValue(NavigationProperty);
        }

        public static void SetDetail(BindableObject view, object value)
        {
            view.SetValue(DetailProperty, value);
        }

        public static void SetMaster(BindableObject view, object value)
        {
            view.SetValue(MasterProperty, value);
        }

        public static void SetNavigation(BindableObject view, INavigationController value)
        {
            view.SetValue(NavigationProperty, value);
        }

        private static Page GetNavigationPage(object newValue)
        {
            var templateKey = newValue?.GetType().GetCustomAttribute<TemplateKeyAttribute>();

            Page page = null;

            if (templateKey != null)
            {
                var template = App.Current.Resources[templateKey.TemplateKey] as DataTemplate;

                page = template?.CreateContent() as Page;
            }

            if (page != null)
            {
                page.BindingContext = newValue;

                foreach (var item in page.ToolbarItems)
                {
                    item.BindingContext = newValue;
                }
            }

            return page;
        }

        private static async void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Page page = GetNavigationPage(newValue);

            var masterPage = (MasterDetailPage)bindable;

            await masterPage.Detail.Navigation.PushAsync(page);

            //masterPage.Detail = page;
        }

        private static void OnMasterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Page page = GetNavigationPage(newValue);

            var masterPage = (MasterDetailPage)bindable;

            masterPage.Master = page;
        }

        private static void OnNavigationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var navigationPage = (NavigationPage)bindable;

            var newNav = newValue as INavigationController;

            if (newNav != null)
            {
                newNav.Added += p =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Page page = GetNavigationPage(p);
                        navigationPage.Navigation.PushAsync(page);
                    });
                };

                newNav.Removed += p =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        var page = navigationPage.Navigation.NavigationStack.FirstOrDefault(x => x.BindingContext == p);
                        if (page != null)
                        {
                            navigationPage.Navigation.RemovePage(page);
                        }
                    });
                };

                foreach (var item in newNav.Stack)
                {
                    var page = GetNavigationPage(item);
                    navigationPage.Navigation.PushAsync(page);
                }
            }
        }
    }
}