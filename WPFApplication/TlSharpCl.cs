using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLSharp.Core;

namespace WPFApplication
{
    public class  TlSharpCl
    {
        public FileSessionStore Store ;
        public TelegramClient Client;
        public string Hash;
        public TlSharpCl()
        {
             Store = new FileSessionStore();
             Client = new TelegramClient(Store, "session");
        }

        public async Task AuthUser()
        {
            await Client.Connect();
            Hash = await Client.SendCodeRequest("375257307554");
    
        }


        public async Task EnterCode(string codes)
        {            
            var code = codes;
            var user = await Client.MakeAuth("375257307554", Hash, code);
               
        }

        public async Task sendMessage(string number,string message)
        {
            var userByPhoneId = await Client.ImportContactByPhoneNumber(number);
            await Client.SendMessage(userByPhoneId.Value, message);
        }

    }
}
