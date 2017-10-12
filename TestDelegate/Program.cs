using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    //Delegate is an object that knows how to call a method(or a group of methods)
    //Delegate is a reference to a function
    //Why do we need delegates?
    //For designing extensible and flexible applications(e.g. frameworks)
    //An alternative is Interface
    //Use a delegate when
    //[1]An eventing design pattern is used
    //[2]The caller doesn't need to access other properties or methods on the object implementing the method
    class Program
    {
        static void Main(string[] args)
        {
            //-using processor delegate
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);

            Console.WriteLine("------------------------------------");

            //-using generic processor delegate
            var gProcessor = new GenericPhotoProcessor();
            Action<Photo> gFilterHandler = filters.ApplyBrightness;
            gFilterHandler += filters.ApplyContrast;
            gFilterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
        }
    }
}
