// events1.cs
using System;
using System.Threading;
namespace YuantaAPI {

   public delegate void OnResponseEventHandler(object sender, EventArgs e);

   public class Yuanta {

      public Yuanta () {
         Thread t = new Thread(new ThreadStart(MyWork));
         t.Start();
      }

      public void MyWork() {
         while (!_shouldStop) {
            Thread.Sleep(100);
            RaiseEvent();
         }
         
      }
      public event OnResponseEventHandler OnResponse;

      public void RaiseEvent() {
         OnResponse(this, EventArgs.Empty);
      }

      public void Stop() {
         _shouldStop = true;
      }
      private volatile bool _shouldStop;
   }
}

namespace TestEvents {

   using YuantaAPI;

   class Test  {
      private static void HandleFunction(object sender, EventArgs e) {
         Console.WriteLine("This is called when the event fires.");
      }
      public static void Main() {
         Yuanta obj = new Yuanta();
         obj.OnResponse += new OnResponseEventHandler(HandleFunction);

         Thread.Sleep(1000);
         obj.Stop();
      }
   }
}