using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLSharp.Core;

namespace example
{
    class Program
    {

        

        static void Main(string[] args)
        {
            var trtr= new trtrtr();
            trtr.AuthUser();
           
            while (true)
            {
                
            }
        }
    }

     class trtrtr
    {
        public trtrtr()
        {
   
        }

        public async Task AuthUser()
        {
            var store = new FileSessionStore();
            var client = new TelegramClient(store, "session");

            await client.Connect();
            var hash = await client.SendCodeRequest("375257307554");
            var code = "70342"; // you can change code in debugger
            int n;
            var t = Console.ReadLine();
            code = t;
            var user = await client.MakeAuth("375257307554", hash, code);
            Console.WriteLine("fdfdfdfd");

            var userByPhoneId = await client.ImportContactByPhoneNumber("375299969274");
            //int id =(int)userByUserNameId;
            await client.SendMessage(userByPhoneId.Value, "Hello Habr!");
            Assert.IsNotNull(user);

            var hist = await client.GetMessagesHistoryForContact(userByPhoneId.Value, 0, 1000);
            hist.Count();
        }
    }

}
