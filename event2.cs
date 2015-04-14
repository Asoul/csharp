// events1.cs
using System;
using System.Threading;
namespace AsoulAPI {

   

   public class Asoul {

      public delegate void MyHandler(int q);

      public Asoul () {
         Thread t = new Thread(new ThreadStart(MyWork));
         count = 0;
         t.Start();
      }

      public void MyWork() {
         while (!_shouldStop) {
            Thread.Sleep(100);
            RaiseEvent(count);
            count += 1;
         }
         
      }
      public event MyHandler MyEvent;p

      public void RaiseEvent(int i) {
         // MyEventArgs args = new MyEventArgs(i);
         MyEvent(i);
      }

      public void Stop() {
         _shouldStop = true;
      }
      private volatile bool _shouldStop;
      private int count;
   }
}

namespace TestEvents {

   using AsoulAPI;

   class Test  {
      private static void HandleFunction(int q) {
         Console.WriteLine("Get {0}", q);
      }
      public static void Main() {
         Asoul obj = new Asoul();
         obj.MyEvent += new Asoul.MyHandler(HandleFunction);

         Thread.Sleep(1000);
         obj.Stop();
      }
   }
}