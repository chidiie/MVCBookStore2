using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using MyBookStore2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyBookStore2.Repository;

namespace MyBookStore2.Controllers
{
    //[Route("[controller]/[action]")]

    public class HomeController : Controller
    {
        //private readonly IConfiguration configuration;
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration, IMessageRepository messageRepository )
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;

        }


        [Route("~/")]
        public ViewResult Index()
        {

            bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;
            bool isDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;

            //var value = _messageRepository.GetName();
            //var result = configuration.GetValue<bool>("NewBookAlert:DisplayNewBookAlert");
            //var bookName = configuration.GetValue<string>("NewBookAlert:AppName");
            ////var result1 = configuration["AppName"];
            return View();
        }

        //[Route("~/about-us/{name:alpha:minlength(5):regex()}")]
        public ViewResult AboutUs()
        {
            return View();
        }
        
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
