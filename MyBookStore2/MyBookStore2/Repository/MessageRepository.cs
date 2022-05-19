using Microsoft.Extensions.Options;
using MyBookStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertconfiguration;

        public MessageRepository(IOptionsMonitor <NewBookAlertConfig> newBookAlertconfiguration)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration;
          
        }
        public string GetName()
        {
            return _newBookAlertconfiguration.CurrentValue.BookName;
        }
    }
}
