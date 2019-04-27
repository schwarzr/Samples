using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using static Xamarin.Forms.BindableProperty;

namespace ConstructionDiary.App.Attached
{
    public class BindableMasterDetail
    {
        public static readonly BindableProperty DetailProperty = BindableProperty.CreateAttached("Detail", typeof(object), typeof(BindableMasterDetail), null, BindingMode.OneWay, null, new BindingPropertyChangedDelegate(OnDetailChanged));

        public static readonly BindableProperty MasterProperty = BindableProperty.CreateAttached("Master", typeof(object), typeof(BindableMasterDetail), null, BindingMode.OneWay, null, new BindingPropertyChangedDelegate(OnMasterChanged));

        public static object GetDetail(BindableObject view)
        {
            return (object)view.GetValue(DetailProperty);
        }

        public static object GetMaster(BindableObject view)
        {
            return (object)view.GetValue(MasterProperty);
        }

        public static void SetDetail(BindableObject view, bool value)
        {
            view.SetValue(DetailProperty, value);
        }

        public static void SetMaster(BindableObject view, bool value)
        {
            view.SetValue(MasterProperty, value);
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
            }

            return page;
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Page page = GetNavigationPage(newValue);

            var masterPage = (MasterDetailPage)bindable;

            masterPage.Detail = page;
        }

        private static void OnMasterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Page page = GetNavigationPage(newValue);

            var masterPage = (MasterDetailPage)bindable;

            masterPage.Master = page;
        }
    }
}