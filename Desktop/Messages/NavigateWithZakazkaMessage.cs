using Models;
using System;

namespace Desktop.Messages
{
    internal class NavigateWithZakazkaMessage
    {
        internal Type PageType { get; set; }
        internal ZakazkaModel Zakazka { get; set; }
    }
}
