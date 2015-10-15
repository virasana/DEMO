using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings _emailSettings;
        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            //Send the email
        }

        public EmailOrderProcessor(EmailSettings settings, EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

    }
}
