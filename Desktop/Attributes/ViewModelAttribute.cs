using System;

namespace Desktop.Attributes
{
    public class ViewModelAttribute : Attribute
    {
        public enum ScopeType
        {
            SingleInstance,
            InstancePerDependency
        }

        public ScopeType Scope { get; set; }

        public ViewModelAttribute()
        {
            Scope = ScopeType.InstancePerDependency;
        }
    }
}
