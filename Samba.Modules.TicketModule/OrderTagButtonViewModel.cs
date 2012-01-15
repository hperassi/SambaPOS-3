﻿using System.Collections.Generic;
using System.Linq;
using Samba.Domain.Models.Tickets;
using Samba.Localization.Properties;
using Samba.Presentation.Common;

namespace Samba.Modules.TicketModule
{
    public class OrderTagButtonViewModel : ObservableObject
    {
        public OrderTag Model { get; set; }
        private readonly IEnumerable<Order> _selectedOrders;

        public OrderTagButtonViewModel(IEnumerable<Order> selectedOrders, OrderTag model)
        {
            _selectedOrders = selectedOrders;
            Model = model;
            if (string.IsNullOrEmpty(model.Name))
                model.Name = string.Format("[{0}]", Resources.NewProperty);
        }

        public string Name { get { return Model.Name; } set { Model.Name = value; } }
        public string Color
        {
            get
            {
                if (_selectedOrders != null && _selectedOrders.All(x => x.IsTaggedWith(Model)))
                    return "Red";
                return "Transparent";
            }
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => Color);
        }
    }
}