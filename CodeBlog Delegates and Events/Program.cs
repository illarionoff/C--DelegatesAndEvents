using System;

namespace CodeBlog_Delegates_and_Events
{
    // public delegate тип_возвращаемого_значения имя_делегата(тип_аргумента аргумент)

    class Person
    {
        public string Name { get; set; }
        public event Action GoToSleep;
        public event EventHandler DoWork;

        public void TakeTime(DateTime now)
        {
            if (now.Hour <= 8)
            {
                GoToSleep?.Invoke();
            }
            else
            {

                DoWork?.Invoke(this, null);
            }
        }
    }

    class Friend
    {
        public void CallFriend(object sender, EventArgs e)
        {
            if (sender is Person)
            {
                Console.WriteLine($"Call {((Person)sender).Name}");
            }
        }
    }

    internal class Program
    {
        #region delegates

        //public delegate void MyDelegate(); // same as Action action = method_name;

        //public static void Method1()
        //{
        //    Console.WriteLine("Method 1");
        //}

        //public static int Method2()
        //{
        //    Console.WriteLine("Method 2");
        //    return 0;
        //}

        //public static void Method3(int i)
        //{
        //    Console.WriteLine($"Method {i}");
        //}

        //public static void Method4()
        //{
        //    Console.WriteLine("Method 4");
        //}

        //public static bool Method4(int i)
        //{
        //    if (i > 0)
        //        return true;
        //    return false;
        //}

        //public static int Method5(int i)
        //{
        //    return i;
        //}

        #endregion

        //public delegate void MyDelegate();
        //public event MyDelegate Event;
        //public event Action EventAction;


        private static void Main(string[] args)
        {
            #region delegates

            //MyDelegate mDelegate = Method1;
            //mDelegate += Method4;
            //mDelegate();
            //Console.WriteLine("-----------------------------------");
            //mDelegate -= Method1;
            //mDelegate();
            //Console.WriteLine("-----------------------------------");
            //MyDelegate mDelegate2 = new MyDelegate(Method4);
            //mDelegate2 += Method4;
            //mDelegate2.Invoke();
            //Console.WriteLine("-----------------------------------");
            //MyDelegate mDelegate3 = mDelegate + mDelegate2;
            //mDelegate3();
            //Console.WriteLine("-----------------------------------");
            //Action action = Method1;
            //action += Method4;
            //action();

            //Console.WriteLine("---------------Action--------------");
            ////public delegate void Action() - optional arguments;
            //Action<int> action2 = Method3;
            //action2(3);

            //Console.WriteLine("-------------Predicate-------------");
            ////public delegate bool Predicate<T>(T value)
            //Predicate<int> action3 = Method4;
            //Console.WriteLine(action3(2));

            //Console.WriteLine("----------------Func---------------");
            ////public delegate return_type Func(arg_type arg) - optional arguments;
            //Func<int, int> action4 = Method5;
            //Console.WriteLine(action4(3));

            #endregion

            Person person  = new Person()
            {
                Name = "Alex"
            };

            Friend friend = new Friend();

            person.GoToSleep += Person_GoToSleep;
            person.DoWork += friend.CallFriend;
            person.DoWork += Person_DoWork;
            person.TakeTime(DateTime.Parse("27.12.2018 21:00:00"));
            person.TakeTime(DateTime.Parse("27.12.2018 04:00:00"));

        }

        private static void Person_DoWork(object sender, EventArgs e)
        {
            if (sender is Person)
            {
                Console.WriteLine($"{((Person) sender).Name} работает");
            }
        }

        private static void Person_GoToSleep()
        {
            Console.WriteLine("Go to sleep!");
        }
    }
}