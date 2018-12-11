using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Labb2OOADSimonOTobias.Objects
{
    public class BreachedSites : IImageCallback
    {

        public string Name { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string BreachDate { get; set; }
        public string AddedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Description { get; set; }
        private string _logoPath;
        public string LogoPath 
        { 
            get { return _logoPath; } 
            set 
            { 
                _logoPath = value;
                HttpRequest.RequestImage(value ,this);
                //Task.Run(() => {  }); 
            } 
        }
        public ImageSource MyImage { get; set; }

        public BreachedSites()
        {
        }

        public void ImageCallback(ImageSource image)
        {
            MyImage = image;
        }
    }
}
