// events1.cs
using System;
namespace AsoulProxy 
{

   public delegate void EventHandler(object sender, EventArgs e);

   public class Yuanta {

      public event EventHandler MyEvent;

      protected void RaiseEvent(EventArgs e) {
         if (MyEvent != null)
            MyEvent(this, e);
      }

      public void Start() {
         RaiseEvent(EventArgs.Empty);
      }
   }
}

namespace TestEvents
{
   using AsoulProxy;

   class MyProgram {

      private Yuanta yuanta;

      public MyProgram(Yuanta q) {
         yuanta = q;
         yuanta.Start += new EventHandler(SayYo);
      }

      private void SayYo(object sender, EventArgs e) {
         Console.WriteLine("Yo");
      }

      public void Stop() {
         yuanta.Start -= new EventHandler(SayYo);
         yuanta = null;
      }
   }

   class Test
   {
      public static void Main() {
         Yuanta yuanta = new Yuanta();
         
      }
      // Test the ListWithChangedEvent class.
      public static void Main() 
      {
      // Create a new list.
      ListWithChangedEvent list = new ListWithChangedEvent();

      // Create a class that listens to the list's change event.
      EventListener listener = new EventListener(list);

      // Add and remove items from the list.
      list.Add("item 1");
      
      Console.WriteLine("{0}", list[0]);
      list.Clear();
      listener.Detach();
      }
   }
}