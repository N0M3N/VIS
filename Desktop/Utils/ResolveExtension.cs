using CommonServiceLocator;
using System;
using System.Windows.Markup;

namespace Desktop.Utils
{
    public class ResolveExtension : MarkupExtension
    {
        [ConstructorArgument("viewModelType")]
        public Type ViewModelType { get; set; }

        public ResolveExtension(Type viewModel)
        {
            ViewModelType = viewModel;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ServiceLocator.Current.GetInstance(ViewModelType);
        }
    }
}
